Public Class ModificarVentasDetalle

   Private _publicos As Publicos
   Private _entidad As Entidades.Venta
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Publicos.FacturacionIgnorarPCdeCaja
   Private _blnCajasModificables As Boolean = False
   Private _sucursal As Integer

   '# Algunos nombres que no se pueden obtener directamente de la venta
   Private _categoriaOriginal As String = String.Empty
   Private _nombreClienteVinculado As String = String.Empty
   Private _nombrePaciente As String = String.Empty
   Private _nombreDoctor As String = String.Empty
   Private _codigoPacienteOriginal As Long = 0
   Private _codigoDoctorOriginal As Long = 0
   Private _cambioFormaDePago As Boolean = False
   Private _modificaComision As Boolean = False

   Private _quitarPaciente As Boolean = False
   Private _quitarDoctor As Boolean = False
   Private _quitarClienteVinculado As Boolean = False

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.Venta, idFuncion As String)
      InitializeComponent()
      _entidad = entidad
      idFuncion = idFuncion
   End Sub

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         txtObservacion.MaxLength = Reglas.Publicos.Facturacion.FacturacionCantidadCaracteresObservaciones

         '# Carga Combos
         _publicos.CargaComboCategorias(cmbCategoria)
         _publicos.CargaComboEmpleados(cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)
         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         _publicos.CargaComboFormasDePago(cboFormaPago, "VENTAS")
         _publicos.CargaComboTipoDocumento(cmbTipoDoc, Entidades.Publicos.SiNoTodos.SI)

         _sucursal = actual.Sucursal.Id

         CargarComprobante()

         '# Si no visualiza los campos correspondientes a historia Clínica en la Facturación, tampoco muestro dichos campos para modificar.
         If Not Reglas.Publicos.FacturacionMuestraHistoriaClinica Then
            tbcDatos.TabPages.Remove(tbpHistoriaClinica)
         End If

      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         tsbGrabar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region


