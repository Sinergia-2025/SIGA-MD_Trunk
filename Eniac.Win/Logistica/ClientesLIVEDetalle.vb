Public Class ClientesLIVEDetalle
   Protected Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

#Region "Campos"

   Private _publico As Publicos
   Private _publicos As Eniac.Win.Publicos
   Private _cargandoPantalla As Boolean = True
   Private _actividades As DataTable
   Private _idProvinciaCliente As String
   Private _idProvinciaSucursal As String
   Private _soloProvinciasClienteEmpresa As Boolean = True
   Private _ExistFactBlanco As Boolean = False
   Private _DireccionCorregida As Boolean
   Private _codigoActualCliente As String = String.Empty
   Private _cuitActualCliente As String = String.Empty
#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.Cliente)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
   Public Sub New(entidad As Entidades.Cliente, validarDireccion As Boolean)
      Me.InitializeComponent()
      Me._entidad = entidad
      _DireccionCorregida = validarDireccion
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try

         Dim idCatFiscal = DirectCast(_entidad, Entidades.Cliente).CategoriaFiscal.IdCategoriaFiscal

         _publico = New Publicos()
         _publicos = New Publicos()

         _idProvinciaSucursal = actual.Sucursal.LocalidadComercial.IdProvincia

         'tab Datos Personales
         _publico.CargaComboTipoDocumento(Me.cmbTipoDoc, Entidades.Publicos.SiNoTodos.SI)
         _publico.CargaComboTipoClientes(Me.cmbTipoCliente)
         _publico.CargaComboCategorias(Me.cmbCategoria)
         _publico.CargaComboCategoriasFiscales(Me.cmbCategoriaFiscal)
         _publicos.CargaComboZonasGeograficas(cmbZonaGeografica)

         'tab Ubicacion
         '_publico.CargaComboLocalidades(Me.cmbLocalidades)
         '_publico.CargaComboLocalidades(Me.cmbLocalidades2)

         _publicos.CargaComboEstadosCiviles(cmbEstadosCiviles)

         'tab Condiciones de Venta
         _publico.CargaComboListaDePrecios(Me.cmbListaDePrecios)
         _publico.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         _publico.CargaComboEstadosClientes(Me.cmbEstado)
         _publico.CargaComboMarcas(Me.cmbMarcas)
         _publico.CargaComboRubros(Me.cmbRubros)

         Dim blnMiraUsuario As Boolean = False  'Se bien deberia controlarlo a la hora de factura no lo tiene cargado asi que no lograria hacerle un comprobante.
         Dim blnMiraPC As Boolean = False
         Dim blnCajasModificables As Boolean = False
         Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, blnMiraUsuario, blnMiraPC, blnCajasModificables)

         'tab Visitas
         _publico.CargaComboEmpleados(Me.cmbVendedor, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)
         _publico.CargaComboEmpleados(Me.cmbDadoAltaPor, Eniac.Entidades.Publicos.TiposEmpleados.TODOS)
         _publico.CargaComboTransportistas(Me.cmbTransportistas, True)
         _publico.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS", , , , True)

         cmbProvincia.DisplayMember = "NombreProvincia"
         cmbProvincia.ValueMember = "IdProvincia"
         cmbProvincia.DataSource = New Eniac.Reglas.Provincias().GetAll()
         cmbProvincia.Text = New Eniac.Reglas.Localidades().GetUna(Publicos.LocalidadEmpresa).NombreProvincia.ToString()
         _publicos.CargaComboTiposDeExension(Me.cmbTiposDeExension)

         If DirectCast(_entidad, Entidades.Cliente).IdClienteCtaCte <> 0 Then
            chkClienteCtaCte.Checked = True
         Else
            chkClienteCtaCte.Checked = False
         End If

         _liSources.Add("TipoCliente", DirectCast(Me._entidad, Entidades.Cliente).TipoCliente)
         '  Me._liSources.Add("Categoria", DirectCast(Me._entidad, Entidades.Cliente).Categoria)
         _liSources.Add("CategoriaFiscal", DirectCast(Me._entidad, Entidades.Cliente).CategoriaFiscal)
         ' Me._liSources.Add("TipoDocCliente", DirectCast(Me._entidad, Entidades.Cliente).TipoDocCliente)
         _liSources.Add("Calle", DirectCast(Me._entidad, Entidades.Cliente).Calle)
         _liSources.Add("Calle2", DirectCast(Me._entidad, Entidades.Cliente).Calle2)
         _liSources.Add("LocalidadCalle", DirectCast(Me._entidad, Entidades.Cliente).Calle.Localidad)
         _liSources.Add("LocalidadCalle2", DirectCast(Me._entidad, Entidades.Cliente).Calle2.Localidad)
         _liSources.Add("EstadoCliente", DirectCast(Me._entidad, Entidades.Cliente).EstadoCliente)
         '    Me._liSources.Add("FormaPago", DirectCast(Me._entidad, Entidades.Cliente).FormaPago)
         '   Me._liSources.Add("ListaDePrecios", DirectCast(Me._entidad, Entidades.Cliente).ListaDePrecios)
         ' Me._liSources.Add("Transportista", DirectCast(Me._entidad, Entidades.Cliente).Transportista)
         _liSources.Add("Vendedor", DirectCast(Me._entidad, Entidades.Cliente).Vendedor)
         _liSources.Add("DadoAltaPor", DirectCast(Me._entidad, Entidades.Cliente).DadoAltaPor)
         '  Me._liSources.Add("ClienteCtaCte", DirectCast(Me._entidad, Entidades.Cliente).ClienteCtaCte)
         'Me._liSources.Add("TipoDocClienteClienteCtaCte", DirectCast(Me._entidad, Entidades.Cliente).ClienteCtaCte.TipoDocCliente)
         _liSources.Add("ZonaGeografica", DirectCast(Me._entidad, Entidades.Cliente).ZonaGeografica)

         _publicos.CargaComboDesdeEnum(CmbAlicuota2deProducto, GetType(Entidades.Cliente.Alicuota2DeProductoSegun))

         BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Eniac.Win.StateForm.Actualizar Then

            Me.chbNumeroAutomatico.Visible = False
            Me.lblNumeroAutomatico.Visible = False

            txtNivelAutorizacion.Visible = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "Clientes-NivelAutorizacion")
            txtNivelAutorizacion.LabelAsoc.Visible = txtNivelAutorizacion.Visible

            Me.cmbCategoriaFiscal.SelectedValue = idCatFiscal
            '-----------------------

            'Me.CmbAlicuota2deProducto.SelectedText = DirectCast(Me._entidad, Entidades.Cliente).Alicuota2deProducto

            _publico.CargaComboVendedoresDelCliente(Me.cmbVendedor, DirectCast(Me._entidad, Entidades.Cliente).IdCliente)

            If Me.cmbVendedor.Items.Count = 0 Then
               _publico.CargaComboEmpleados(Me.cmbVendedor, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)
            End If

            Me.CargarActividades()

            Me.txtCodigoCliente.Tag = DirectCast(Me._entidad, Entidades.Cliente).IdCliente

            Me.bscCodigoLocalidad.Text = DirectCast(Me._entidad, Entidades.Cliente).IdLocalidad.ToString()
            Me.bscCodigoLocalidad.PresionarBoton()

            Me.bscCodigoLocalidad2.Text = DirectCast(Me._entidad, Entidades.Cliente).Calle2.Localidad.IdLocalidad.ToString()
            Me.bscCodigoLocalidad2.PresionarBoton()

            Me.tbcCliente.SelectedTab = Me.tbpUbicacion
            Me.bscCalles.Text = DirectCast(Me._entidad, Entidades.Cliente).Calle.NombreCalle
            Me.bscCalles.Tag = DirectCast(Me._entidad, Entidades.Cliente).Calle.IdCalle
            Me.bscCalles.PresionarBoton()

            Me.bscCalles2.Text = DirectCast(Me._entidad, Entidades.Cliente).Calle2.NombreCalle
            Me.bscCalles2.Tag = DirectCast(Me._entidad, Entidades.Cliente).Calle2.IdCalle
            Me.bscCalles2.PresionarBoton()

            Me.tbcCliente.SelectedTab = Me.tbpVisitas

            Me.tbcCliente.SelectedTab = Me.tbpDatosPersonales

            Me.tbcCliente.SelectedTab = Me.tbpCondicDeVenta

            If DirectCast(Me._entidad, Entidades.Cliente).NroDocCliente <> 0 Then
               Me.chbTipoDocCliente.Checked = True
            End If

            'If DirectCast(Me._entidad, Entidades.Cliente).IdTransportista <> 0 Then
            '   Me.transenteCtaCte.Checked = True
            'End If



            If DirectCast(Me._entidad, Entidades.Cliente).IdClienteCtaCte <> 0 Then
               Dim ClienteCtaCte As Entidades.Cliente = New Reglas.Clientes(ModoClienteProspecto)._GetUno(DirectCast(Me._entidad, Entidades.Cliente).IdClienteCtaCte)
               Me.bscCodigoClienteCtaCte.Text = ClienteCtaCte.CodigoCliente.ToString()
               Me.bscNombreClienteCtaCte.Text = ClienteCtaCte.NombreCliente
            End If

            'If Me.cmbVendedor.SelectedIndex = -1 Then
            '   Me.cmbVendedor.SelectedIndex = 0
            'End If

            If DirectCast(Me._entidad, Entidades.Cliente).IdCaja > 0 Then
               Me.cmbCajas.SelectedItem = DirectCast(Me._entidad, Entidades.Cliente).IdCaja
            End If

            Me.chbCaja.Checked = Me.cmbCajas.SelectedIndex >= 0

            chbEsClienteGenerico.Enabled = Not New Reglas.Ventas().ClientePoseeFacturas(DirectCast(Me._entidad, Entidades.Cliente).IdCliente, grabaLibro:=Nothing)


            Dim rVenta As Reglas.Ventas = New Reglas.Ventas()
            'Verifico si tiene alguna venta el cliente en blanco
            _ExistFactBlanco = rVenta.ClientePoseeFacturas(DirectCast(Me._entidad, Entidades.Cliente).IdCliente)
            If _ExistFactBlanco And ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente Then

               'Verifico si el cuit es valido
               If Not String.IsNullOrWhiteSpace(txtCUIT.Text) AndAlso Publicos.EsCuitValido(txtCUIT.Text) Then
                  'Si es valido lo no permito que se cambie. Si es invalido lo dejo editar para subsanar el error
                  Me.txtCUIT.ReadOnly = True
               End If

               If IsNumeric(txtNroDoc.Text) AndAlso Long.Parse(Me.txtNroDoc.Text) <> 0 Then
                  'Si el número de documento es diferente de cero (0) no lo dejo modificar
                  cmbTipoDoc.Enabled = False
                  Me.txtNroDoc.ReadOnly = True
               Else
                  'Si el número de documento es cero (0) lo permito modificar
                  cmbTipoDoc.Enabled = True
                  Me.txtNroDoc.ReadOnly = False
               End If
            End If

            If Not _DireccionCorregida Then
               Me.txtDireccionCompleta.Text = DirectCast(Me._entidad, Entidades.Cliente).Direccion
               Me.lblDireccionCompleta.Visible = True
               Me.txtDireccionCompleta.Visible = True
            End If

            Me._codigoActualCliente = txtCodigoCliente.Text
            Me._cuitActualCliente = txtCUIT.Text

         Else

            Me.chbNumeroAutomatico.Checked = True

            _DireccionCorregida = True

            _publico.CargaComboEmpleados(Me.cmbVendedor, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)

            Me.ChequeaEstructuraActividades()

            Me.CargarProximoCodigo()

            Me.chbActivo.Checked = True


            Me.chbPublicarEnWeb.Checked = True

            Me.tbcCliente.SelectedTab = Me.tbpVisitas

            Me.chbHabilitarVisita.Checked = True
            Me.ChbRepartoIndep.Checked = False

            If Me.cmbDadoAltaPor.Items.Count = 1 Then
               Me.cmbDadoAltaPor.SelectedIndex = 0
            End If
            DirectCast(Me._entidad, Entidades.Cliente).DadoAltaPor = DirectCast(Me.cmbDadoAltaPor.SelectedItem, Eniac.Entidades.Empleado)

            If cmbVendedor.Items.Count = 1 Then
               cmbVendedor.SelectedIndex = 0
            Else
               cmbVendedor.SelectedIndex = -1
            End If
            DirectCast(Me._entidad, Entidades.Cliente).Vendedor = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado)

            If Me.cmbTransportistas.Items.Count = 1 Then
               Me.cmbTransportistas.SelectedIndex = 0
            End If
            '  DirectCast(Me._entidad, Entidades.Cliente).Transportista = DirectCast(Me.cmbTransportistas.SelectedItem, Eniac.Entidades.Transportista)

            Me.tbcCliente.SelectedTab = Me.tbpCondicDeVenta
            Me.tbcCliente.SelectedTab = Me.tbpUbicacion

            Me.chbVerEnConsultas.Checked = True

            'Me.cmbTipoDoc.SelectedValue = Eniac.Win.Publicos.TipoDocumentoCliente

            Me.dtpFechaAlta.Value = DateTime.Now

            Me.chbHabilitarVisita.Checked = True
            Me.txtCantidadVisitas.Text = "1"

            If cmbZonaGeografica.Items.Count = 1 Then
               cmbZonaGeografica.SelectedIndex = 0
            End If
            If cmbTipoCliente.Items.Count = 1 Then
               cmbTipoCliente.SelectedIndex = 0
            End If
            If cmbCategoria.Items.Count = 1 Then
               cmbCategoria.SelectedIndex = 0
            End If
            If cmbVendedor.Items.Count = 1 Then
               cmbVendedor.SelectedIndex = 0
            End If
            If cmbEstado.Items.Count = 1 Then
               cmbEstado.SelectedIndex = 0
            End If


         End If
         Me.bscCodigoCalles.Text = String.Empty
         Me.bscCodigoCalles2.Text = String.Empty

         Dim reg As Reglas.ClientesDescuentosMarcas
         reg = New Reglas.ClientesDescuentosMarcas()
         Me._descuentosMarcas = reg.GetClientesDescuentosMarcas(DirectCast(Me._entidad, Entidades.Cliente).IdCliente, False)
         Me._descuentosMarcas.TableName = "DescuentosMarcas"
         Me.dgvDescuentosMarcas.DataSource = Me._descuentosMarcas

         Dim reg1 As Reglas.ClientesDescuentosRubros
         reg1 = New Reglas.ClientesDescuentosRubros()
         Me._descuentosRubros = reg1.GetClientesDescuentosRubros(DirectCast(Me._entidad, Entidades.Cliente).IdCliente, False)
         Me._descuentosRubros.TableName = "DescuentosRubros"
         Me.dgvDescuentosRubros.DataSource = Me._descuentosRubros

         Dim reg2 As Reglas.ClientesDescuentosProductos
         reg2 = New Reglas.ClientesDescuentosProductos()
         Me._descuentosProducto = reg2.GetClientesDescuentosProductos(DirectCast(Me._entidad, Entidades.Cliente).IdCliente, False)
         Me._descuentosProducto.TableName = "DescuentosProductos"
         Me.dgvDescuentosProductos.DataSource = Me._descuentosProducto

         Me.tbcCliente.SelectedTab = Me.tbpDatosPersonales

         CmbAlicuota2deProducto.Enabled = Reglas.Publicos.ProductoUtilizaAlicuota2


         Me._cargandoPantalla = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Clientes()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Dim vacio As String = ""

      '# Validación del Código del Cliente
      If _codigoActualCliente <> Me.txtCodigoCliente.Text Then
         Dim regla As Reglas.Clientes = New Reglas.Clientes(ModoClienteProspecto)
         Dim col As String = String.Format("Nombre{0}", ModoClienteProspecto.ToString())
         If Me.txtCodigoCliente.Text <> String.Empty AndAlso Not Me.chbNumeroAutomatico.Checked Then
            Dim dt As DataTable = regla.Get1PorCodigo(Long.Parse(Me.txtCodigoCliente.Text), incluirFoto:=False, puedeVerDetalleValoracionEstrellas:=False)

            If dt.Rows.Count > 0 Then
               For Each r As DataRow In dt.Rows
                  Me.txtCodigoCliente.Focus()
                  Return String.Format("ATENCION: El Código de {0} ingresado ya está siendo utilizado ({0}: {1}).", ModoClienteProspecto, r(col).ToString())
               Next
            End If

         End If
      End If

      If Not Me.bscCalles.Selecciono AndAlso Not Me.bscCodigoCalles.Selecciono Then
         Me.tbcCliente.SelectedTab = Me.tbpUbicacion
         Me.bscCalles.Focus()
         Return "No selecciono la Calle."
      End If

      If Not Me.bscCalles2.Selecciono AndAlso Not Me.bscCodigoCalles2.Selecciono Then
         Me.tbcCliente.SelectedTab = Me.tbpUbicacion
         Me.bscCalles2.Focus()
         Return "No selecciono la Calle 2."
      End If

      If Me.cmbFormaPago.SelectedIndex = -1 Then
         Me.tbcCliente.SelectedTab = Me.tbpCondicDeVenta
         Me.cmbFormaPago.Focus()
         Return "Debe seleccionar una Forma de Pago."
      End If

      If Me.cmbCategoriaFiscal.SelectedItem Is Nothing Then
         Return "Falta la Categoria Fiscal."
      End If

      'If DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Eniac.Entidades.CategoriaFiscal).IvaDiscriminado Then
      '   If Me.txtCUIT.Text.Length <> 11 Then
      '      Return "El CUIT ingresado para el Cliente es inválido, deben ser 11 caracteres y posee " & Me.txtCUIT.Text.Length.ToString() & "."
      '   End If
      '   If Not Eniac.Win.Publicos.EsCuitValido(Me.txtCUIT.Text.Trim()) Then
      '      Me.tbcCliente.SelectedTab = Me.tbpCondicDeVenta
      '      Me.txtCUIT.Focus()
      '      Return "El CUIT es invalido."
      '   End If
      'End If

      Dim result As Reglas.Validaciones.ValidacionResult
      result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() _
                                                                                With {.IdFiscal = txtCUIT.Text,
                                                                                      .SolicitaCUIT = DirectCast(Me._entidad, Entidades.Cliente).CategoriaFiscal.SolicitaCUIT And
                                                                                                       Me.ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente})
      If result.Error Then
         tbcCliente.SelectedTab = Me.tbpDatosPersonales
         txtCUIT.Focus()
         Return result.MensajeError
      End If

      If Me.cmbTipoCliente.SelectedIndex = -1 Then
         Return "Debe ingresar una categoria para el usuario."
      End If

      If Me.cmbTipoDoc.Text = "CUIT" Or Me.cmbTipoDoc.Text = "CUIL" Then
         If Me.txtNroDoc.Text.Length <> 11 Then
            Return "El número de " & Me.cmbTipoDoc.Text & " ingresado para el Cliente es inválido, deben ser 11 caracteres y posee " & Me.txtNroDoc.Text.Length.ToString() & "."
         End If
         If Not Eniac.Win.Publicos.EsCuitValido(Me.txtNroDoc.Text) Then
            Return "El número de " & Me.cmbTipoDoc.Text & " ingresado para el Cliente es inválido-"
         End If
      End If

      If Me.chbInscriptoIB.Checked Then
         If Me.rbtLocal.Checked = False And Me.rbtConvMultilateral.Checked = False Then
            Return "Activó Inscripto Ingresos Brutos, debe seleccionar una opción."
            Me.tbpImpuestos.Show()
         End If
      End If

      If Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing AndAlso
        DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Eniac.Entidades.CategoriaFiscal).EsPasiblePercIIBB Then
         If _soloProvinciasClienteEmpresa Then
            Dim dt As DataTable = New Eniac.Reglas.ClientesActividades().GetClientesActividades(DirectCast(Me._entidad, Entidades.Cliente).IdCliente,
                                                                                          _idProvinciaCliente,
                                                                                          DirectCast(cmbCategoriaFiscal.SelectedItem, Eniac.Entidades.CategoriaFiscal).IdCategoriaFiscal)

            Dim drCol As DataRow() = dt.Select(String.Format("IdProvincia = '{0}'", _idProvinciaCliente))
            If drCol.Length > 0 AndAlso
               _actividades.Select(String.Format("IdProvincia = '{0}'", _idProvinciaCliente)).Length = 0 Then
               Me.tbcCliente.SelectedTab = Me.tbpImpuestos
               Return String.Format("ATENCION: Debe indicar una actividad para la provincia del cliente ({0} - {1}).",
                                    _idProvinciaCliente,
                                    drCol(0)("NombreProvincia"))
            End If

            drCol = dt.Select(String.Format("IdProvincia = '{0}'", _idProvinciaSucursal))
            If drCol.Length > 0 AndAlso
               _actividades.Select(String.Format("IdProvincia = '{0}'", _idProvinciaSucursal)).Length = 0 Then
               Me.tbcCliente.SelectedTab = Me.tbpImpuestos
               Return String.Format("ATENCION: Debe indicar una actividad para la provincia de la sucursal ({0} - {1}).",
                                    _idProvinciaSucursal,
                                    drCol(0)("NombreProvincia"))
            End If
            _actividades.AcceptChanges()
            For Each dr As DataRow In _actividades.Rows
               If Not dr("IdProvincia").ToString().Equals(_idProvinciaCliente) AndAlso
                  Not dr("IdProvincia").ToString().Equals(_idProvinciaSucursal) Then
                  Me.tbcCliente.SelectedTab = Me.tbpImpuestos
                  Return String.Format("ATENCION: No debe indicar una actividad para la provincia {0} - {1} ya que no es del cliente ni de la sucursal.",
                                       dr("IdProvincia"),
                                       dr("NombreProvincia"))
               End If
            Next

         End If
      End If
      If txtNivelAutorizacion.Visible Then
         If Not IsNumeric(txtNivelAutorizacion.Text) Then txtNivelAutorizacion.Text = "1"
         If Short.Parse(txtNivelAutorizacion.Text) > actual.NivelAutorizacion Then
            tbcCliente.SelectedTab = tbpDatosPersonales
            Me.txtNivelAutorizacion.Focus()
            Return "ATENCION: El nivel de autorización ingresado es superior al suyo."
         End If
      End If
      If Not _DireccionCorregida Then
         Dim direccionVerificar As String
         With DirectCast(Me._entidad, Entidades.Cliente)
            direccionVerificar = .Calle.NombreCalle & " " & .Altura.ToString() & " " & .DireccionAdicional
         End With
         If direccionVerificar <> Me.txtDireccionCompleta.Text Then
            If MessageBox.Show("ATENCION: Existen campos inconsistente en la ubicación, verificar los campos de lo contrario limpia la ubicación actual. " & vbNewLine + vbNewLine & " ¿ Desea Continuar ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
               Return String.Empty
            Else
               Me.tbcCliente.SelectedTab = Me.tbpUbicacion
               Me.bscCalles.Focus()
               Return "Operación Cancelada por el usuario"
            End If
         End If
      End If

      Return String.Empty

   End Function

   Protected Overrides Sub Aceptar()

      '# Vuelvo a validar los horarios por si no fueron actualizados
      Me.HorarioClienteCompleto()

      If Not Me.dtpFechaBaja.Checked Then
         DirectCast(Me._entidad, Entidades.Cliente).FechaBaja = Nothing
      End If

      '-- REG-32849.- --------------------------------
      chbActivo.Checked = Not (dtpFechaBaja.Checked)
      '-----------------------------------------------

      If Not Me.dtpFechaSUS.Checked Then
         DirectCast(Me._entidad, Entidades.Cliente).FechaSUS = Nothing
      End If

      Dim descuentos As DataSet = New DataSet()
      If Me._descuentosMarcas IsNot Nothing Then
         descuentos.Tables.Add(Me._descuentosMarcas.Copy())
      End If
      If Me._descuentosRubros IsNot Nothing Then
         descuentos.Tables.Add(Me._descuentosRubros.Copy())
      End If
      If Me._descuentosProducto IsNot Nothing Then
         descuentos.Tables.Add(Me._descuentosProducto.Copy())
      End If

      If Not Me.chbInscriptoIB.Checked Then
         DirectCast(Me._entidad, Entidades.Cliente).IdTipoDeExension = -1
      End If

      'Por Compabilidad, por ahora no se usa.
      'If DirectCast(Me._entidad, Entidades.Cliente).Categoria.IdCategoria = 0 Then
      '   DirectCast(Me._entidad, Entidades.Cliente).Categoria.IdCategoria = 1
      'End If

      DirectCast(Me._entidad, Entidades.Cliente).Actividades = Me._actividades

      'DirectCast(Me._entidad, Entidades.Cliente).Alicuota2deProducto = Me.CmbAlicuota2deProducto.Text


      If chbCertificadoMiPyme.Checked Then
         DirectCast(Me._entidad, Entidades.Cliente).FechaDesdeCertificado = Me.dtpFechaDesdeCertificado.Value
         DirectCast(Me._entidad, Entidades.Cliente).FechaHastaCertificado = Me.dtpFechaHastaCertificado.Value
      Else
         DirectCast(Me._entidad, Entidades.Cliente).FechaDesdeCertificado = Nothing
         DirectCast(Me._entidad, Entidades.Cliente).FechaHastaCertificado = Nothing
      End If

      '# Verifico si el Código de Clientes es automático o no. En ese caso le seteo valor 0 y es la regla quien se encarga de asignar el nuevo Código de Cliente
      If Me.chbNumeroAutomatico.Checked Then
         DirectCast(Me._entidad, Entidades.Cliente).CodigoCliente = 0
      End If

      '---------------------------------------------------------

      Dim clie As Reglas.Clientes = New Reglas.Clientes()

      Me.HayError = False

      Try

         Dim res As String = Me.ValidarControles().Trim()
         Dim res2 As String = Me.ValidarDetalle()

         If res2 <> "" Then
            If res = "" Then
               res = res2
            Else
               res += Convert.ToChar(Keys.Enter) & res2
            End If
         End If
         If res = "" Then
            Dim oWS As Reglas.Base = Me.GetReglas()
            Me._entidad.Usuario = Eniac.Entidades.Usuario.Actual.Nombre
            'Inserto un registro
            If Me.StateForm = StateForm.Insertar Then
               clie.InsertarLIVE(Me._entidad, descuentos)
               MessageBox.Show("Se ingreso el registro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               If Not Me.HayError And Not Me.CierraAutomaticamente Then
                  Me.LimpiarControles()
               End If
            Else
               'Modifico un registro
               If DirectCast(Me._entidad, Entidades.Cliente).IdLocalidad2 = 0 Then
                  DirectCast(Me._entidad, Entidades.Cliente).IdLocalidad2 = DirectCast(Me._entidad, Entidades.Cliente).Calle2.Localidad.IdLocalidad
               End If
               If Me._cuitActualCliente <> Me.txtCUIT.Text Then
                  If MessageBox.Show("El Cuit del Cliente es distinto al actual; Desea asignarlo como Usuario del Movil/Web?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                     DirectCast(Me._entidad, Entidades.Cliente).SiMovilIdUsuario = Me.txtCUIT.Text
                  End If
               End If

               If Me._codigoActualCliente <> Me.txtCodigoCliente.Text Then
                  If MessageBox.Show("El Código del Cliente es distinto al actual; Desea asignarlo como Clave del Movil/Web?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                     DirectCast(Me._entidad, Entidades.Cliente).SiMovilClave = Me.txtCodigoCliente.Text
                  End If
               End If

               clie.ActualizarLIVE(Me._entidad, descuentos)
               MessageBox.Show("Se actualizo el registro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.DialogResult = Windows.Forms.DialogResult.OK
               Me.Close()
            End If
         Else
            MessageBox.Show(res, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.HayError = True
         End If
         If Not Me.HayError And Me.CierraAutomaticamente Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
         End If
      Catch exSql As System.Data.SqlClient.SqlException
         If exSql.Message.Contains("Cannot insert duplicate key in object") Then
         ElseIf exSql.Message.Contains("No puede insertar valores duplicados") Then 'este mensaje cambiarlo por el correcto
            MessageBox.Show("El código ingresado ya existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         ElseIf exSql.Message.Contains("Expire time") Then
            MessageBox.Show("Expiro el tiempo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         ElseIf exSql.Message.Contains("Time out") Then
            MessageBox.Show("Expiro el tiempo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(exSql.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
         Me.HayError = True
      Catch ex As Exception
         MessageBox.Show(ex.Message)
         Me.HayError = True
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub cmbTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDoc.SelectedIndexChanged
      Try
         If Me.cmbTipoDoc.SelectedIndex >= 0 And Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Me.CargarProximoCodigo()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkCalle_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCalle.LinkClicked
      Try
         Me.bscCodigoCalles.Text = String.Empty
         Dim cal As Entidades.Calle = New Entidades.Calle()
         If Me.bscNombreLocalidad.Text IsNot Nothing Then
            cal.Localidad = New Eniac.Reglas.Localidades().GetUna(Int32.Parse(Me.bscCodigoLocalidad.Text.ToString()))
         End If
         Using calles As CallesDetalle = New CallesDetalle(cal)
            calles.StateForm = Win.StateForm.Insertar
            If calles.ShowDialog() = Windows.Forms.DialogResult.OK Then
               If cal IsNot Nothing Then
                  bscCodigoLocalidad.Text = calles._idLocalidad.ToString()
                  bscCodigoCalles.Text = calles._idCalle.ToString()
                  bscCodigoCalles.PresionarBoton()
               End If
            End If
         End Using

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkCopiarDireccion_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCopiarDireccion.LinkClicked
      Try
         If Me.bscNombreLocalidad.Text IsNot Nothing And Not String.IsNullOrEmpty(Me.bscCalles.Text) Then
            Me.bscCodigoLocalidad2.Text = Me.bscCodigoLocalidad.Text.ToString()
            Me.bscNombreLocalidad2.Text = Me.bscNombreLocalidad.Text.ToString()
            Me.bscCalles2.Text = DirectCast(Me._entidad, Entidades.Cliente).Calle.NombreCalle
            Me.bscCalles2.Tag = DirectCast(Me._entidad, Entidades.Cliente).Calle.IdCalle
            Me.bscCalles2.PresionarBoton()
            Me.txtAltura2.Text = Me.txtAltura.Text
            Me.txtDireccionAdicional2.Text = Me.txtDireccionAdicional.Text
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkCalle2_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCalle2.LinkClicked
      Try
         Me.bscCodigoCalles2.Text = String.Empty
         Dim cal As Entidades.Calle = New Entidades.Calle()
         'If Me.cmbLocalidades2.SelectedValue IsNot Nothing Then
         If Me.bscCodigoLocalidad2.Text IsNot Nothing Then
            'cal.Localidad = New Eniac.Reglas.Localidades().GetUna(DirectCast(Me.cmbLocalidades2.SelectedItem, Eniac.Entidades.Localidad).IdLocalidad)
            'cal.Localidad = New Eniac.Reglas.Localidades().GetUna(Int32.Parse(Me.cmbLocalidades2.SelectedValue.ToString()))
            cal.Localidad = New Eniac.Reglas.Localidades().GetUna(Int32.Parse(Me.bscCodigoLocalidad2.Text.ToString()))

         End If
         Using calles As CallesDetalle = New CallesDetalle(cal)
            calles.StateForm = Win.StateForm.Insertar
            If calles.ShowDialog() = Windows.Forms.DialogResult.OK Then
               If cal IsNot Nothing Then
                  'cmbLocalidades2.SelectedValue = calles._idLocalidad
                  bscCodigoLocalidad.Text = calles._idLocalidad.ToString()
                  bscCodigoCalles2.Text = calles._idCalle.ToString()
                  bscCodigoCalles2.PresionarBoton()
               End If
            End If
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbHorarioCorridoLaV_CheckedChanged(sender As Object, e As EventArgs) Handles chbHorarioCorridoLaV.CheckedChanged
      Try
         If Me.chbHorarioCorridoLaV.Checked Then
            Me.dtpHoraDesde2.Value = DateTime.Today
            Me.dtpHoraDesde2.Enabled = False
            Me.dtpHoraHasta.Value = DateTime.Today
            Me.dtpHoraHasta.MinDate = DateTime.Today
            Me.dtpHoraHasta.Enabled = False
         Else
            Me.dtpHoraDesde2.Enabled = True
            Me.dtpHoraHasta.Enabled = True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbHorarioCorridoSab_CheckedChanged(sender As Object, e As EventArgs) Handles chbHorarioCorridoSab.CheckedChanged
      Try
         If Me.chbHorarioCorridoSab.Checked Then
            Me.dtpHoraSabDesde2.Value = DateTime.Today
            Me.dtpHoraSabDesde2.MinDate = DateTime.Today
            Me.dtpHoraSabDesde2.Enabled = False
            Me.dtpHoraSabHasta.Value = DateTime.Today
            Me.dtpHoraSabHasta.MinDate = DateTime.Today
            Me.dtpHoraSabHasta.Enabled = False
         Else
            Me.dtpHoraSabDesde2.Enabled = True
            Me.dtpHoraSabHasta.Enabled = True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub lnkCopiarNombreCliente_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCopiarNombreCliente.LinkClicked
      Try
         Me.txtNombreDeFantasia.Text = Me.txtNombre.Text
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCalles_BuscadorClick() Handles bscCalles.BuscadorClick
      Try
         Dim oCalles As Reglas.Calles = New Reglas.Calles()
         Me._publico.PreparaGrillaCalles(Me.bscCalles)

         Dim idLoca As Integer = 0
         If Me.bscNombreLocalidad.Text IsNot Nothing Then
            idLoca = Int32.Parse(Me.bscCodigoLocalidad.Text.ToString())
         End If
         'esto lo hago para cuando cargo las pantallas ya que busco solamente por el Id de la calle
         'y luego tengo que eliminar el valor del Tag para que se pueda filtrar correctamente
         If Me.bscCalles.Tag Is Nothing OrElse String.IsNullOrEmpty(Me.bscCalles.Tag.ToString()) Then
            Me.bscCalles.Datos = oCalles.GetPorLocalidadYNombre(idLoca, Me.bscCalles.Text)
         Else
            Me.bscCalles.Datos = oCalles.GetPorId(Int32.Parse(Me.bscCalles.Tag.ToString()))
         End If
         Me.bscCalles.Tag = ""
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCalles_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCalles.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscCalles.Text = e.FilaDevuelta.Cells("NombreCalle").Value.ToString()
            DirectCast(Me._entidad, Entidades.Cliente).Calle = New Reglas.Calles().GetUna(Int32.Parse(e.FilaDevuelta.Cells("IdCalle").Value.ToString()))
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

      If Not Me.HayError Then Me.Close()

      Try
         'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         '   Me.tbcCliente.SelectedTab = Me.tbpDatosPersonales
         '   Me.bscCalles.Text = String.Empty
         '   Me.CargarProximoCodigo()
         'End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCalles2_BuscadorClick() Handles bscCalles2.BuscadorClick
      Try
         Dim oCalles As Reglas.Calles = New Reglas.Calles()
         Me._publico.PreparaGrillaCalles(Me.bscCalles2)
         Dim idLoca As Integer = 0
         'If Me.cmbLocalidades2.SelectedIndex <> -1 Then
         If Me.bscNombreLocalidad2.Text IsNot Nothing Then
            'idLoca = Int32.Parse(Me.cmbLocalidades2.SelectedValue.ToString())
            idLoca = Int32.Parse(Me.bscCodigoLocalidad2.Text.ToString())
         End If
         'esto lo hago para cuando cargo las pantallas ya que busco solamente por el Id de la calle
         'y luego tengo que eliminar el valor del Tag para que se pueda filtrar correctamente
         If Me.bscCalles2.Tag Is Nothing OrElse String.IsNullOrEmpty(Me.bscCalles2.Tag.ToString()) Then
            Me.bscCalles2.Datos = oCalles.GetPorLocalidadYNombre(idLoca, Me.bscCalles2.Text)
         Else
            Me.bscCalles2.Datos = oCalles.GetPorId(Int32.Parse(Me.bscCalles2.Tag.ToString()))
         End If
         Me.bscCalles2.Tag = ""

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCalles2_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCalles2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscCalles2.Text = e.FilaDevuelta.Cells("NombreCalle").Value.ToString()
            DirectCast(Me._entidad, Entidades.Cliente).Calle2 = New Reglas.Calles().GetUna(Int32.Parse(e.FilaDevuelta.Cells("IdCalle").Value.ToString()))
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   'Private Sub cmbLocalidades_SelectedIndexChanged(sender As Object, e As EventArgs)
   '   Try
   '      Me.bscCalles.Text = String.Empty
   '      Me.bscCalles.Selecciono = False
   '      Me.bscCalles.Datos = Nothing

   '      Me._idProvinciaCliente = ""
   '      If Me.cmbLocalidades.SelectedValue IsNot Nothing Then
   '         Me._idProvinciaCliente = New Eniac.Reglas.Localidades().GetUna(Integer.Parse(Me.cmbLocalidades.SelectedValue.ToString())).IdProvincia
   '      End If

   '      Me.CargarActividades()

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Private Sub cmbLocalidades2_SelectedIndexChanged(sender As Object, e As EventArgs)
      Try
         Me.bscCalles2.Text = String.Empty
         Me.bscCalles2.Selecciono = False
         Me.bscCalles2.Datos = Nothing
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbVendedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVendedor.SelectedIndexChanged
      Try
         If Not Me._cargandoPantalla Then
            DirectCast(Me._entidad, Entidades.Cliente).Vendedor = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbDadoAltaPor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDadoAltaPor.SelectedIndexChanged
      Try
         If Not Me._cargandoPantalla Then
            DirectCast(Me._entidad, Entidades.Cliente).DadoAltaPor = DirectCast(Me.cmbDadoAltaPor.SelectedItem, Eniac.Entidades.Empleado)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbTransportistas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTransportistas.SelectedIndexChanged
      Try
         If Not Me._cargandoPantalla Then
            '   DirectCast(Me._entidad, Entidades.Cliente).Transportista = DirectCast(Me.cmbTransportistas.SelectedItem, Eniac.Entidades.Transportista)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreClienteCtaCte_BuscadorClick() Handles bscNombreClienteCtaCte.BuscadorClick
      Try
         Me._publico.PreparaGrillaClientes(Me.bscNombreClienteCtaCte)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes()
         '  Me.bscNombreClienteCtaCte.Datos = oClientes.GetFiltradoPorNombre(Me.bscNombreClienteCtaCte.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreClienteCtaCte_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscNombreClienteCtaCte.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteCtaCte(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   '
   Private Sub chkClienteCtaCte_CheckedChanged(sender As Object, e As EventArgs) Handles chkClienteCtaCte.CheckedChanged
      Try
         If Not Me.chkClienteCtaCte.Checked Then
            Me.bscCodigoClienteCtaCte.Text = ""
            Me.bscNombreClienteCtaCte.Text = ""
            DirectCast(Me._entidad, Entidades.Cliente).IdClienteCtaCte = 0
         End If
         Me.bscCodigoClienteCtaCte.Enabled = Me.chkClienteCtaCte.Checked
         Me.bscNombreClienteCtaCte.Enabled = Me.chkClienteCtaCte.Checked

         If Me.chkClienteCtaCte.Checked Then
            Me.bscCodigoClienteCtaCte.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoClienteCtaCte_BuscadorClick() Handles bscCodigoClienteCtaCte.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publico.PreparaGrillaClientes(Me.bscCodigoClienteCtaCte)
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         If Me.bscCodigoClienteCtaCte.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoClienteCtaCte.Text.Trim())
         End If
         Me.bscCodigoClienteCtaCte.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoClienteCtaCte_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoClienteCtaCte.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteCtaCte(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publico.PreparaGrillaProductos2(Me.bscCodigoProducto)
         Me.bscCodigoProducto.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, 0, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto_BuscadorClick() Handles bscProducto.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publico.PreparaGrillaProductos2(Me.bscProducto)
         Me.bscProducto.Datos = oProductos.GetPorNombre(Me.bscProducto.Text.Trim(), actual.Sucursal.Id, 0, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertarMarca_Click(sender As Object, e As EventArgs) Handles btnInsertarMarca.Click
      Try
         If Me.cmbMarcas.SelectedValue IsNot Nothing And Me.txtDescuentoMarcas.Text <> "0.00" Then
            If Me.ExisteMarca(Int32.Parse(Me.cmbMarcas.SelectedValue.ToString())) Then
               MessageBox.Show("Ya existe la Marca.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               Me.AgregarMarca()

            End If
            Me.cmbMarcas.Text = ""
            Me.txtDescuentoMarcas.Text = "0.00"
            Me.cmbMarcas.Focus()
         Else
            MessageBox.Show("El Descuento no puede ser 0", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarMarca_Click(sender As Object, e As EventArgs) Handles btnEliminarMarca.Click
      Try
         If Me.dgvDescuentosMarcas.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el Descuento seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaMarca()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnRefrescarMarcas_Click(sender As Object, e As EventArgs) Handles btnRefrescarMarcas.Click
      Try
         Me.cmbMarcas.SelectedIndex = -1
         Me.txtDescuentoMarcas.Text = "0.00"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertarRubros_Click(sender As Object, e As EventArgs) Handles btnInsertarRubros.Click
      Try
         If Me.cmbRubros.SelectedValue IsNot Nothing And Me.txtDescuentoRubro.Text <> "0.00" Then
            If Me.ExisteRubro(Int32.Parse(Me.cmbRubros.SelectedValue.ToString())) Then
               MessageBox.Show("Ya existe el Rubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               Me.AgregarRubro()

            End If
            Me.cmbRubros.Text = ""
            Me.txtDescuentoRubro.Text = "0.00"
            Me.cmbRubros.Focus()
         Else
            MessageBox.Show("El Descuento no puede ser 0", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarRubro_Click(sender As Object, e As EventArgs) Handles btnEliminarRubros.Click
      Try
         If Me.dgvDescuentosRubros.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el Descuento seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaRubro()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnRefrescarRubros_Click(sender As Object, e As EventArgs) Handles btnRefrescarRubros.Click
      Try
         Me.cmbRubros.SelectedIndex = -1
         Me.txtDescuentoRubro.Text = "0.00"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertarProductos_Click(sender As Object, e As EventArgs) Handles btnInsertarProductos.Click
      Try
         If String.IsNullOrEmpty(Me.bscCodigoProducto.Text) Then
            MessageBox.Show("Seleccione un Producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscProducto.Focus()
            Exit Sub
         End If
         If Me.bscCodigoProducto.Text IsNot Nothing And Me.txtDescuentoProducto.Text <> "0.00" Then
            If Me.ExisteProducto(Int32.Parse(Me.bscCodigoProducto.Text.ToString())) Then
               MessageBox.Show("Ya existe el Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               Me.AgregarProducto()

            End If
            Me.bscCodigoProducto.Text = ""
            Me.bscProducto.Text = ""
            Me.txtDescuentoProducto.Text = "0.00"
            Me.bscProducto.Enabled = True
            Me.bscCodigoProducto.Enabled = True
            Me.bscCodigoProducto.Focus()
         Else
            MessageBox.Show("El Descuento no puede ser 0", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDescuentoProducto.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarProductos_Click(sender As Object, e As EventArgs) Handles btnEliminarProductos.Click
      Try
         If Me.dgvDescuentosProductos.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el Descuento seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaProducto()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnRefrescarProductos_Click(sender As Object, e As EventArgs) Handles btnRefrescarProductos.Click
      Try
         Me.bscCodigoProducto.Text = ""
         Me.bscProducto.Text = ""
         Me.txtDescuentoProducto.Text = "0.00"
         Me.bscProducto.Enabled = True
         Me.bscCodigoProducto.Enabled = True
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkLocalidad_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLocalidad.LinkClicked
      Try
         Dim PantLocalidad As LocalidadesDetalle = New LocalidadesDetalle(New Entidades.Localidad())
         PantLocalidad.StateForm = Win.StateForm.Insertar
         PantLocalidad.CierraAutomaticamente = True
         If PantLocalidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoLocalidad.Text = PantLocalidad.IdLocalidad.ToString()
            Me.bscCodigoLocalidad.PresionarBoton()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkLocalidad2_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLocalidad2.LinkClicked
      Try
         Dim PantLocalidad As LocalidadesDetalle = New LocalidadesDetalle(New Entidades.Localidad())
         PantLocalidad.StateForm = Win.StateForm.Insertar
         PantLocalidad.CierraAutomaticamente = True
         If PantLocalidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoLocalidad2.Text = PantLocalidad.IdLocalidad.ToString()
            Me.bscCodigoLocalidad2.PresionarBoton()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub HorarioClienteCompleto()

      Dim horarioClienteCompleto As StringBuilder = New StringBuilder
      With horarioClienteCompleto

         '# Lunes a Viernes
         If IsDate(dtpHoraDesde.Value) AndAlso dtpHoraDesde.Value.TimeOfDay.ToString <> "00:00:00" Then
            .AppendFormat("Lun A Vie: {0} a {1}", dtpHoraDesde.Value.ToString("HH:mm"), If(chbHorarioCorridoLaV.Checked, dtpHoraHasta2.Value.ToString("HH:mm"), dtpHoraHasta.Value.ToString("HH:mm")))
            If Not Me.chbHorarioCorridoLaV.Checked AndAlso IsDate(dtpHoraDesde2.Value) AndAlso dtpHoraDesde2.Value.TimeOfDay.ToString <> "00:00:00" Then
               .AppendFormat(" Y de {0} a {1}", dtpHoraDesde2.Value.ToString("HH:mm"), dtpHoraHasta2.Value.ToString("HH:mm"))
            End If
         End If

         '# Sábados
         If IsDate(dtpHoraSabDesde.Value) AndAlso dtpHoraSabDesde.Value.TimeOfDay.ToString <> "00:00:00" Then
            .AppendFormat(" - Sab: {0} a {1}", dtpHoraSabDesde.Value.ToString("HH:mm"), If(chbHorarioCorridoSab.Checked, dtpHoraSabHasta2.Value.ToString("HH:mm"), dtpHoraSabHasta.Value.ToString("HH:mm")))
            If Not Me.chbHorarioCorridoSab.Checked AndAlso IsDate(dtpHoraSabDesde2.Value) AndAlso dtpHoraSabDesde2.Value.TimeOfDay.ToString <> "00:00:00" Then
               .AppendFormat(" Y de {0} a {1}.", dtpHoraSabDesde2.Value.ToString("HH:mm"), dtpHoraSabHasta2.Value.ToString("HH:mm"))
            End If
         End If

         '# Desde el ABM Live no existen los domingos

      End With

      Me.txtHorarioClienteCompleto.Text = If(Not String.IsNullOrEmpty(horarioClienteCompleto.ToString()), horarioClienteCompleto.ToString(), String.Empty)
   End Sub

   Private Sub CargarLocalidad(dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.Cliente).Localidad = New Reglas.Localidades().GetUna(Integer.Parse(dr.Cells("IdLocalidad").Value.ToString()))
      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      _idProvinciaCliente = dr.Cells("IdProvincia").Value.ToString()
      Me.txtProvinciaLocalidad.Text = dr.Cells("NombreProvincia").Value.ToString()
      Me.bscCalles.Text = ""
      Me.CargarActividades()

   End Sub

   Private Sub CargarLocalidad2(dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.Cliente).Localidad = New Reglas.Localidades().GetUna(Integer.Parse(dr.Cells("IdLocalidad").Value.ToString()))
      Me.bscCodigoLocalidad2.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidad2.Text = dr.Cells("NombreLocalidad").Value.ToString()
      _idProvinciaCliente = dr.Cells("IdProvincia").Value.ToString()
      Me.bscCalles2.Text = ""
      Me.CargarActividades()

   End Sub

   Private Sub CargarProximoCodigo()

      Dim oCliente As Reglas.Clientes = New Reglas.Clientes()
      Dim ProximoCliente As Long

      ProximoCliente = oCliente.GetCodigoMaximo(Entidades.Cliente.Columnas.CodigoCliente.ToString()) + 1
      Me.txtCodigoCliente.Text = ProximoCliente.ToString()

      DirectCast(Me._entidad, Entidades.Cliente).IdCliente = ProximoCliente

      'Me.txtCodigoCliente.Tag = Me.txtCodigoCliente.Text

      'If ProximoCliente > Long.Parse("0" & Me.txtNroDoc.Text) Then
      '   Me.txtNroDoc.Text = Me.txtCodigoCliente.Text
      'End If

   End Sub

   Private Sub CargarDatosClienteCtaCte(dr As DataGridViewRow)
      Me.bscNombreClienteCtaCte.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoClienteCtaCte.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscNombreClienteCtaCte.Text = dr.Cells("NombreCliente").Value.ToString()

      DirectCast(Me._entidad, Entidades.Cliente).IdClienteCtaCte = Long.Parse(dr.Cells("Id" + ModoClienteProspecto.ToString()).Value.ToString())

   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)

      Me.bscProducto.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto.Enabled = False
      Me.bscCodigoProducto.Enabled = False

   End Sub

   Private _descuentosMarcas As DataTable
   Private _descuentosRubros As DataTable
   Private _descuentosProducto As DataTable

   Private Function ExisteMarca(idMarca As Integer) As Boolean
      Return ExisteClavePrimaria(_descuentosMarcas, "IdMarca", idMarca)
      'For Each dr As DataRow In Me._descuentosMarcas.Rows
      '   If Int32.Parse(dr("IdMarca").ToString()) = idMarca Then
      '      Return True
      '   End If
      'Next
      'Return False
   End Function
   Private Sub AgregarMarca()

      Dim dr As DataRow = Me._descuentosMarcas.NewRow()

      dr("IdCliente") = DirectCast(Me._entidad, Entidades.Cliente).IdCliente
      dr("IdMarca") = Me.cmbMarcas.SelectedValue.ToString()
      dr("NombreMarca") = Me.cmbMarcas.Text
      dr("DescuentoRecargoPorc1") = Me.txtDescuentoMarcas.Text
      dr("DescuentoRecargoPorc2") = 0

      Me._descuentosMarcas.Rows.Add(dr)

      Me.dgvDescuentosMarcas.DataSource = Me._descuentosMarcas

   End Sub
   Private Sub EliminarLineaMarca()
      EliminarLineaSeleccionada(dgvDescuentosMarcas)
      'Me._descuentosMarcas.Rows(Me.dgvDescuentosMarcas.SelectedRows(0).Index).Delete()
      'Me.dgvDescuentosMarcas.DataSource = Me._descuentosMarcas
   End Sub

   Private Function ExisteRubro(idRubro As Integer) As Boolean
      Return ExisteClavePrimaria(_descuentosRubros, "IdRubro", idRubro)
      'For Each dr As DataRow In Me._descuentosRubros.Rows
      '   If Int32.Parse(dr("IdRubro").ToString()) = idRubro Then
      '      Return True
      '   End If
      'Next
      'Return False
   End Function

   Private Sub AgregarRubro()

      Dim dr As DataRow = Me._descuentosRubros.NewRow()

      dr("IdCliente") = DirectCast(Me._entidad, Entidades.Cliente).IdCliente
      dr("IdRubro") = Me.cmbRubros.SelectedValue.ToString()
      dr("NombreRubro") = Me.cmbRubros.Text
      dr("DescuentoRecargoPorc1") = Me.txtDescuentoRubro.Text
      dr("DescuentoRecargoPorc2") = "0"

      Me._descuentosRubros.Rows.Add(dr)

      Me.dgvDescuentosRubros.DataSource = Me._descuentosRubros

   End Sub

   Private Sub EliminarLineaRubro()
      EliminarLineaSeleccionada(dgvDescuentosRubros)
      'Me._descuentosRubros.Rows(Me.dgvDescuentosRubros.SelectedRows(0).Index).Delete()
      'Me.dgvDescuentosRubros.DataSource = Me._descuentosRubros
   End Sub

   Private Function ExisteProducto(idProducto As Integer) As Boolean
      Return ExisteClavePrimaria(_descuentosProducto, "IdProducto", idProducto)
      'For Each dr As DataRow In Me._descuentosProducto.Rows
      '   If Int32.Parse(dr("IdProducto").ToString()) = idProducto Then
      '      Return True
      '   End If
      'Next
      'Return False
   End Function

   Private Sub AgregarProducto()

      Dim dr As DataRow = Me._descuentosProducto.NewRow()

      dr("IdCliente") = DirectCast(Me._entidad, Entidades.Cliente).IdCliente
      dr("IdProducto") = Me.bscCodigoProducto.Text.ToString()
      dr("NombreProducto") = Me.bscProducto.Text
      dr("DescuentoRecargoPorc1") = Me.txtDescuentoProducto.Text

      Me._descuentosProducto.Rows.Add(dr)

      Me.dgvDescuentosProductos.DataSource = Me._descuentosProducto

   End Sub

   Private Sub EliminarLineaProducto()
      EliminarLineaSeleccionada(dgvDescuentosProductos)
      'Me._descuentosProducto.Rows(Me.dgvDescuentosProductos.SelectedRows(0).Index).Delete()
      'Me.dgvDescuentosProductos.DataSource = Me._descuentosProducto
   End Sub


   Private Sub EliminarLineaSeleccionada(grilla As Eniac.Controles.DataGridView)
      If grilla IsNot Nothing Then
         If grilla.SelectedRows.Count > 0 AndAlso
            grilla.SelectedRows(0).DataBoundItem IsNot Nothing AndAlso
            TypeOf (grilla.SelectedRows(0).DataBoundItem) Is DataRowView AndAlso
            DirectCast(grilla.SelectedRows(0).DataBoundItem, DataRowView).Row IsNot Nothing Then
            DirectCast(grilla.SelectedRows(0).DataBoundItem, DataRowView).Row.Delete()
         End If
         If grilla.RowCount > 0 And grilla.SelectedRows.Count = 0 Then
            grilla.Rows(0).Selected = True
         End If
      End If
   End Sub
   Private Function ExisteClavePrimaria(dt As DataTable, keyName As String, keyValue As Integer) As Boolean
      If dt IsNot Nothing Then
         For Each dr As DataRow In dt.Rows
            If dr.RowState <> DataRowState.Deleted Then
               If Int32.Parse(dr(keyName).ToString()) = keyValue Then
                  Return True
               End If
            End If
         Next
      End If
      Return False
   End Function

#End Region

   Private Sub bscCalles_TextChange(sender As Object, e As EventArgs) Handles bscCalles.TextChange
      Try
         If Not Me._cargandoPantalla Then
            'DirectCast(Me._entidad, Entidades.Cliente).Calle = Nothing
            'Me.bscCalles.Selecciono = False
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCalles2_Load(sender As Object, e As EventArgs) Handles bscCalles2.Load
      Try
         If Not Me._cargandoPantalla Then
            'DirectCast(Me._entidad, Entidades.Cliente).Calle2 = Nothing
            ' Me.bscCalles2.Selecciono = False
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbTipoDocCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoDocCliente.CheckedChanged
      Try
         If Me.chbTipoDocCliente.Checked Then
            Me.cmbTipoDoc.Enabled = True
            Me.txtNroDoc.Enabled = True
         Else
            Me.cmbTipoDoc.Enabled = False
            Me.txtNroDoc.Enabled = False
            Me.txtNroDoc.Text = "0"
            Me.cmbTipoDoc.SelectedIndex = -1
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbInscriptoIB_CheckedChanged(sender As Object, e As EventArgs) Handles chbInscriptoIB.CheckedChanged
      Try

         Me.rbtLocal.Enabled = Me.chbInscriptoIB.Checked
         Me.rbtConvMultilateral.Enabled = Me.chbInscriptoIB.Checked
         Me.gpbActividades.Enabled = Me.chbInscriptoIB.Checked
         Me.gpbTiposDeExension.Enabled = Me.chbInscriptoIB.Checked

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
      Try
         Me.Refrescar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscActividades_BuscadorClick() Handles bscActividades.BuscadorClick
      Try
         Me._publicos.PreparaGrillaActividades(Me.bscActividades)
         Dim oActividades As Eniac.Reglas.Actividades = New Eniac.Reglas.Actividades
         Me.bscActividades.Datos = oActividades.GetPorNombre(Me.bscActividades.Text.Trim(), Me.cmbProvincia.SelectedValue.ToString())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscActividades_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscActividades.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosActividad(e.FilaDevuelta)
            Me.btnInsertar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Me.bscActividades.FilaDevuelta IsNot Nothing Then
            If Me.bscActividades.Text <> "" Then
               If Me.ExisteActividad(Integer.Parse(Me.bscActividades.FilaDevuelta.Cells("IdActividad").Value.ToString()), Me.cmbProvincia.SelectedValue.ToString()) Then
                  MessageBox.Show("Ya existe la Actividad.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Else
                  Me.AgregarActividad()

               End If
               Me.Refrescar()
               Me.cmbProvincia.Focus()
            Else
               MessageBox.Show("No selecciono la Actividad", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvDetalle.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar la Actividad seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.cmbProvincia.Focus()
               Me.EliminarLineaActividad()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Public Sub Refrescar()
      Me.bscActividades.Text = ""
      Me.txtPorcentaje.Text = "0.00"
      Me.cmbProvincia.Text = New Eniac.Reglas.Localidades().GetUna(Publicos.LocalidadEmpresa).NombreProvincia.ToString()
      Me.bscActividades.Enabled = True
      Me.txtPorcentaje.Enabled = True
      Me.cmbProvincia.Enabled = True
      Me.cmbProvincia.Focus()
   End Sub

   Private Sub CargarDatosActividad(dr As DataGridViewRow)

      Me.bscActividades.Text = dr.Cells("NombreActividad").Value.ToString()
      Me.txtPorcentaje.Text = Decimal.Parse(dr.Cells("Porcentaje").Value.ToString()).ToString()
      Me.bscActividades.Enabled = False
      Me.txtPorcentaje.Enabled = False
      Me.cmbProvincia.Enabled = False

   End Sub

   Private Function ExisteActividad(idActividad As Integer, idProvincia As String) As Boolean

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         If Integer.Parse(dr.Cells("IdActividad").Value.ToString()) = idActividad And dr.Cells("IdProvincia").Value.ToString() = idProvincia Then
            Return True
         End If
      Next

      Return False

   End Function

   Public Sub CargarActividades()

      Dim IdCliente As Long = 0

      IdCliente = DirectCast(Me._entidad, Entidades.Cliente).IdCliente

      Dim reg As Eniac.Reglas.ClientesActividades = New Eniac.Reglas.ClientesActividades()

      Dim idCategoriaFiscalCliente As Integer = 0
      If cmbCategoriaFiscal.SelectedIndex >= 0 Then
         idCategoriaFiscalCliente = DirectCast(cmbCategoriaFiscal.SelectedItem, Eniac.Entidades.CategoriaFiscal).IdCategoriaFiscal
      End If

      Me._actividades = reg.GetClientesActividades(IdCliente, _idProvinciaCliente, idCategoriaFiscalCliente)

      Me.ChequeaEstructuraActividades()

      Me.dgvDetalle.DataSource = Me._actividades

   End Sub
   Private Sub AgregarActividad()

      Dim dr As DataRow = Me._actividades.NewRow()

      dr("IdCliente") = DirectCast(Me._entidad, Entidades.Cliente).CodigoCliente
      dr("IdProvincia") = Me.bscActividades.FilaDevuelta.Cells("IdProvincia").Value.ToString()
      dr("NombreProvincia") = Me.bscActividades.FilaDevuelta.Cells("NombreProvincia").Value.ToString()
      dr("IdActividad") = Me.bscActividades.FilaDevuelta.Cells("IdActividad").Value.ToString()
      dr("NombreActividad") = Me.bscActividades.FilaDevuelta.Cells("NombreActividad").Value.ToString()
      dr("Porcentaje") = Me.bscActividades.FilaDevuelta.Cells("Porcentaje").Value.ToString()

      Me._actividades.Rows.Add(dr)

      Me.dgvDetalle.DataSource = Me._actividades

   End Sub

   Private Sub EliminarLineaActividad()

      Me._actividades.Rows(Me.dgvDetalle.SelectedRows(0).Index).Delete()
      Me.dgvDetalle.DataSource = Me._actividades

      If Me.dgvDetalle.Rows.Count > 0 Then
         Me.dgvDetalle.FirstDisplayedScrollingRowIndex = Me.dgvDetalle.Rows.Count - 1
         Me.dgvDetalle.Rows(Me.dgvDetalle.Rows.Count - 1).Selected = True
      End If

   End Sub

   Private Sub ChequeaEstructuraActividades()
      If Me._actividades Is Nothing Then
         Me._actividades = New DataTable()
         Me._actividades.Columns.Add("IdCliente", System.Type.GetType("System.String"))
         Me._actividades.Columns.Add("IdProvincia", System.Type.GetType("System.String"))
         Me._actividades.Columns.Add("NombreProvincia", System.Type.GetType("System.String"))
         Me._actividades.Columns.Add("IdActividad", System.Type.GetType("System.Int32"))
         Me._actividades.Columns.Add("NombreActividad", System.Type.GetType("System.String"))
         Me._actividades.Columns.Add("Porcentaje", System.Type.GetType("System.Decimal"))
      End If

   End Sub

   Private Sub cmbCategoriaFiscal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoriaFiscal.SelectedIndexChanged
      ' If Me._estaCargando Then Exit Sub
      DirectCast(Me._entidad, Entidades.Cliente).CategoriaFiscal = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Eniac.Entidades.CategoriaFiscal)
      Me.CargarActividades()
      chbInscriptoIB.Enabled = True
      chbInscriptoIB.Checked = Reglas.Publicos.RetieneIIBB AndAlso DirectCast(Me._entidad, Entidades.Cliente).CategoriaFiscal.EsPasiblePercIIBB
      chbInscriptoIB.Enabled = False
   End Sub

   Private Sub chbCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chbCaja.CheckedChanged
      If Not Me.chbCaja.Checked Then
         Me.cmbCajas.SelectedIndex = -1
         DirectCast(Me._entidad, Entidades.Cliente).IdCaja = 0
      End If
      Me.cmbCajas.Enabled = Me.chbCaja.Checked()
   End Sub

   Private Sub txtCUIT_Leave(sender As Object, e As EventArgs) Handles txtCUIT.Leave
      Try

         If txtCUIT.Text <> "" Then
            Dim o As Long = 1
            Dim cl As Entidades.Cliente = New Reglas.Clientes().GetUnoPorCUIT(txtCUIT.Text)
            If Me.StateForm = Eniac.Win.StateForm.Actualizar Then

               If cl IsNot Nothing AndAlso cl.CodigoCliente <> Long.Parse(txtCodigoCliente.Text) Then
                  MessageBox.Show("Atención, este número de CUIT ya esta asignado a otro cliente ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If
            ElseIf Me.StateForm = Eniac.Win.StateForm.Insertar Then
               If cl IsNot Nothing Then
                  MessageBox.Show("Atención, este número de CUIT ya esta asignado a otro cliente ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tbcCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcCliente.SelectedIndexChanged
      Try
         If Me.tbcCliente.SelectedTab Is Me.tbpImpuestos Then
            Me.chbInscriptoIB.Checked = Reglas.Publicos.RetieneIIBB AndAlso DirectCast(Me._entidad, Entidades.Cliente).CategoriaFiscal.EsPasiblePercIIBB
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoCalles_BuscadorClick() Handles bscCodigoCalles.BuscadorClick
      Try
         Dim oCalle As Reglas.Calles = New Reglas.Calles
         Me._publicos.PreparaGrillaCalles(Me.bscCodigoCalles)
         Me.bscCodigoCalles.Datos = oCalle.GetPorId(Int32.Parse(bscCodigoCalles.Text.ToString()))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoCalles_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCalles.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarCalles1(e.FilaDevuelta)
            Me.cmbCategoriaFiscal.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub CargarCalles1(dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.Cliente).Calle = New Reglas.Calles().GetUna(Int32.Parse(dr.Cells("IdCalle").Value.ToString()))
      Me.bscCodigoCalles.Text = dr.Cells("IdCalle").Value.ToString()
      Me.bscCalles.Text = dr.Cells("NombreCalle").Value.ToString()
   End Sub

   Private Sub bscCodigoCalles2_BuscadorClick() Handles bscCodigoCalles2.BuscadorClick
      Try
         Dim oCalle As Reglas.Calles = New Reglas.Calles
         Me._publicos.PreparaGrillaCalles(Me.bscCodigoCalles2)
         Me.bscCodigoCalles2.Datos = oCalle.GetPorId(Int32.Parse(bscCodigoCalles2.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoCalles2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCalles2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarCalles2(e.FilaDevuelta)
            Me.cmbCategoriaFiscal.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub CargarCalles2(dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.Cliente).Calle2 = New Reglas.Calles().GetUna(Int32.Parse(dr.Cells("IdCalle").Value.ToString()))
      Me.bscCodigoCalles2.Text = dr.Cells("IdCalle").Value.ToString()
      Me.bscCalles2.Text = dr.Cells("NombreCalle").Value.ToString()
   End Sub
   Private Sub chbCertificadoMiPyme_CheckedChanged(sender As Object, e As EventArgs) Handles chbCertificadoMiPyme.CheckedChanged
      Try

         Me.dtpFechaDesdeCertificado.Enabled = Me.chbCertificadoMiPyme.Checked
         Me.dtpFechaHastaCertificado.Enabled = Me.chbCertificadoMiPyme.Checked
      Catch ex As Exception
         chbCertificadoMiPyme.Checked = False
         ShowError(ex)
      End Try
   End Sub

   Private Sub ClientesLIVEDetalle_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      Try
         If Me.StateForm = Eniac.Win.StateForm.Actualizar Then
            If DirectCast(Me._entidad, Entidades.Cliente).Vendedor.IdEmpleado > 0 Then
               Me.cmbVendedor.SelectedItem = Me.GetVendedorCombo(DirectCast(Me._entidad, Entidades.Cliente).Vendedor.IdEmpleado)
            End If
            Me.txtNombre.Focus()
         Else
            Me.txtCodigoCliente.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Function GetVendedorCombo(Id As Integer) As Object
      If Me.cmbVendedor.DataSource IsNot Nothing Then
         Dim empleados As List(Of Entidades.Empleado) = DirectCast(Me.cmbVendedor.DataSource, List(Of Entidades.Empleado))
         For Each emp As Entidades.Empleado In empleados
            If Id = emp.IdEmpleado Then
               Return emp
            End If
         Next
      End If
      Return Nothing
   End Function

   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidad)
         Me.bscCodigoLocalidad.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidad.Text.ToString()))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.cmbZonaGeografica.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidad2_BuscadorClick() Handles bscCodigoLocalidad2.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidad2)
         Me.bscCodigoLocalidad2.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidad2.Text.ToString()))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidad2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad2(e.FilaDevuelta)
            Me.cmbZonaGeografica.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNombreLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscNombreLocalidad)
         Me.bscNombreLocalidad.Datos = oLocalidades.GetPorNombre(Me.bscNombreLocalidad.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.cmbZonaGeografica.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidad2_BuscadorClick() Handles bscNombreLocalidad2.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscNombreLocalidad2)
         Me.bscNombreLocalidad2.Datos = oLocalidades.GetPorNombre(Me.bscNombreLocalidad2.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidad2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreLocalidad2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad2(e.FilaDevuelta)
            Me.cmbZonaGeografica.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbNumeroAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroAutomatico.CheckedChanged

      Me.txtCodigoCliente.ReadOnly = Me.chbNumeroAutomatico.Checked
      If Me.chbNumeroAutomatico.Checked Then
         CargarProximoCodigo()
      End If

   End Sub

   Private Sub Horarios_Leave(sender As Object, e As EventArgs) Handles dtpHoraDesde.Leave,
      dtpHoraHasta.Leave, dtpHoraDesde2.Leave, dtpHoraHasta2.Leave,
      dtpHoraSabDesde.Leave, dtpHoraSabHasta.Leave, dtpHoraSabDesde2.Leave, dtpHoraSabHasta2.Leave,
      chbHorarioCorridoLaV.CheckedChanged, chbHorarioCorridoSab.CheckedChanged
      Try
         If Not _cargandoPantalla Then
            Me.HorarioClienteCompleto()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   '-- REQ-32849.- ---------------------
   Private Sub dtpFechaBaja_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaBaja.ValueChanged
      chbActivo.Checked = Not (dtpFechaBaja.Checked)
   End Sub
   '------------------------------------

End Class