#Region "Métodos"
   Private Sub CargarDatosCliente(dr As DataGridViewRow, controlCodigo As Eniac.Controles.Buscador2, controlNombre As Eniac.Controles.Buscador2)
      CargarDatosCliente(dr, controlCodigo, controlNombre, Nothing)
   End Sub
   Private Sub CargarDatosCliente(dr As DataGridViewRow, controlCodigo As Eniac.Controles.Buscador2, controlNombre As Eniac.Controles.Buscador2,
                                  accion As Action(Of DataGridViewRow))
      If dr IsNot Nothing Then
         controlNombre.Text = dr.Cells("NombreCliente").Value.ToString()
         controlCodigo.Text = dr.Cells("CodigoCliente").Value.ToString()
         controlCodigo.Tag = dr.Cells("IdCliente").Value.ToString()
         controlCodigo.Selecciono = True
         controlNombre.Selecciono = True

         If accion IsNot Nothing Then
            accion(dr)
         End If
      End If
   End Sub

   Private Sub CargarComprobante()
      With _entidad
         '# Datos de Cabecera
         txtIdTipoComprobante.Text = .TipoComprobante.IdTipoComprobante
         txtLetra.Text = .LetraComprobante
         txtEmisorFactura.Text = .CentroEmisor.ToString()
         txtNumeroFactura.Text = .NumeroComprobante.ToString()

         '# Cliente
         bscCodigoCliente.Text = .Cliente.CodigoCliente.ToString()
         bscCodigoCliente.PresionarBoton()
         txtCategoriaFiscal.Text = .Cliente.CategoriaFiscal.NombreCategoriaFiscal

         '# Registros editables
         chbFecha.Enabled = Not .TipoComprobante.GrabaLibro
         dtpFecha.Value = .Fecha

         cboFormaPago.SelectedValue = .FormaPago.IdFormasPago

         If .FormaPago.Dias = 0 Then
            chbFormaDePago.Enabled = True
         Else
            chbFormaDePago.Enabled = False
         End If

         cmbCategoria.SelectedValue = .IdCategoria
         _categoriaOriginal = cmbCategoria.Text
         cmbVendedor.SelectedValue = .Vendedor.IdEmpleado
         txtComisiones.Text = .ComisionVendedor.ToString()
         cmbCobrador.SelectedValue = .Cobrador.IdEmpleado
         txtReferenciaCtaCte.Text = If(.CuentaCorriente IsNot Nothing, .CuentaCorriente.Referencia, "")
         chbReferenciaCuentaCorriente.Enabled = .FormaPago.Dias <> 0

         If .ClienteVinculado IsNot Nothing Then
            bscCodigoClienteCtaCte.Text = .ClienteVinculado.CodigoCliente.ToString()
            bscCodigoClienteCtaCte.PresionarBoton()
         End If

         bscCodigoClienteCtaCte.Enabled = False
         bscClienteCtaCte.Enabled = False
         txtObservacion.Text = .Observacion.ToString()

         txtCUIT.Text = .Cuit
         cmbTipoDoc.SelectedValue = .TipoDocCliente
         txtNroDoc.Text = .NroDocCliente.ToString()

         If Not String.IsNullOrWhiteSpace(.Cuit) Then
            chbCUIT.Checked = False
            chbCUIT.Enabled = False
         ElseIf Not .CategoriaFiscal.SolicitaCUIT Then
            chbCUIT.Checked = False
            chbCUIT.Enabled = False
         End If
         If Not String.IsNullOrWhiteSpace(.TipoDocCliente) And .NroDocCliente > 0 Then
            chbTipoDocumento.Checked = False
            chbTipoDocumento.Enabled = False
         End If

         '# Historia Clínica
         tbcDatos.SelectedTab = tbpHistoriaClinica
         If Reglas.Publicos.FacturacionMuestraHistoriaClinica Then
            Dim rClientes = New Reglas.Clientes()
            If .IdPaciente.HasValue Then
               _codigoPacienteOriginal = rClientes.GetUno(.IdPaciente.Value).CodigoCliente
               bscCodigoPaciente.Text = _codigoPacienteOriginal.ToString()
               bscCodigoPaciente.PresionarBoton()
               _nombrePaciente = bscPaciente.Text
            End If
            If .IdDoctor.HasValue Then
               _codigoDoctorOriginal = rClientes.GetUno(.IdDoctor.Value).CodigoCliente
               bscCodigoDoctor.Text = _codigoDoctorOriginal.ToString()
               bscCodigoDoctor.PresionarBoton()
               _nombreDoctor = bscDoctor.Text
            End If
            If .FechaCirugia.HasValue Then
               dtpFechaCirugia.Value = .FechaCirugia.Value
               dtpFechaCirugia.Checked = True
            Else
               dtpFechaCirugia.Checked = False
            End If

            bscPaciente.Enabled = chbPaciente.Checked
            bscCodigoPaciente.Enabled = chbPaciente.Checked
            bscDoctor.Enabled = chbDoctor.Checked
            bscCodigoDoctor.Enabled = chbDoctor.Checked
            dtpFechaCirugia.Enabled = chbFechaCirugia.Checked
         End If
         tbcDatos.SelectedTab = tbpDatos
      End With
   End Sub

   Private Function ValidarDetalle() As Boolean

      With _entidad

         Dim totalCambios As Integer = 0

         '# Validaciones
         If chbFecha.Checked Then
            If dtpFecha.Value = .Fecha Then
               Throw New Exception("ATENCIÓN: No modificó la Fecha aunque activó la opción para cambiarla.")
            End If
         End If

         If chbFormaDePago.Checked Then
            If CInt(cboFormaPago.SelectedValue) = .FormaPago.IdFormasPago Then
               Throw New Exception("ATENCIÓN: No modificó el valor de Forma de Pago aunque activó la opción para cambiarlo.")
            End If
            If .FormaPago.Dias = 0 AndAlso cboFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).Dias > 0 AndAlso (.ImporteTarjetas > 0 Or .ImporteCheques > 0) Then
               Throw New Exception("ATENCIÓN: No es posible editar forma pago, ya que contiene pagos con Tarjetas/Cheques")
            End If
            '-- REQ-43086.- -------------------------------------------------------------------------------------------------
            If .FormaPago.RequierePesos = cboFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).RequierePesos AndAlso
                  .FormaPago.RequiereDolares = cboFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).RequiereDolares AndAlso
                  .FormaPago.RequiereCheques = cboFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).RequiereCheques AndAlso
                  .FormaPago.RequiereTransferencia = cboFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).RequiereTransferencia Then
            Else
               If .FormaPago.Dias = 0 AndAlso cboFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).Dias = 0 Then
                  Throw New Exception("ATENCIÓN: No es posible Cambiar la forma de Pago ya que el comprobante no involucra un medio de pago asociada a la nueva forma de pago seleccionada.")
               End If
            End If
            '----------------------------------------------------------------------------------------------------------------
         End If

         If chbCategoria.Checked Then
            If CInt(cmbCategoria.SelectedValue) = .IdCategoria Then
               Throw New Exception("ATENCIÓN: No modificó el valor de Categoria aunque activó la opción para cambiarlo.")
            End If
         End If

         If chbVendedor.Checked Then
            If CInt(cmbVendedor.SelectedValue) = .Vendedor.IdEmpleado Then
               Throw New Exception("ATENCIÓN: No modificó el Vendedor del comprobante aunque activó la opción para cambiarlo.")
            End If
         End If

         If chbComisionVendedor.Checked Then
            If CDec(txtComisiones.Text) = .ComisionVendedor Then
               Throw New Exception("ATENCIÓN: No modificó la Comisión del Vendedor aunque activó la opción para cambiarla.")
            End If
         End If

         If chbCobrador.Checked Then
            If CInt(cmbCobrador.SelectedValue) = .Cobrador.IdEmpleado Then
               Throw New Exception("ATENCIÓN: No modificó el Cobrador del comprobante aunque activó la opción para cambiarlo.")
            End If
         End If

         If chbReferenciaCuentaCorriente.Checked Then
            If txtReferenciaCtaCte.Text = .CuentaCorriente.Referencia Then
               Throw New Exception("ATENCIÓN: No modificó el valor de Referencia del comprobante aunque activó la opción para cambiarlo.")
            End If
         End If

         If chbClienteCtaCte.Checked Then
            If chbClienteCtaCte.Checked AndAlso (Not bscCodigoClienteCtaCte.Selecciono OrElse Not bscClienteCtaCte.Selecciono) AndAlso Not _quitarClienteVinculado Then
               Throw New Exception("ATENCIÓN: No modificó el Cliente Vinculado del comprobante aunque activó la opción para cambiarlo.")
            End If
         End If

         If chbClienteCtaCte.Checked AndAlso Me.bscCodigoClienteCtaCte.Selecciono AndAlso bscClienteCtaCte.Selecciono Then
            If .CuentaCorriente IsNot Nothing AndAlso Not _quitarClienteVinculado Then
               If Long.Parse(bscCodigoClienteCtaCte.Tag.ToString()) = .CuentaCorriente.IdClienteCtaCte Then
                  Throw New Exception("ATENCIÓN: No modificó el Cliente Vinculado del comprobante aunque activó la opción para cambiarlo.")
               End If
            End If
         End If

         If chbObservacion.Checked Then
            If txtObservacion.Text = .Observacion Then
               Throw New Exception("ATENCIÓN: No modificó la Observación del comprobante aunque activó la opción para cambiarla.")
            End If
         End If

         If chbCUIT.Checked Then
            If txtCUIT.Text = .Observacion Then
               Throw New Exception("ATENCIÓN: No modificó el CUIT del comprobante aunque activó la opción para cambiarla.")
            End If
         End If
         If chbTipoDocumento.Checked Then
            If cmbTipoDoc.ValorSeleccionado(Of String) = .TipoDocCliente AndAlso txtNroDoc.ValorNumericoPorDefecto(0L) = .NroDocCliente Then
               Throw New Exception("ATENCIÓN: No modificó el Tipo/Nro de Documento del comprobante aunque activó la opción para cambiarla.")
            End If
         End If

         If chbPaciente.Checked Then
            If chbPaciente.Checked AndAlso (Not bscCodigoPaciente.Selecciono OrElse Not bscPaciente.Selecciono) AndAlso Not _quitarPaciente Then
               Throw New Exception("ATENCIÓN: No modificó el Paciente del comprobante aunque activó la opción para cambiarlo.")
            End If
         End If

         If chbPaciente.Checked AndAlso bscCodigoPaciente.Selecciono AndAlso bscPaciente.Selecciono Then
            If Not _quitarPaciente Then
               If Long.Parse(bscCodigoPaciente.Tag.ToString()) = .IdPaciente Then
                  Throw New Exception("ATENCIÓN: No modificó el Paciente del comprobante aunque activó la opción para cambiarlo.")
               End If
            End If
         End If

         If chbDoctor.Checked Then
            If chbDoctor.Checked AndAlso (Not bscCodigoDoctor.Selecciono OrElse Not bscDoctor.Selecciono) AndAlso Not _quitarDoctor Then
               Throw New Exception("ATENCIÓN: No modificó el Doctor del comprobante aunque activó la opción para cambiarlo.")
            End If
         End If

         If chbDoctor.Checked AndAlso bscCodigoDoctor.Selecciono AndAlso bscDoctor.Selecciono Then
            If Not _quitarDoctor Then
               If Long.Parse(Me.bscCodigoDoctor.Tag.ToString()) = .IdDoctor Then
                  Throw New Exception("ATENCIÓN: No modificó el Doctor del comprobante aunque activó la opción para cambiarlo.")
               End If
            End If
         End If

         If chbFechaCirugia.Checked AndAlso
            dtpFechaCirugia.Checked AndAlso
            dtpFechaCirugia.Value = .FechaCirugia Then
            Throw New Exception("ATENCIÓN: No modificó la fecha de cirugía comprobante aunque activó la opción para cambiarlo.")
         End If

         '# Se le solicita confirmación al usuario por cada cambio que haya realizado
         If chbFecha.Checked Then
            If ShowPregunta(String.Format("Está por cambiar la fecha del comprobante de {1} a {2}. ¿Desea continuar?", Environment.NewLine,
                                          .Fecha, dtpFecha.Value)) = Windows.Forms.DialogResult.No Then Return False
            '# Si llego hasta acá, quiere decir que cambió la forma de pago del comprobante
            totalCambios += 1
         End If

         If chbFormaDePago.Checked Then
            If ShowPregunta(String.Format("Está por cambiar la forma de pago del comprobante de {1} a {2}. ¿Desea continuar?", Environment.NewLine,
                                          .FormaPago.DescripcionFormasPago, cboFormaPago.Text)) = Windows.Forms.DialogResult.No Then Return False
            '# Si llego hasta acá, quiere decir que cambió la forma de pago del comprobante
            _cambioFormaDePago = True
            totalCambios += 1
         End If
         If chbCategoria.Checked Then
            If ShowPregunta(String.Format("Está por cambiar la categoría del comprobante de {1} a {2}. ¿Desea continuar?", Environment.NewLine,
                                             _categoriaOriginal, cmbCategoria.Text)) = Windows.Forms.DialogResult.No Then Return False
            totalCambios += 1
         End If
         If chbVendedor.Checked Then
            If ShowPregunta(String.Format("Está por cambiar el vendedor comprobante de {1} a {2}. ¿Desea continuar?", Environment.NewLine,
                                          .Vendedor.NombreEmpleado, cmbVendedor.Text)) = Windows.Forms.DialogResult.No Then Return False
            totalCambios += 1
         End If
         If chbComisionVendedor.Checked Then
            If ShowPregunta(String.Format("Está por cambiar la comisión del vendedor de {1} a {2}. ¿Desea continuar?", Environment.NewLine,
                                          .ComisionVendedor, txtComisiones.Text)) = Windows.Forms.DialogResult.No Then Return False
            '# Si llego hasta acá, quiere decir que cambió la comisión del vendedor
            _modificaComision = True
            totalCambios += 1
         End If
         If chbCobrador.Checked Then
            If ShowPregunta(String.Format("Está por cambiar el Cobrador del comprobante de {1} a {2}. ¿Desea continuar?", Environment.NewLine,
                                          .Cobrador.NombreEmpleado, cmbCobrador.Text)) = Windows.Forms.DialogResult.No Then Return False
            totalCambios += 1
         End If
         If chbReferenciaCuentaCorriente.Checked Then
            If ShowPregunta(String.Format("Está por cambiar el valor de referencia del comprobante de {1} a {2}. ¿Desea continuar?", Environment.NewLine,
                                          .CuentaCorriente.Referencia, txtReferenciaCtaCte.Text)) = Windows.Forms.DialogResult.No Then Return False
            totalCambios += 1
         End If
         If chbClienteCtaCte.Checked Then
            Dim mensaje As String
            If bscCodigoClienteCtaCte.Selecciono AndAlso bscClienteCtaCte.Selecciono AndAlso _quitarClienteVinculado Then
               mensaje = String.Format("Esta por quitar el cliente vinculado {0} del comprobante. ¿Desea continuar?", _nombreClienteVinculado)
            Else
               mensaje = If(.CuentaCorriente IsNot Nothing AndAlso .ClienteVinculado IsNot Nothing,
                            String.Format("Está por cambiar el cliente vinculado del comprobante de {1} a {2}. ¿Desea continuar?", Environment.NewLine, .ClienteVinculado.NombreCliente, bscClienteCtaCte.Text),
                            String.Format("Está por agregar un cliente vinculado al comprobante ({1}). ¿Desea continuar?", Environment.NewLine, bscClienteCtaCte.Text))
            End If
            If ShowPregunta(mensaje) = Windows.Forms.DialogResult.No Then Return False
            totalCambios += 1
         End If
         If chbObservacion.Checked Then
            If ShowPregunta(String.Format("Está por cambiar la observación del comprobante de {1} a {2}. ¿Desea continuar?", Environment.NewLine,
                                          .Observacion, txtObservacion.Text)) = Windows.Forms.DialogResult.No Then Return False
            totalCambios += 1
         End If
         If chbCUIT.Checked Then
            If ShowPregunta(String.Format("Está por cambiar el CUIT del comprobante de {1} a {2}. ¿Desea continuar?", Environment.NewLine,
                                          .Cuit, txtCUIT.Text)) = Windows.Forms.DialogResult.No Then Return False
            Dim result As Reglas.Validaciones.ValidacionResult
            result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() With {
                                                                                          .IdFiscal = txtCUIT.Text,
                                                                                          .SolicitaCUIT = _entidad.CategoriaFiscal.SolicitaCUIT})
            If result.Error Then
               ShowMessage(result.MensajeError)
               txtCUIT.Focus()
               Return False
            End If
            totalCambios += 1
         End If
         If chbTipoDocumento.Checked Then
            If ShowPregunta(String.Format("Está por cambiar el Tipo/Nro de Documento del comprobante de {1}/{3} a {2}/{4}. ¿Desea continuar?", Environment.NewLine,
                                          .TipoDocCliente, cmbTipoDoc.Text, .NroDocCliente, txtNroDoc.Text)) = Windows.Forms.DialogResult.No Then Return False
            totalCambios += 1
         End If
         If chbPaciente.Checked Then
            Dim mensaje As String
            If bscCodigoPaciente.Selecciono AndAlso Me.bscPaciente.Selecciono AndAlso _quitarPaciente Then
               mensaje = String.Format("Esta por quitar el paciente {0} del comprobante. ¿Desea continuar?", _nombrePaciente)
            Else
               mensaje = If(.IdPaciente IsNot Nothing,
                            String.Format("Está por cambiar el paciente del comprobante de {1} a {2}. ¿Desea continuar?", Environment.NewLine, _nombrePaciente, bscPaciente.Text),
                            String.Format("Está por agregar un paciente al comprobante ({1}). ¿Desea continuar?", Environment.NewLine, bscPaciente.Text))
            End If
            If ShowPregunta(mensaje) = Windows.Forms.DialogResult.No Then Return False
            totalCambios += 1
         End If
         If chbDoctor.Checked Then
            Dim mensaje As String
            If bscCodigoDoctor.Selecciono AndAlso Me.bscDoctor.Selecciono AndAlso _quitarDoctor Then
               mensaje = String.Format("Esta por quitar el Doctor {0} del comprobante. ¿Desea continuar?", _nombreDoctor)
            Else
               mensaje = If(.IdDoctor IsNot Nothing,
                            String.Format("Está por cambiar el Doctor del comprobante de {1} a {2}. ¿Desea continuar?", Environment.NewLine, _nombreDoctor, bscDoctor.Text),
                            String.Format("Está por agregar un Doctor al comprobante ({1}). ¿Desea continuar?", Environment.NewLine, bscDoctor.Text))
            End If
            If ShowPregunta(mensaje) = Windows.Forms.DialogResult.No Then Return False
            totalCambios += 1
         End If
         If Me.chbFechaCirugia.Checked Then
            Dim mensaje As String
            If .FechaCirugia IsNot Nothing Then
               If dtpFechaCirugia.Checked Then
                  mensaje = String.Format("Está por cambiar la fecha de cirugía del comprobante de {1} a {2}. ¿Desea continuar?", Environment.NewLine,
                                          .FechaCirugia,
                                          dtpFechaCirugia.Value)
               Else
                  mensaje = String.Format("Está por quitar la fecha de cirugía ({1}) del comprobante. ¿Desea continuar?", Environment.NewLine,
                                          .FechaCirugia)
               End If
            Else
               If dtpFechaCirugia.Checked Then
                  mensaje = String.Format("Está por agregar una fecha de cirugía al comprobante ({1}). ¿Desea continuar?", Environment.NewLine,
                                          dtpFechaCirugia.Value)
               Else
                  Throw New Exception("ATENCIÓN: No modificó la fecha de cirugía comprobante aunque activó la opción para cambiarlo.")
               End If
            End If
            If ShowPregunta(mensaje) = Windows.Forms.DialogResult.No Then Return False
            totalCambios += 1
         End If

         If totalCambios = 0 Then
            Throw New Exception("No se han realizado cambios en el comprobante.")
         End If

      End With

      Return True
   End Function

   Private Sub GrabarCambios()

      Dim rVentas = New Reglas.Ventas()
      Dim eVenta = rVentas.GetUna(actual.Sucursal.Id,
                                  _entidad.TipoComprobante.IdTipoComprobante, _entidad.LetraComprobante,
                                  _entidad.CentroEmisor, _entidad.NumeroComprobante)
      With eVenta

         '# Actualizo los datos a modificar
         If chbFecha.Checked Then
            .Fecha = dtpFecha.Value
         End If
         If chbFormaDePago.Checked Then
            .FormaPago = cboFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago)
         End If
         If chbCategoria.Checked Then
            .IdCategoria = cmbCategoria.ValorSeleccionado(Of Integer)
         End If
         If chbVendedor.Checked Then
            .Vendedor.IdEmpleado = cmbVendedor.ValorSeleccionado(Of Integer)
         End If
         If chbCobrador.Checked Then
            .Cobrador.IdEmpleado = cmbCobrador.ValorSeleccionado(Of Integer)
         End If
         If chbComisionVendedor.Checked Then
            .ComisionVendedor = txtComisiones.ValorNumericoPorDefecto(0D)
         End If
         If chbReferenciaCuentaCorriente.Checked Then
            .CuentaCorriente.Referencia = txtReferenciaCtaCte.Text
         End If
         If chbClienteCtaCte.Checked Then
            If .CuentaCorriente IsNot Nothing Then
               .CuentaCorriente.IdClienteCtaCte = If(Not _quitarClienteVinculado, Long.Parse(Me.bscCodigoClienteCtaCte.Tag.ToString()), .IdCliente)
            End If
         End If
         If chbObservacion.Checked Then
            .Observacion = txtObservacion.Text
         End If

         If chbCUIT.Checked Then
            .Cuit = txtCUIT.Text
         End If
         If chbTipoDocumento.Checked Then
            .TipoDocCliente = cmbTipoDoc.ValorSeleccionado(Of String)
            .NroDocCliente = txtNroDoc.ValorNumericoPorDefecto(0L)
         End If

         '# Historia Clínica
         If chbPaciente.Checked Then
            .IdPaciente = If(Not _quitarPaciente, Long.Parse(bscCodigoPaciente.Tag.ToString()), Nothing)
         End If
         If chbDoctor.Checked Then
            .IdDoctor = If(Not _quitarDoctor, Long.Parse(bscCodigoDoctor.Tag.ToString()), Nothing)
         End If
         If chbFechaCirugia.Checked Then
            If dtpFechaCirugia.Checked Then
               .FechaCirugia = dtpFechaCirugia.Value
            Else
               .FechaCirugia = Nothing
            End If
         End If

         rVentas.ActualizaVenta(eVenta, _modificaComision, _cambioFormaDePago, IdFuncion, (_entidad.Fecha <> .Fecha))

      End With

      ShowMessage("Cambios grabados EXITOSAMENTE !!!")
      Close(DialogResult.OK)
   End Sub

#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(
      Sub()
         If ValidarDetalle() Then
            GrabarCambios()
         End If
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub
#End Region

#Region "Eventos Buscador Clientes"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, False, False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      End Sub)
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta, bscCodigoCliente, bscCliente))
   End Sub
#End Region

#Region "Eventos Buscador Clientes Vinculado (Cta. Cte.)"
   Private Sub bscCodigoClienteCtaCte_BuscadorClick() Handles bscCodigoClienteCtaCte.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoClienteCtaCte)
         Dim codigoCliente = bscCodigoClienteCtaCte.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoClienteCtaCte.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, False, False)
      End Sub)
   End Sub
   Private Sub bscClienteCtaCte_BuscadorClick() Handles bscClienteCtaCte.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscClienteCtaCte)
         bscClienteCtaCte.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscClienteCtaCte.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCodigoClienteCtaCte_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoClienteCtaCte.BuscadorSeleccion, bscClienteCtaCte.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta, bscCodigoCliente, bscCliente, Sub(dr) _quitarClienteVinculado = False))
   End Sub
#End Region

#Region "Eventos Buscador Paciente"
   Private Sub bscCodigoPaciente_BuscadorClick() Handles bscCodigoPaciente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoPaciente)
         Dim codigoPaciente = bscCodigoPaciente.Text.ValorNumericoPorDefecto(-1L)

         '# Valido que esté configurado la categoria para los Pacientes
         If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaPaciente) Then
            ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Pacientes. Debe configurarla para poder continuar.")
            Exit Sub
         End If

         bscCodigoPaciente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoPaciente, True, True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaPaciente))
      End Sub)
   End Sub
   Private Sub bscPaciente_BuscadorClick() Handles bscPaciente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscPaciente)

         '# Valido que esté configurado la categoria para los Pacientes
         If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaPaciente) Then
            ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Pacientes. Debe configurarla para poder continuar.")
            Exit Sub
         End If

         bscPaciente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscPaciente.Text.Trim(), True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaPaciente))
      End Sub)
   End Sub
   Private Sub bscCodigoPaciente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoPaciente.BuscadorSeleccion, bscPaciente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta, bscCodigoPaciente, bscPaciente, Sub(dr) _quitarPaciente = False))
   End Sub
#End Region

#Region "Eventos Buscador Doctor"
   Private Sub bscCodigoDoctor_BuscadorClick() Handles bscCodigoDoctor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoDoctor)
         Dim codigoDoctor = bscCodigoDoctor.Text.ValorNumericoPorDefecto(-1L)

         '# Valido que esté configurado la categoria para los Doctores
         If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaDoctor) Then
            ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Doctores. Debe configurarla para poder continuar.")
            Exit Sub
         End If

         bscCodigoDoctor.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoDoctor, True, True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaDoctor))
      End Sub)

   End Sub
   Private Sub bscDoctor_BuscadorClick() Handles bscDoctor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscDoctor)

         '# Valido que esté configurado la categoria para los Doctores
         If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaDoctor) Then
            ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Doctores. Debe configurarla para poder continuar.")
            Exit Sub
         End If

         bscDoctor.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscDoctor.Text.Trim(), True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaDoctor))
      End Sub)
   End Sub
   Private Sub bscCodigoDoctor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoDoctor.BuscadorSeleccion, bscDoctor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta, bscCodigoDoctor, bscDoctor, Sub(dr) _quitarDoctor = False))
   End Sub
#End Region

   Private Sub chbFormaDePago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaDePago.CheckedChanged
      TryCatched(
      Sub()
         cboFormaPago.Enabled = chbFormaDePago.Checked
         If Not chbFormaDePago.Checked Then
            cboFormaPago.SelectedValue = _entidad.FormaPago.IdFormasPago
         End If
      End Sub)
   End Sub
   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      TryCatched(
      Sub()
         cmbCategoria.Enabled = chbCategoria.Checked
         If Not chbCategoria.Checked Then
            cmbCategoria.SelectedValue = _entidad.IdCategoria
         End If
      End Sub)
   End Sub
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(
      Sub()
         cmbVendedor.Enabled = chbVendedor.Checked
         If Not chbVendedor.Checked Then
            cmbVendedor.SelectedValue = _entidad.Vendedor.IdEmpleado
         End If
      End Sub)
   End Sub
   Private Sub chbCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbCobrador.CheckedChanged
      TryCatched(
      Sub()
         cmbCobrador.Enabled = chbCobrador.Checked
         If Not chbCobrador.Checked Then
            cmbCobrador.SelectedValue = _entidad.Cobrador.IdEmpleado
         End If
      End Sub)
   End Sub
   Private Sub chbReferenciaCuentaCorriente_CheckedChanged(sender As Object, e As EventArgs) Handles chbReferenciaCuentaCorriente.CheckedChanged
      TryCatched(
      Sub()
         txtReferenciaCtaCte.Enabled = chbReferenciaCuentaCorriente.Checked
         If Not chbReferenciaCuentaCorriente.Checked Then
            If _entidad.CuentaCorriente IsNot Nothing Then
               txtReferenciaCtaCte.Text = _entidad.CuentaCorriente.Referencia
            Else
               txtReferenciaCtaCte.Text = String.Empty
            End If
         End If
      End Sub)
   End Sub
   Private Sub chbClienteCtaCte_CheckedChanged(sender As Object, e As EventArgs) Handles chbClienteCtaCte.CheckedChanged
      TryCatched(
      Sub()
         If Not chbClienteCtaCte.Checked Then
            If _entidad.CuentaCorriente.Cliente IsNot Nothing AndAlso
               _entidad.ClienteVinculado IsNot Nothing Then
               bscCodigoClienteCtaCte.Enabled = True
               bscCodigoClienteCtaCte.Text = _entidad.ClienteVinculado.CodigoCliente.ToString()
               bscCodigoClienteCtaCte.PresionarBoton()
            Else
               bscCodigoClienteCtaCte.Text = ""
               bscClienteCtaCte.Text = ""
            End If
         Else
            bscClienteCtaCte.Permitido = True
            bscCodigoClienteCtaCte.Permitido = True
         End If
         bscCodigoClienteCtaCte.Enabled = chbClienteCtaCte.Checked
         bscClienteCtaCte.Enabled = chbClienteCtaCte.Checked
      End Sub)
   End Sub
   Private Sub chbObservacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbObservacion.CheckedChanged
      TryCatched(
      Sub()
         txtObservacion.Enabled = chbObservacion.Checked
         If Not chbObservacion.Checked Then
            txtObservacion.Text = _entidad.Observacion
         End If
      End Sub)
   End Sub
   Private Sub chbComisionVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbComisionVendedor.CheckedChanged
      TryCatched(
      Sub()
         txtComisiones.Enabled = chbComisionVendedor.Checked
         If Not chbComisionVendedor.Checked Then
            txtComisiones.Text = _entidad.ComisionVendedor.ToString()
         End If
      End Sub)
   End Sub
   Private Sub chbPaciente_CheckedChanged(sender As Object, e As EventArgs) Handles chbPaciente.CheckedChanged
      TryCatched(
      Sub()
         If Not chbPaciente.Checked Then
            bscCodigoPaciente.Text = If(_codigoPacienteOriginal <> 0, _codigoPacienteOriginal.ToString(), String.Empty)
            If Not String.IsNullOrEmpty(bscCodigoPaciente.Text) Then
               bscCodigoPaciente.PresionarBoton()
            End If
         End If
         bscCodigoPaciente.Enabled = chbPaciente.Checked
         bscPaciente.Enabled = chbPaciente.Checked
      End Sub)
   End Sub
   Private Sub chbDoctor_CheckedChanged(sender As Object, e As EventArgs) Handles chbDoctor.CheckedChanged
      TryCatched(
      Sub()
         If Not chbDoctor.Checked Then
            bscCodigoDoctor.Text = If(_codigoDoctorOriginal <> 0, _codigoDoctorOriginal.ToString(), String.Empty)
            If Not String.IsNullOrEmpty(bscCodigoDoctor.Text) Then
               bscCodigoDoctor.PresionarBoton()
            End If
         End If
         bscCodigoDoctor.Enabled = chbDoctor.Checked
         bscDoctor.Enabled = chbDoctor.Checked
      End Sub)
   End Sub
   Private Sub chbFechaCirugia_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaCirugia.CheckedChanged
      TryCatched(
      Sub()
         If Not chbFechaCirugia.Checked Then
            If _entidad.FechaCirugia.HasValue Then
               dtpFechaCirugia.Value = _entidad.FechaCirugia.Value
            Else
               dtpFechaCirugia.Checked = False '# Si el check está en false, indica que su valor es nulo
            End If
         Else
            dtpFechaCirugia.Checked = True '# Si el check está en false, indica que su valor es nulo
         End If
         dtpFechaCirugia.Enabled = chbFechaCirugia.Checked
      End Sub)
   End Sub
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(
      Sub()
         dtpFecha.Enabled = chbFecha.Checked
         If Not chbFecha.Checked Then
            dtpFecha.Value = _entidad.Fecha
         End If
      End Sub)
   End Sub
   Private Sub chbCUIT_CheckedChanged(sender As Object, e As EventArgs) Handles chbCUIT.CheckedChanged
      TryCatched(
      Sub()
         txtCUIT.Enabled = chbCUIT.Checked
         If Not chbCUIT.Checked Then
            txtCUIT.Text = _entidad.Cuit
         End If
      End Sub)
   End Sub
   Private Sub chbTipoDocumento_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoDocumento.CheckedChanged
      TryCatched(
      Sub()
         cmbTipoDoc.Enabled = chbTipoDocumento.Checked
         txtNroDoc.Enabled = chbTipoDocumento.Checked
         If Not chbTipoDocumento.Checked Then
            cmbTipoDoc.SelectedValue = _entidad.TipoDocCliente
            txtNroDoc.Text = _entidad.NroDocCliente.ToString()
         End If
      End Sub)
   End Sub
   Private Sub btnQuitarPaciente_Click(sender As Object, e As EventArgs) Handles btnQuitarPaciente.Click
      TryCatched(
      Sub()
         If chbPaciente.Checked Then
            If bscCodigoPaciente.Selecciono OrElse bscPaciente.Selecciono Then
               bscPaciente.Text = String.Empty
               bscCodigoPaciente.Text = String.Empty
               bscPaciente.Selecciono = True
               bscCodigoPaciente.Selecciono = True
               _quitarPaciente = True
            End If
         End If
      End Sub)
   End Sub
   Private Sub btnQuitarDoctor_Click(sender As Object, e As EventArgs) Handles btnQuitarDoctor.Click
      TryCatched(
      Sub()
         If chbDoctor.Checked Then
            If bscCodigoDoctor.Selecciono OrElse bscDoctor.Selecciono Then
               bscDoctor.Text = String.Empty
               bscCodigoDoctor.Text = String.Empty
               bscDoctor.Selecciono = True
               bscCodigoDoctor.Selecciono = True
               _quitarDoctor = True
            End If
         End If
      End Sub)
   End Sub
   Private Sub btnQuitarClienteVinculado_Click(sender As Object, e As EventArgs) Handles btnQuitarClienteVinculado.Click
      TryCatched(
      Sub()
         If chbClienteCtaCte.Checked Then
            If bscCodigoClienteCtaCte.Selecciono OrElse bscClienteCtaCte.Selecciono Then
               bscCodigoClienteCtaCte.Text = String.Empty
               bscClienteCtaCte.Text = String.Empty
               bscCodigoClienteCtaCte.Selecciono = True
               bscClienteCtaCte.Selecciono = True
               _quitarClienteVinculado = True
            End If
         End If
      End Sub)
   End Sub


#End Region

End Class