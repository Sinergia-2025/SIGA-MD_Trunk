Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.MapProviders
Public Class ClientesDetalle
   Private solicitarSoporte As Reglas.SolicitarSoporte
   Private sincronizacion As Reglas.ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil

   Public ReadOnly Property Cliente As Entidades.Cliente
      Get
         Return DirectCast(_entidad, Entidades.Cliente)
      End Get
   End Property

#Region "Campos"

   Private _validaGarante As Boolean = False
   Public _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private _originalTipoDocGarante As String = String.Empty
   Private _originalNroDocGarante As String = String.Empty
   Private _actividades As DataTable
   Public _direcciones As DataTable

   Public _domicilios As DataTable = Nothing

   Private _contactos As DataTable
   Private _contactosBorrados As DataTable
   Private _MostrarVendedor As Boolean
   Private _idProvinciaCliente As String
   Private _idProvinciaSucursal As String
   Private _tmpNombreCliente As String
   Private _ExistFactBlanco As Boolean = False
   Private _soloProvinciasClienteEmpresa As Boolean = True
   Private _codigoActualCliente As String = String.Empty
   Private _cuitActualCliente As String = String.Empty

   Private _direccionCorregida As Boolean
   Private _clienteUtilizaCalle As Boolean = True

   Private _contactoEditado As DataRow

   Private _titAdjuntos As Dictionary(Of String, String)
   Private _modulosAdic As DataTable
   Private _proximoCodigoClienteTemp As Long
#End Region

   Protected Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

#Region "Constructores"

   Public Sub New(ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto)
      InitializeComponent()
      Me.ModoClienteProspecto = ModoClienteProspecto
   End Sub

   Public Sub New(entidad As Entidades.Cliente)
      Me.New(entidad, Entidades.Cliente.ModoClienteProspecto.Cliente)
   End Sub

   Public Sub New(entidad As Entidades.Cliente, ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto)
      Me.New(ModoClienteProspecto)
      _entidad = entidad
   End Sub
   Public Sub New(entidad As Entidades.Cliente, ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto, validarDireccion As Boolean)
      Me.New(entidad, ModoClienteProspecto)
      _direccionCorregida = validarDireccion
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      TryCatched(
         Sub()
            _clienteUtilizaCalle = Reglas.Publicos.ClienteUtilizaCalle

            If ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Prospecto Then
               Text = Entidades.Cliente.ModoClienteProspecto.Prospecto.ToString()
               chbClienteCtaCte.Text = Entidades.Cliente.ModoClienteProspecto.Prospecto.ToString() + " C.C."
            End If

            txtTelefonos.IsRequired = Reglas.Publicos.ClienteRequiereTelefono
            txtCelular.IsRequired = Reglas.Publicos.ClienteRequiereCelular
            txtCorreoElectronico.IsRequired = Reglas.Publicos.ClienteRequiereCorreoElectronico
            txtCorreoAdministrativo.IsRequired = Reglas.Publicos.ClienteRequiereCorreoAdministrativo

            If _clienteUtilizaCalle Then
               txtDireccion.IsRequired = False
            End If

         End Sub)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _idProvinciaSucursal = actual.Sucursal.LocalidadComercial.IdProvincia

            'Seguridad del Descuento/Recargo General
            Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
            txtDescuentoRecargoPorc.ReadOnly = Not oUsuario.TienePermisos("Clientes-DescRecGeneralPorc")
            '---------------------------------------CargaComboEstadosCiviles

            _publicos = New Publicos()

            _publicos.CargaComboTipoDocumento(Me.cmbTipoDoc, Entidades.Publicos.SiNoTodos.SI)
            'Me._publicos.CargaComboLocalidades(Me.cmbLocalidad)

            _publicos.CargaComboEstadosCiviles(cmbEstadosCiviles)

            _publicos.CargaComboTiposDirecciones(Me.cmbTiposDirecciones)
            _publicos.CargaComboLocalidades(Me.cmbLocalidadTrabajo)
            _publicos.CargaComboCategorias(Me.cmbCategorias)
            _publicos.CargaComboCategoriasFiscales(Me.cmbCategoriaFiscal)
            _publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
            _publicos.CargaComboEmpleados(cmbDadoAltaPor, Entidades.Publicos.TiposEmpleados.TODOS)
            _publicos.CargaComboListaDePrecios(Me.cmbListasDePrecios)

            _publicos.CargaComboEmpleados(Me.cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)
            'seteo el primero del combo para que no molesto el campo nuevo
            If cmbCobrador.Items.Count > 0 Then
               cmbCobrador.SelectedIndex = 0
            End If

            _publicos.CargaComboTipoClientes(Me.cmbTipoCliente)
            'seteo el primero del combo para que no molesto el campo nuevo
            If cmbTipoCliente.Items.Count > 0 Then
               cmbTipoCliente.SelectedIndex = 0
            End If


            _publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, MiraPC:=False, Tipo1:="VENTAS", Tipo2:="", AfectaCaja:="", seleccionMultiple:=False, seleccionTodos:=False, IgnoraSucursal:=True)

            _publicos.CargaComboTiposComprobantes(Me.cmbComprobanteInvocacionMasiva, MiraPC:=False, Tipo1:="VENTAS", Tipo2:="", AfectaCaja:="", seleccionMultiple:=False, seleccionTodos:=False, IgnoraSucursal:=True)

            _publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
            _publicos.CargaComboTiposDeExension(Me.cmbTiposDeExension)
            cmbTiposDeExension.SelectedIndex = -1
            _publicos.CargaComboSucursales(Me.cmbSucursales)
            _publicos.CargaComboEstadosClientes(Me.cmbEstadoCliente)
            cmbEstadoCliente.SelectedIndex = -1
            _publicos.CargaComboTiposContactos(Me.cmbTipoContacto)

            _publicos.CargaComboAFIPConceptoCM05(cmbAFIPConceptoCM05, Entidades.AFIPConceptoCM05.TiposConceptosCM05.INGRESOS)

            'PE-30972
            _publicos.CargaComboCategorias(Me.cmbCambioCategoria)

            _publicos.CargaComboDesdeEnum(cmbActualizadorFunciona, GetType(Entidades.Cliente.FuncionaActualizador))


            Dim blnMiraUsuario As Boolean = False  'Se bien deberia controlarlo a la hora de factura no lo tiene cargado asi que no lograria hacerle un comprobante.
            Dim blnMiraPC As Boolean = False
            Dim blnCajasModificables As Boolean = False
            Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, blnMiraUsuario, blnMiraPC, blnCajasModificables)

            If DirectCast(Me._entidad, Entidades.Cliente).IdClienteGarante <> 0 Then
               Me.chbTieneGarante.Checked = True
            Else
               Me.chbTieneGarante.Checked = False
            End If

            If DirectCast(Me._entidad, Entidades.Cliente).IdClienteCtaCte <> 0 Then
               Me.chbClienteCtaCte.Checked = True
            Else
               Me.chbClienteCtaCte.Checked = False
            End If

            Me.chbEsResidente.Visible = (Publicos.IDAplicacionSinergia = "SICAP")

            Me._originalTipoDocGarante = DirectCast(Me._entidad, Entidades.Cliente).TipoDocumentoGarante
            Me._originalNroDocGarante = DirectCast(Me._entidad, Entidades.Cliente).NroDocumentoGarante

            Me.cmbProvincia.DisplayMember = "NombreProvincia"
            Me.cmbProvincia.ValueMember = "IdProvincia"
            Me.cmbProvincia.DataSource = New Reglas.Provincias().GetAll()
            Me.cmbProvincia.Text = New Reglas.Localidades().GetUna(Publicos.LocalidadEmpresa).NombreProvincia.ToString()

            Me._publicos.CargaComboMotoresDeBaseDeDatos(Me.cboMotorBaseDatos, Me.ModoClienteProspecto)
            Me._publicos.CargaComboBancos(Me.cmbBanco)
            Me._publicos.CargaComboCuentasBancariasClase(Me.cmbCuentaBancariaClase)

            Me._publicos.CargaComboMonedas(Me.cmbMoneda)

            'GAR: 07/03/2018 - No pude hacer andar el Enum. Lo hizo a lo criollo. Perdon! ;-)
            '_publicos.CargaComboDesdeEnum(cboBackupAutoConfig, GetType(Publicos.OpcionesCombo), , True)

            'Dim aOpcionesCombo As ArrayList = New ArrayList
            'aOpcionesCombo.Insert(0, "NO")
            'aOpcionesCombo.Insert(1, "SI")
            'aOpcionesCombo.Insert(2, "Pend.")

            'Me.cboBackupAutoConfig.DataSource = aOpcionesCombo
            'Me.cboBackupAutoConfig.SelectedIndex = 2

            'Me.cboConsultaPreciosConIVA.DataSource = aOpcionesCombo
            'Me.cboConsultaPreciosConIVA.SelectedIndex = 2

            'Me.cboTienePreciosConIVA.DataSource = aOpcionesCombo
            'Me.cboTienePreciosConIVA.SelectedIndex = 2

            'Me.cboTieneServidorDedicado.DataSource = aOpcionesCombo
            'Me.cboTieneServidorDedicado.SelectedIndex = 2

            Me.cboBackupAutoConfig.Items.Insert(0, "NO")
            Me.cboBackupAutoConfig.Items.Insert(1, "SI")
            Me.cboBackupAutoConfig.Items.Insert(2, "Pend.")
            Me.cboBackupAutoConfig.SelectedIndex = 2

            Me.cboConsultaPreciosConIVA.Items.Insert(0, "NO")
            Me.cboConsultaPreciosConIVA.Items.Insert(1, "SI")
            Me.cboConsultaPreciosConIVA.Items.Insert(2, "Pend.")
            Me.cboConsultaPreciosConIVA.SelectedIndex = 2

            Me.cboTienePreciosConIVA.Items.Insert(0, "NO")
            Me.cboTienePreciosConIVA.Items.Insert(1, "SI")
            Me.cboTienePreciosConIVA.Items.Insert(2, "Pend.")
            Me.cboTienePreciosConIVA.SelectedIndex = 2

            Me.cboTieneServidorDedicado.Items.Insert(0, "NO")
            Me.cboTieneServidorDedicado.Items.Insert(1, "SI")
            Me.cboTieneServidorDedicado.Items.Insert(2, "Pend.")
            Me.cboTieneServidorDedicado.SelectedIndex = 2

            'Me._publicos.CargaComboAplicacionesEdiciones(Me.cmbEdicion, Me.cmbAplicaciones.SelectedValue)

            'Me.cmbEdicion.Items.Insert(0, "Sin Asig.")
            'Me.cmbEdicion.Items.Insert(1, "Plus")
            'Me.cmbEdicion.Items.Insert(2, "Express")
            'Me.cmbEdicion.Items.Insert(3, "Básica")
            'Me.cmbEdicion.Items.Insert(4, "P.V.")
            'Me.cmbEdicion.Items.Insert(5, "N/A")


            _publicos.CargaComboAplicaciones(Me.cmbAplicaciones)
            _publicos.CargaComboModulos(cmbModulos)
            _publicos.CargaComboAplicacionesEdiciones(Me.cmbEdicion, DirectCast(Me._entidad, Entidades.Cliente).IdAplicacion)


            _liSources.Add("CategoriaFiscal", DirectCast(Me._entidad, Entidades.Cliente).CategoriaFiscal)
            _liSources.Add("Localidad", DirectCast(Me._entidad, Entidades.Cliente).Localidad)
            _liSources.Add("Vendedor", DirectCast(Me._entidad, Entidades.Cliente).Vendedor)
            _liSources.Add("ZonaGeografica", DirectCast(Me._entidad, Entidades.Cliente).ZonaGeografica)
            _liSources.Add("EstadoCliente", DirectCast(Me._entidad, Entidades.Cliente).EstadoCliente)
            _liSources.Add("TipoCliente", DirectCast(Me._entidad, Entidades.Cliente).TipoCliente)
            _liSources.Add("Cobrador", DirectCast(Me._entidad, Entidades.Cliente).Cobrador)
            _liSources.Add("Banco", DirectCast(Me._entidad, Entidades.Cliente).Banco)
            _liSources.Add("CuentaBancariaClase", DirectCast(Me._entidad, Entidades.Cliente).CuentaBancariaClase)
            _liSources.Add("DadoAltaPor", DirectCast(Me._entidad, Entidades.Cliente).DadoAltaPor)

            _publicos.CargaComboDesdeEnum(CmbAlicuota2deProducto, GetType(Entidades.Cliente.Alicuota2DeProductoSegun))

            _publicos.CargaComboDesdeEnum(cmbSexo, GetType(Entidades.Cliente.SexoOpciones))

            'Me.cmbSexo.Items.Insert(0, "F")
            'Me.cmbSexo.Items.Insert(1, "M")
            'Me.cmbSexo.Items.Insert(2, "Sin Definir")
            'Me.cmbSexo.SelectedIndex = 2

            If Cliente.Activo Then
               Cliente.FechaBaja = dtpFechaBaja.MinDate
            End If

            SetearHorasEnCero()

            BindearControles(_entidad, _liSources)

            If Reglas.Publicos.ClienteUtilizaGeolocalizacion Then
               Me.cmbTipoMapa.Text = "Google Maps"
               GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly
               Me.gmcMapa.SetPositionByKeywords("Rosario, Argentina")
               GMapProvider.Language = LanguageType.Spanish
               Me.gmcMapa.Zoom = 11
               Me.gmcMapa.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance
            End If

            Me._entidad.Usuario = actual.Nombre

            If Not Reglas.Publicos.ClienteTieneTrabajo Then
               Me.tbcCliente.TabPages.Remove(Me.tbpTrabajo)
            End If

            If Not Reglas.Publicos.TieneModuloControlDeLicencias Then
               Me.tbcCliente.TabPages.Remove(Me.tbpLicencias)
            End If

            If Not Reglas.Publicos.ExtrasSinergia Then
               'PE-31191 - No se oculta mas la solapa, sino que se ocultan algunos controles especificos
               'Me.tbcCliente.TabPages.Remove(Me.tbpLicencias)
               Me.tbcCliente.TabPages.Remove(Me.tbpVincularDispositivos)

               Me.lblVencimientoLicencia.Visible = False
               Me.dtpVencimientoLicencia.Visible = False

               'PE-31191 - Controles especificos que se ocultan
               Me.lblTienePreciosConIVA.Visible = False
               Me.cboTienePreciosConIVA.Visible = False
               Me.cboTienePreciosConIVA.Visible = False
               Me.lblConsultaPreciosConIVA.Visible = False
               Me.cboConsultaPreciosConIVA.Visible = False
               Me.lblBackupAutoConfig.Visible = False
               Me.cboBackupAutoConfig.Visible = False
               Me.lblBackupAutomaticoCuenta.Visible = False
               Me.txtBackupAutomaCuenta.Visible = False
               Me.lblBackupNroVersion.Visible = False
               Me.txtBackupNroVersion.Visible = False
               Me.gBoxModulosAdicionales.Visible = False
               Me.ugModulos.Visible = False

               grpBackupAutomatico.Visible = False
               grpActualizadorAutomatico.Visible = False

            End If

            If Not Reglas.Publicos.ClienteTieneGarante Then
               'Me.chbTieneGarante.Visible = False
               'Me.grbGarante.Visible = False
               Me.tbcCliente.TabPages.Remove(Me.tbpGarante)
            End If

            If Not Reglas.Publicos.ClienteUtilizaGeolocalizacion Then
               Me.tbcCliente.TabPages.Remove(Me.tbpMapa)
            End If

            If Not Reglas.Publicos.ClienteTieneMultiplesDirecciones Then
               Me.tbcCliente.TabPages.Remove(Me.tbpDirecciones)
            End If

            If Not Reglas.Publicos.ClienteUtilizaOtros Then
               Me.tbcCliente.TabPages.Remove(Me.tbpOtros)
            End If

            If Not Reglas.Publicos.ClienteUtilizaContactos Then
               Me.tbcCliente.TabPages.Remove(Me.tbpContactos)
            End If

            If Not Reglas.Publicos.ClienteUtilizaAdjuntos Then
               Me.tbcCliente.TabPages.Remove(Me.tbpAduntos)
            End If

            If Not Reglas.Publicos.ClienteUtilizaImpuestos Then
               Me.tbcCliente.TabPages.Remove(Me.tbpImpuestos)
            End If

            If Not Reglas.Publicos.ClienteUtilizaHorarios Then
               Me.tbcCliente.TabPages.Remove(Me.tbpHorarios)
            End If

            If Publicos.ClienteDRporGrabaLibro Then
               Me.lblDescuentoRecargoPorc2.Visible = True
               Me.txtDescuentoRecargoPorc2.Visible = True
            End If

            If Reglas.Publicos.ClienteUtilizaCBU Then
               Me.chkCuentaBancariaGroup.Visible = True
               Me.grbCuentaBancaria.Visible = True
            End If

            'Seguridad del campo Vendedor
            Me._MostrarVendedor = oUsuario.TienePermisos("Clientes-MostrarVendedor")

            If Not Me._MostrarVendedor Then
               Me.cmbVendedor.Visible = False
               Me.lblVendedor.Visible = False
            Else
               Me.cmbVendedor.Visible = True
               Me.lblVendedor.Visible = True
            End If

            Me.tbcCliente.SelectedTab = Me.tbpContactos

            If Me.cmbTipoContacto.Items.Count = 1 Then
               Me.cmbTipoContacto.SelectedIndex = 0
            End If

            Me.tbcCliente.SelectedTab = Me.tbpDatos

            Me.lblCodigoClienteLetras.Visible = Reglas.Publicos.ClienteMuestraCodigoClienteLetras
            Me.txtCodigoClienteLetras.Visible = Reglas.Publicos.ClienteMuestraCodigoClienteLetras

            HabilitaIdImpositivoOtroPais()

            If Reglas.Publicos.IDAplicacionSinergia = "SILIVE" Then
               chbFormaPago.Checked = True
               chbFormaPago.Enabled = False
               chbComprobanteFacturacion.Checked = True
               chbComprobanteFacturacion.Enabled = False
            End If

            If _clienteUtilizaCalle Then
               Dim deltaY = txtAltura.Top - txtDireccionAdicional.Top
               txtDireccionAdicional.Top += deltaY
               lblDireccionAdicional.Top += deltaY

               txtDireccion.ReadOnly = True

               txtDireccionAdicional.TabIndex = txtAltura.TabIndex

               'If Not _direccionCorregida Then
               '   txtDireccion.Text = Cliente.Direccion
               'End If
            Else
               bscCalles.Enabled = False
               lnkCalle.Enabled = False
               txtAltura.Enabled = False
               lblAltura.Enabled = False

            End If


            If Me.StateForm = Eniac.Win.StateForm.Actualizar Then


               Me.chbNumeroAutomatico.Visible = False
               Me.lblNumeroAutomatico.Visible = False

               txtNivelAutorizacion.Visible = oUsuario.TienePermisos("Clientes-NivelAutorizacion")
               txtNivelAutorizacion.LabelAsoc.Visible = txtNivelAutorizacion.Visible


               If ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Prospecto Then
                  Me.btnConvertirEnCliente.Visible = True
               End If

               If CierraAutomaticamente And DirectCast(Me._entidad, Entidades.Cliente).ModificarDatos = False Then
                  Me.btnAceptar.Enabled = False
               End If

               ''Me.CmbAlicuota2deProducto.SelectedText = DirectCast(Me._entidad, Entidades.Cliente).Alicuota2deProducto

               ''Se usa en las pantallas que llaman directamente al editar.
               'Me.txtCodigoCliente.Tag = DirectCast(Me._entidad, Entidades.Cliente).IdCliente
               Me.cmbTipoDoc.Text = DirectCast(Me._entidad, Entidades.Cliente).TipoDocCliente

               _tmpNombreCliente = DirectCast(Me._entidad, Entidades.Cliente).NombreCliente

               Dim rVenta As Reglas.Ventas = New Reglas.Ventas()
               'Verifico si tiene alguna venta el cliente en blanco
               _ExistFactBlanco = rVenta.ClientePoseeFacturas(DirectCast(Me._entidad, Entidades.Cliente).IdCliente)
               If _ExistFactBlanco And ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente Then

                  cmbTipoDoc.Enabled = False
                  txtNroDoc.ReadOnly = True

                  'Verifico si el cuit es valido
                  If Not String.IsNullOrWhiteSpace(txtCUIT.Text) AndAlso Publicos.EsCuitValido(txtCUIT.Text) Then
                     'Si es valido lo no permito que se cambie. Si es invalido lo dejo editar para subsanar el error
                     Me.txtCUIT.ReadOnly = True
                  Else
                     If txtNroDoc.Text = "0" Then
                        cmbTipoDoc.Enabled = True
                        txtNroDoc.ReadOnly = False
                     End If
                  End If

                  'If IsNumeric(txtNroDoc.Text) AndAlso Long.Parse(Me.txtNroDoc.Text) <> 0 Then
                  'Si el número de documento es diferente de cero (0) no lo dejo modificar

                  'Else
                  '   'Si el número de documento es cero (0) lo permito modificar
                  '   cmbTipoDoc.Enabled = True
                  '   Me.txtNroDoc.ReadOnly = False
                  'End If
               End If

               CargarActividades()
               CargarDirecciones()
               CargarContactos()
               CargarModulosAdic()

               If _clienteUtilizaCalle Then
                  bscCodigoCalles.Visible = True
                  'bscCodigoCalles.Text = Cliente.Calle.IdCalle.ToString()
                  'bscCodigoCalles.PresionarBoton()

                  bscCalles.Text = Cliente.Calle.NombreCalle
                  bscCodigoCalles.Text = Cliente.Calle.IdCalle.ToString()

                  bscCalles.Selecciono = True
                  bscCodigoCalles.Selecciono = True

               End If

               If DirectCast(Me._entidad, Entidades.Cliente).IdSucursalAsociada > 0 Then
                  Me.cmbSucursales.SelectedItem = DirectCast(Me._entidad, Entidades.Cliente).IdSucursalAsociada
               End If

               If DirectCast(Me._entidad, Entidades.Cliente).IdCaja > 0 Then
                  Me.cmbCajas.SelectedItem = DirectCast(Me._entidad, Entidades.Cliente).IdCaja
               End If

               If DirectCast(Me._entidad, Entidades.Cliente).Vendedor.IdEmpleado > 0 Then
                  Me.cmbVendedor.SelectedItem = DirectCast(Me._entidad, Entidades.Cliente).Vendedor
               End If

               cmbMoneda.SelectedValue = DirectCast(Me._entidad, Entidades.Cliente).MonedaCredito

               If DirectCast(Me._entidad, Entidades.Cliente).Cobrador.IdEmpleado > 0 Then
                  Me.cmbCobrador.SelectedItem = DirectCast(Me._entidad, Entidades.Cliente).Cobrador
               End If

               ' Carga la lista de precios del cliente
               Me.cmbListasDePrecios.SelectedValue = DirectCast(Me._entidad, Entidades.Cliente).IdListaPrecios

               Me.tbcCliente.SelectedTab = Me.tbpFoto
               Me.pcbFoto.Image = DirectCast(Me._entidad, Entidades.Cliente).Foto

               'Navego los tabs para activar los controles combobox y que luego se validen, sino, no sucede.
               Me.tbcCliente.SelectedTab = Me.tbpOtros

               If Not String.IsNullOrEmpty(Me.txtCBU.Text) Or Not String.IsNullOrEmpty(Me.txtNumeroCuentaBancaria.Text) Or
                     Me.cmbCuentaBancariaClase.SelectedIndex > -1 Or Me.cmbBanco.SelectedIndex > -1 Then
                  Me.chkCuentaBancariaGroup.Checked = True
               End If

               If DirectCast(Me._entidad, Entidades.Cliente).IdTipoComprobante <> "" Then
                  Me.chbComprobanteFacturacion.Checked = True
               End If

               If DirectCast(Me._entidad, Entidades.Cliente).IdTipoComprobanteInvocacionMasiva <> "" Then
                  Me.chbComprobanteInvocacionMasiva.Checked = True
               End If

               If DirectCast(Me._entidad, Entidades.Cliente).IdFormasPago <> 0 Then
                  Me.chbFormaPago.Checked = True
               End If

               chbAFIPConceptoCM05.Checked = Cliente.IdConceptoCM05.HasValue

               If Not Reglas.Publicos.AFIPUtilizaCM05 Then
                  chbAFIPConceptoCM05.Checked = False
                  chbAFIPConceptoCM05.Enabled = False
               End If

               If DirectCast(Me._entidad, Entidades.Cliente).IdTransportista <> 0 Then
                  Me.bscCodigoTransportista.Text = DirectCast(Me._entidad, Entidades.Cliente).IdTransportista.ToString()
                  Me.bscCodigoTransportista.PresionarBoton()
                  Me.bscNombreTransportista.Selecciono = True
                  Me.chbTransportista.Checked = True
               End If

               If DirectCast(Me._entidad, Entidades.Cliente).NumeroLote > 0 Then
                  Me.txtNumeroLote.Text = DirectCast(Me._entidad, Entidades.Cliente).NumeroLote.ToString()
                  Me.chbNumeroLote.Checked = True
               End If

               If DirectCast(Me._entidad, Entidades.Cliente).VarPesosCotizDolar <> 0 Then
                  Me.txtVariacionDolarSistema.Text = DirectCast(Me._entidad, Entidades.Cliente).VarPesosCotizDolar.ToString()
                  Me.chbVariacionDolarSistema.Checked = True
               End If

               Me.chbAsociaSucursal.Checked = Me.cmbSucursales.SelectedIndex >= 0

               Me.chbAsociaSucursal.Visible = Reglas.Publicos.ClienteTieneSucursalAsociada
               Me.cmbSucursales.Visible = Reglas.Publicos.ClienteTieneSucursalAsociada

               Me.chbCaja.Checked = Me.cmbCajas.SelectedIndex >= 0

               Me.tbcCliente.SelectedTab = Me.tbpGarante
               'Por algun motivo aun bindeado, esto no carga el valor.
               'me.txtNroDocGarante.Text.Length
               If DirectCast(Me._entidad, Entidades.Cliente).IdClienteGarante <> 0 Then
                  Dim Garante As Entidades.Cliente = New Reglas.Clientes(ModoClienteProspecto)._GetUno(DirectCast(Me._entidad, Entidades.Cliente).IdClienteGarante)
                  Me.bscCodigoGarante.Text = Garante.CodigoCliente.ToString()
                  Me.bscGarante.Text = Garante.NombreCliente
                  Me._validaGarante = True
               End If

               If DirectCast(Me._entidad, Entidades.Cliente).IdClienteCtaCte <> 0 Then
                  Dim ClienteCtaCte As Entidades.Cliente = New Reglas.Clientes(ModoClienteProspecto)._GetUno(DirectCast(Me._entidad, Entidades.Cliente).IdClienteCtaCte)
                  Me.bscCodigoClienteCtaCte.Text = ClienteCtaCte.CodigoCliente.ToString()
                  Me.bscNombreClienteCtaCte.Text = ClienteCtaCte.NombreCliente
               End If

               Me.tbcCliente.SelectedTab = Me.tbpTrabajo

               Me.tbcCliente.SelectedTab = Me.tbpMapa


               If Reglas.Publicos.ClienteUtilizaGeolocalizacion Then
                  ' Me.tbcCliente.SelectedTab = Me.tbpUbicacion
                  If DirectCast(Me._entidad, Entidades.Cliente).GeoLocalizacionLat <> 0 Then
                     Me.Ubicacion()
                  End If
               End If


               Me.tbcCliente.SelectedTab = Me.tbpLicencias

               Me.cmbAplicaciones.SelectedValue = DirectCast(Me._entidad, Entidades.Cliente).IdAplicacion
               Me.cmbEdicion.SelectedValue = DirectCast(Me._entidad, Entidades.Cliente).Edicion

               SetValorAComboSiNoPend(Cliente.BackupAutoConfig, Me.cboBackupAutoConfig)
               SetValorAComboSiNoPend(Cliente.TienePreciosConIVA, Me.cboTienePreciosConIVA)
               SetValorAComboSiNoPend(Cliente.ConsultaPreciosConIVA, Me.cboConsultaPreciosConIVA)
               SetValorAComboSiNoPend(Cliente.TieneServidorDedicado, Me.cboTieneServidorDedicado)

               If Not Cliente.Activo Then
                  dtpFechaBaja.Value = Cliente.FechaBaja
               End If

               Me.tbcCliente.SelectedTab = Me.tbpDatos
               Me.bscCodigoLocalidad.PresionarBoton()
               Me.bscCodigoZonaGeografica.PresionarBoton()

               'If ModoClienteProspecto <> Entidades.Cliente.ModoClienteProspecto.Prospecto Then
               '   Me.dtpFechaAlta.Enabled = False
               'End If

               SetLocalidadContactoDefault()

               If Reglas.Publicos.TieneModuloContabilidad Then
                  UcCuentas1.Cuenta = DirectCast(Me._entidad, Entidades.Cliente).CuentaContable
               Else
                  grpContabilidad.Visible = False
               End If

               MostrarCodigos()

               txtCodigoCliente.Enabled = Reglas.Publicos.ClientePermiteModificarCodigo

               txtCodigoClienteLetras.Enabled = Reglas.Publicos.ClientePermiteModificarCodigo

               chbEsClienteGenerico.Enabled = Not New Reglas.Ventas().ClientePoseeFacturas(DirectCast(Me._entidad, Entidades.Cliente).IdCliente, grabaLibro:=Nothing)

               Me._codigoActualCliente = txtCodigoCliente.Text
               Me._cuitActualCliente = txtCUIT.Text

               Me.txtDescuentoRecargoPorc.Text = DirectCast(_entidad, Entidades.Cliente).DescuentoRecargoPorc.ToString()
               Me.txtDescuentoRecargoPorc2.Text = DirectCast(_entidad, Entidades.Cliente).DescuentoRecargoPorc2.ToString()

               'PE-30972
               If DirectCast(Me._entidad, Entidades.Cliente).IdCategoriaCambio <> 0 Then
                  Me.chbCambioCategoria.Checked = True
               End If
            Else
               _direccionCorregida = True

               cmbEstadosCiviles.SelectedIndex = 0
               'Insertar
               If _domicilios IsNot Nothing Then
                  Me.CargarDirecciones()
               End If
               '-- REQ-34505.- -------------------------------------------------------------
               chbPublicarEnWeb.Checked = Reglas.Publicos.AltaNuevoClientePublicarenWeb
               '----------------------------------------------------------------------------

               cmbMoneda.SelectedValue = Entidades.Moneda.Peso

               Me.chbNumeroAutomatico.Checked = True

               'Me.cmbTipoDoc.Text = Publicos.TipoDocumentoCliente()  'Puerdo que calculo el maximo codigo.
               Me.chbModificarDatos.Visible = False
               DirectCast(Me._entidad, Entidades.Cliente).ModificarDatos = True

               Me.ChequeaEstructuraActividades()

               Me.ChequeaEstructuraDirecciones()

               Me.ChequeaEstructuraContactos()

               Me.ChequeaEstructuraModulosAdicionales()

               Me.chbActivo.Checked = True

               Me.ChbRepartoIndep.Checked = False

               Me.chbRecibeNotificaciones.Checked = True

               Me.tbcCliente.SelectedTab = Me.tbpOtros

               Me.tbcCliente.SelectedTab = Me.tbpDatos

               If Me.cmbCategorias.Items.Count = 1 Then
                  Me.cmbCategorias.SelectedIndex = 0
               Else
                  If Eniac.Reglas.Publicos.ClienteCategoriaPorDefecto = 0 Then
                     Me.cmbCategorias.SelectedIndex = -1
                  Else
                     Me.cmbCategorias.SelectedValue = Eniac.Reglas.Publicos.ClienteCategoriaPorDefecto
                  End If
               End If

               If DirectCast(Me._entidad, Entidades.Cliente).CategoriaFiscal.IdCategoriaFiscal > 0 Then
                  Me.cmbCategoriaFiscal.SelectedValue = DirectCast(Me._entidad, Entidades.Cliente).CategoriaFiscal.IdCategoriaFiscal
               Else
                  If Eniac.Reglas.Publicos.ClienteCategoriaFiscalPorDefecto = 0 Then
                     Me.cmbCategoriaFiscal.SelectedIndex = -1
                  Else
                     Me.cmbCategoriaFiscal.SelectedValue = Eniac.Reglas.Publicos.ClienteCategoriaFiscalPorDefecto
                     DirectCast(Me._entidad, Entidades.Cliente).CategoriaFiscal = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)
                  End If
               End If


               ' Forzar la selección de una Lista de Precios
               'If DirectCast(Me._entidad, Entidades.Cliente).IdCategoriaFiscal > 0 Then
               '   Me.cmbCategoriaFiscal.SelectedValue = DirectCast(Me._entidad, Entidades.Cliente).IdCategoriaFiscal
               'End If

               If Reglas.Publicos.ForzarListaDePreciosCliente Then
                  cmbListasDePrecios.SelectedIndex = -1
               Else
                  ' Comportamiento normal cuando el parámetro de forzar no se encuentra tildado
                  If cmbListasDePrecios.Items.Count = 1 Then
                     cmbListasDePrecios.SelectedIndex = 0
                  Else
                     If Eniac.Reglas.Publicos.ClienteListaDePreciosPorDefecto = 0 Then
                        cmbListasDePrecios.SelectedValue = Publicos.ListaPreciosPredeterminada
                     Else
                        Me.cmbListasDePrecios.SelectedValue = Eniac.Reglas.Publicos.ClienteListaDePreciosPorDefecto
                     End If
                  End If
               End If

               If cmbVendedor.Items.Count = 1 Then
                  cmbVendedor.SelectedIndex = 0
                  DirectCast(Me._entidad, Entidades.Cliente).Vendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado)
               Else
                  If Not Me._MostrarVendedor Then
                     Me.cmbVendedor.SelectedIndex = 0
                     DirectCast(Me._entidad, Entidades.Cliente).Vendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado)
                  Else
                     If Eniac.Reglas.Publicos.ClienteVendedorPorDefecto = 0 Then
                        Me.cmbVendedor.SelectedIndex = -1
                     Else
                        Me.cmbVendedor.SelectedValue = Eniac.Reglas.Publicos.ClienteVendedorPorDefecto
                        DirectCast(Me._entidad, Entidades.Cliente).Vendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado)
                     End If

                  End If

               End If

               ' Me.tbcCliente.SelectedTab = Me.tbpUbicacion

               'Me.bscCodigoLocalidad.Text = actual.Sucursal.Localidad.IdLocalidad.ToString()
               If bscCodigoLocalidad.Text = "0" Then
                  Me.bscCodigoLocalidad.Text = actual.Sucursal.LocalidadComercial.IdLocalidad.ToString()
               End If
               Me.bscCodigoLocalidad.PresionarBoton()

               Using dtZG = New Reglas.ZonasGeograficas().GetAll()
                  If dtZG.Count = 1 Then
                     bscCodigoZonaGeografica.Text = dtZG.AsEnumerable().First().Field(Of String)(Entidades.ZonaGeografica.Columnas.IdZonaGeografica.ToString())
                     bscCodigoZonaGeografica.PresionarBoton()
                  Else
                     If Reglas.Publicos.ClienteZonaGeograficaPorDefecto.ValorNumericoPorDefecto(0I) > 0 Then
                        bscCodigoZonaGeografica.Text = Eniac.Reglas.Publicos.ClienteZonaGeograficaPorDefecto
                        bscCodigoZonaGeografica.PresionarBoton()
                     End If
                  End If
               End Using

               If Me.cmbEstadoCliente.Items.Count = 1 Then
                  Me.cmbEstadoCliente.SelectedIndex = 0
               End If

               If Me.cmbCobrador.Items.Count = 1 Then
                  Me.cmbCobrador.SelectedIndex = 0
                  DirectCast(Me._entidad, Entidades.Cliente).Cobrador = DirectCast(Me.cmbCobrador.SelectedItem, Entidades.Empleado)
               Else
                  If Eniac.Reglas.Publicos.ClienteCobradorPorDefecto <> 0 Then
                     Me.cmbCobrador.SelectedValue = Eniac.Reglas.Publicos.ClienteCobradorPorDefecto
                     DirectCast(Me._entidad, Entidades.Cliente).Cobrador = DirectCast(Me.cmbCobrador.SelectedItem, Entidades.Empleado)
                  Else
                     Me.cmbCobrador.SelectedIndex = -1
                  End If
               End If

               If Me.cmbTipoCliente.Items.Count = 1 Then
                  Me.cmbTipoCliente.SelectedIndex = 0
               Else
                  If Eniac.Reglas.Publicos.ClienteTipoPorDefecto <> 0 Then
                     Me.cmbTipoCliente.SelectedValue = Eniac.Reglas.Publicos.ClienteTipoPorDefecto
                  End If
               End If

               Me.dtpFechaNacimiento.Value = DirectCast(Me._entidad, Entidades.Cliente).FechaNacimiento
               'Me.dtpFechaNacimiento.Value = Date.Parse("1900-01-01")

               '# Se habilita siempre para los nuevos clientes
               Me.chbHabilitarVisitas.Checked = True

               txtCantidadVisitas.Text = Reglas.Publicos.ClienteCantidadVisitasPorDefecto.ToString()

               If Reglas.Publicos.TieneModuloContabilidad Then
                  UcCuentas1.Cuenta = Nothing
               Else
                  grpContabilidad.Visible = False
               End If

               Me.CargarProximoCodigo()

               If Reglas.Publicos.IDAplicacionSinergia <> "SILIVE" Then
                  cmbDadoAltaPor.SetSelectedIndexSecure(0)
               End If

            End If

            bscCodigoCalles.Visible = False

            If cmbTipoDoc.SelectedIndex < 0 Then
               cmbTipoDoc.SelectedValue = Reglas.Publicos.TipoDocumentoCliente
            End If

            Dim curTP As TabPage = tbcCliente.SelectedTab
            tbcCliente.SelectedTab = tbpAduntos
            _titAdjuntos = GetColumnasVisiblesGrilla(ugAdjunto)

            tbcCliente.SelectedTab = tbpImpuestos
            chbInscriptoIB.Enabled = True
            chbInscriptoIB.Checked = Reglas.Publicos.RetieneIIBB AndAlso DirectCast(Me._entidad, Entidades.Cliente).CategoriaFiscal.EsPasiblePercIIBB
            chbInscriptoIB.Enabled = False

            tbcCliente.SelectedTab = tbpDescuentos
            Dim rClteDescMarcas = New Reglas.ClientesDescuentosMarcas()
            ugDescuentosMarcas.DataSource = rClteDescMarcas.GetClientesDescuentosMarcas(If(StateForm = StateForm.Insertar, -1L, Cliente.IdCliente), False)

            Dim rClteDescRubros = New Reglas.ClientesDescuentosRubros()
            ugDescuentosRubros.DataSource = rClteDescRubros.GetClientesDescuentosRubros(If(StateForm = StateForm.Insertar, -1L, Cliente.IdCliente), False)

            Dim rClteDescProdus = New Reglas.ClientesDescuentosProductos()
            ugDescuentosProductos.DataSource = rClteDescProdus.GetClientesDescuentosProductos(If(StateForm = StateForm.Insertar, -1L, Cliente.IdCliente), False)

            _publicos.CargaComboMarcas(cmbMarcas)
            _publicos.CargaComboRubros(cmbRubros)

            ugDescuentosMarcas.AgregarFiltroEnLinea({"NombreMarca"})
            ugDescuentosRubros.AgregarFiltroEnLinea({"NombreRubro"})
            ugDescuentosProductos.AgregarFiltroEnLinea({"NombreProducto"})

            tbcCliente.SelectedTab = curTP
            ugAdjunto.DataSource = Cliente.Adjuntos
            AjustarColumnasGrilla(ugAdjunto, _titAdjuntos)

            dtpFechaBaja.Enabled = Not chbActivo.Checked

            CmbAlicuota2deProducto.Enabled = Reglas.Publicos.ProductoUtilizaAlicuota2


            Me._estaCargando = False

            If Not Reglas.Publicos.ExtrasSinergia Then
               Me.chbActualizarAplicacion.Visible = True
               Me.chbControlarBackup.Visible = True
               Me.chbUtilizaAppSoporte.Visible = True
            End If

            If Not New Reglas.Usuarios().TienePermisos("PuedeVerDetalleEstrellas") Then
               txtValorizacionFacturacionMensual.Visible = False
               txtValorizacionCoeficienteFacturacion.Visible = False
               txtValorizacionFacturacion.Visible = False
               txtValorizacionImporteAdeudado.Visible = False
               txtValorizacionCoeficienteDeuda.Visible = False
               txtValorizacionDeuda.Visible = False
               txtValorizacionProyecto.Visible = False
               txtValorizacionCliente.Visible = False

               lblValorizacionFacturacionMensual.Visible = False
               lblValorizacionCoeficienteFacturacion.Visible = False
               lblValorizacionFacturacion.Visible = False
               lblValorizacionImporteAdeudado.Visible = False
               lblValorizacionCoeficienteDeuda.Visible = False
               lblValorizacionDeuda.Visible = False
               lblValorizacionProyecto.Visible = False
               lblValorizacionCliente.Visible = False
            End If
         End Sub)
   End Sub

   Private Sub SetValorAComboSiNoPend(valor As Boolean?, combo As Eniac.Controles.ComboBox)
      'GAR: 07/03/2018 - No toma el SelectedValue. Cosa rara.
      If valor.HasValue Then
         If valor.Value Then
            'combo.SelectedValue = "SI"
            combo.SelectedIndex = 1
         Else
            'combo.SelectedValue = "NO"
            combo.SelectedIndex = 0
         End If
      Else
         'combo.SelectedValue = "Pend."
         combo.SelectedIndex = 2
      End If
   End Sub

   Private Function GetValorDeComboSiNoPend(combo As Eniac.Controles.ComboBox) As Boolean?
      If combo.SelectedItem IsNot Nothing Then
         If combo.SelectedItem.ToString() = "SI" Then
            '   If combo.SelectedItem.ToString() = "SI" Then
            Return True
         ElseIf combo.SelectedItem.ToString() = "NO" Then
            Return False
         End If
      End If
      Return Nothing
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Clientes(ModoClienteProspecto)
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If _contactoEditado IsNot Nothing Then
         If Boolean.Parse(_contactoEditado("EnUso").ToString()) Then
            Me.tbcCliente.SelectedTab = Me.tbpContactos
            Me.btnInsertarContacto.Focus()
            Return "Está editando un contacto ya utilizado. Por favor vuelva a agregar el mismo."
         End If
      End If

      'Dim vacio As String = ""

      'valido que si la categoria fiscal solicita CUIT controle que el campo de CUIT lo haya cargado en el ABM
      Dim result As Reglas.Validaciones.ValidacionResult
      result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() _
                                                                                With {.IdFiscal = txtCUIT.Text,
                                                                                      .SolicitaCUIT = DirectCast(Me._entidad, Entidades.Cliente).CategoriaFiscal.SolicitaCUIT And
                                                                                                       Me.ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente})
      If result.Error Then
         tbcCliente.SelectedTab = Me.tbpDatos
         txtCUIT.Focus()
         Return result.MensajeError
      End If

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

      If Long.Parse("0" & Me.txtNroDoc.Text) > 0 And Me.cmbTipoDoc.SelectedIndex = -1 Then
         Return "Falta Indicar el Tipo de Documento."
      End If

      If Long.Parse("0" & Me.txtNroDoc.Text) <> 0 And Me.cmbTipoDoc.SelectedIndex <> -1 Then
         If Long.Parse(Me.txtNroDoc.Text.ToString()) < 100000 Then
            Return "Numero de documento no válido"
         End If
      End If

      If Not Me.bscCodigoLocalidad.Selecciono And Not Me.bscNombreLocalidad.Selecciono Then
         Me.tbcCliente.SelectedTab = Me.tbpDatos
         Me.bscCodigoLocalidad.Focus()
         Return "No selecciono la Localidad."
      End If

      If _clienteUtilizaCalle Then
         If Not bscCalles.Selecciono Then
            tbcCliente.SelectedTab = tbpDatos
            bscCalles.Focus()
            Return "No selecciono una Calle."
         End If

         If Not _DireccionCorregida Then
            Dim direccionVerificar = Cliente.Calle.NombreCalle & " " & Cliente.Altura.ToString() & " " & Cliente.DireccionAdicional
            If direccionVerificar <> txtDireccion.Text Then
               If ShowPregunta("ATENCION: Existen campos inconsistente en la ubicación, verificar los campos de lo contrario limpia la ubicación actual. " & vbNewLine + vbNewLine & " ¿ Desea Continuar ?") = Windows.Forms.DialogResult.Yes Then
                  Return String.Empty
               Else
                  tbcCliente.SelectedTab = tbpDatos
                  bscCalles.Focus()
                  Return "Operación Cancelada por el usuario"
               End If
            End If
         End If

      End If


      If Me.cmbListasDePrecios.SelectedIndex = -1 Then
         Me.cmbListasDePrecios.Focus()
         Return "No selecciono una Lista de Precios"
      End If

      If Me.bscCodigoGarante.Text = Me.txtCodigoCliente.Text Then
         Return "El Garante NO puede COINCIDIR con el Cliente."
      End If

      If Not Me._validaGarante And Me.bscCodigoGarante.Text <> "" Then
         Return "Debe validar el Garante antes de aceptar."
      End If

      If Me.chbAsociaSucursal.Checked And Me.cmbSucursales.SelectedIndex = -1 Then
         Me.cmbSucursales.Focus()
         Return "ATENCION: Activo la Sucursal Asociada. Debe elegir una."
      End If

      If Me.chbAsociaSucursal.Checked And chbAsociaSucursal.Visible Then
         If cmbSucursales.ValorSeleccionado(Of Integer) = actual.Sucursal.Id Then
            cmbSucursales.Focus()
            Return "ATENCION: No puede elegir la misma Sucursal que la activa."
         End If

         If cmbSucursales.ValorSeleccionado(Of Integer) = actual.Sucursal.IdSucursalAsociada Then
            cmbSucursales.Focus()
            Return "ATENCION: No puede elegir la misma Sucursal que la Asociada a la Sucursal."
         End If
      End If

      If Me.chbComprobanteFacturacion.Checked And Me.cmbTiposComprobantes.SelectedIndex = -1 Then
         Me.cmbTiposComprobantes.Focus()
         Return "ATENCION: Activo el Comprobante de Facturación por Defecto. Debe elegir uno."
      End If

      If Me.chbComprobanteInvocacionMasiva.Checked And Me.cmbComprobanteInvocacionMasiva.SelectedIndex = -1 Then
         Me.cmbComprobanteInvocacionMasiva.Focus()
         Return "ATENCION: Activo el Comprobante para Invocacion Masiva. Debe elegir uno."

      End If

      If Me.chbFormaPago.Checked And Me.cmbFormaPago.SelectedIndex = -1 Then
         Me.cmbFormaPago.Focus()
         Return "ATENCION: Activo la Forma de Pago por Defecto. Debe elegir una."
      End If

      If Me.chbTransportista.Checked And Not Me.bscNombreTransportista.Selecciono Then
         Me.bscNombreTransportista.Focus()
         Return "ATENCION: Activo el Trtansportista por Defecto. Debe elegir una."
      End If
      If Me.chbInscriptoIB.Checked Then
         If Me.rbtLocal.Checked = False And Me.rbtConvMultilateral.Checked = False Then
            Return "Activó Inscripto Ingresos Brutos, debe seleccionar una opción."
            Me.tbpImpuestos.Show()
         End If
      End If

      If Me.chbInscriptoIB.Checked And Me.dgvDetalle.RowCount = 0 Then
         Me.tbcCliente.SelectedTab = Me.tbpImpuestos
         Return "Activó Inscripto Ingresos Brutos, debe cargar la Actividad"
      End If

      If chbAFIPConceptoCM05.Checked And cmbAFIPConceptoCM05.SelectedIndex = -1 Then
         tbcCliente.SelectedTab = tbpImpuestos
         cmbAFIPConceptoCM05.Select()
         Return "ATENCION: Activo el Concepto de CM05 pero no seleccionó uno. Debe elegir una."
      End If


      If Me.chbNumeroLote.Checked And Me.txtNumeroLote.Text = "" Then
         Me.bscNombreTransportista.Focus()
         Return "ATENCION: Activo el Lote por Defecto. Debe ingresar uno."
      End If

      If Me.chbVariacionDolarSistema.Checked And Me.txtVariacionDolarSistema.Text = "" Then
         Me.txtVariacionDolarSistema.Focus()
         Return "ATENCION: Activó la variación del dólar. Debe ingresar una."
      End If

      If Me.chbClienteCtaCte.Checked And Me.bscNombreClienteCtaCte.Text = "" Then
         Me.bscNombreClienteCtaCte.Focus()
         Return "ATENCION: Activo el Cliente de Cta. Cte. Debe ingresar uno."
      End If

      If Me.cmbEstadoCliente.SelectedItem Is Nothing Then
         Me.cmbEstadoCliente.Focus()
         Return "ATENCION: Debe indicar un Estado de Cliente."
      End If

      If Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing AndAlso
          Reglas.Publicos.RetieneIIBB AndAlso DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).EsPasiblePercIIBB Then
         If _soloProvinciasClienteEmpresa Then
            Dim dt As DataTable = New Reglas.ClientesActividades().GetClientesActividades(DirectCast(Me._entidad, Entidades.Cliente).IdCliente,
                                                                                          _idProvinciaCliente,
                                                                                          DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IdCategoriaFiscal)

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

      '**** VALIDAR HORARIOS  **** 
      'Lunes a Viernes
      If Me.dtpHoraHasta.Enabled Then
         If Me.dtpHoraDesde.Value > Me.dtpHoraHasta.Value Then
            Me.dtpHoraHasta.Focus()
            Return "Lunes a Viernes: La Hora Desde 1 No puede ser mayor a Hasta."
         End If
         If Me.dtpHoraDesde2.Value > Me.dtpHoraHasta2.Value Then
            Me.dtpHoraHasta2.Focus()
            Return "Lunes a Viernes: La Hora Desde 2 No puede ser mayor a Hasta."
         End If
      End If
      If Me.chbHorarioCorrido.Checked Then
         If Me.dtpHoraDesde.Value.TimeOfDay.ToString = "00:00:00" Or Me.dtpHoraHasta2.Value.TimeOfDay.ToString = "00:00:00" Then
            Me.dtpHoraDesde.Focus()
            Return "Lunes a Viernes: El horario corrido es incorrecto."
         End If
         If Me.dtpHoraDesde.Value > Me.dtpHoraHasta2.Value Then
            Me.dtpHoraDesde.Focus()
            Return "Lunes a Viernes: El horario corrido es incorrecto."
         End If
      End If

      'Lunes a Viernes
      If Me.dtpHoraSabHasta.Enabled Then
         If Me.dtpHoraSabDesde.Value > Me.dtpHoraSabHasta.Value Then
            Me.dtpHoraSabHasta.Focus()
            Return "Sabado: La Hora Desde 1 No puede ser mayor a Hasta."
         End If
         If Me.dtpHoraSabDesde2.Value > Me.dtpHoraSabHasta2.Value Then
            Me.dtpHoraSabHasta2.Focus()
            Return "Sabado: La Hora Desde 2 No puede ser mayor a Hasta."
         End If
      End If
      If Me.chbHorarioCorridoSab.Checked Then
         If Me.dtpHoraSabDesde.Value.TimeOfDay.ToString = "00:00:00" Or Me.dtpHoraSabHasta2.Value.TimeOfDay.ToString = "00:00:00" Then
            Me.dtpHoraSabDesde.Focus()
            Return "Sabado: El horario corrido es incorrecto."
         End If
         If Me.dtpHoraSabDesde.Value > Me.dtpHoraSabHasta2.Value Then
            Me.dtpHoraSabDesde.Focus()
            Return "Sabado: El horario corrido es incorrecto."
         End If
      End If

      'Domingo
      If Me.dtpHoraDomHasta.Enabled Then
         If Me.dtpHoraDomDesde.Value > Me.dtpHoraDomHasta.Value Then
            Me.dtpHoraDomHasta.Focus()
            Return "Domingo: La Hora Desde 1 No puede ser mayor a Hasta."
         End If
         If Me.dtpHoraDomDesde2.Value > Me.dtpHoraDomHasta2.Value Then
            Me.dtpHoraDomHasta2.Focus()
            Return "Domingo: La Hora Desde 2 No puede ser mayor a Hasta."
         End If
      End If
      If Me.chbHorarioCorridoDom.Checked Then
         If Me.dtpHoraDomDesde.Value.TimeOfDay.ToString = "00:00:00" Or Me.dtpHoraDomHasta2.Value.TimeOfDay.ToString = "00:00:00" Then
            Me.dtpHoraDomDesde.Focus()
            Return "Domingo: El horario corrido es incorrecto."
         End If
         If Me.dtpHoraDomDesde.Value > Me.dtpHoraDomHasta2.Value Then
            Me.dtpHoraDomDesde.Focus()
            Return "Domingo: El horario corrido es incorrecto."
         End If
      End If

      If Me.chkCuentaBancariaGroup.Checked Then
         If Not String.IsNullOrEmpty(Me.txtCBU.Text.Trim()) AndAlso Me.txtCBU.Text.Trim() <> "0" AndAlso Me.txtCBU.Text.Trim().Length <> 22 Then
            Return "El CBU es Inválido, debe contener 22 digitos y es de " & Me.txtCBU.Text.Trim.Length.ToString() & "'."
            Exit Function
         End If

         If Not String.IsNullOrEmpty(Me.txtCBU.Text) AndAlso Me.txtCBU.Text <> "0" AndAlso Me.cmbBanco.SelectedIndex = -1 Then
            Return "Cargo un CBU Pero no indico el Banco."
            Exit Function
         End If

         If Not String.IsNullOrEmpty(Me.txtCBU.Text.Trim()) AndAlso Me.txtCBU.Text.Trim() <> "0" AndAlso Integer.Parse(Me.txtCBU.Text.Trim().Substring(0, 3)) <> Integer.Parse(Me.cmbBanco.SelectedValue.ToString()) Then
            Return "El Banco del CBU (los primeros 3 digitos) NO coincide con el Banco."
            Exit Function
         End If

         If Not String.IsNullOrEmpty(Me.txtCBU.Text) AndAlso Me.txtCBU.Text <> "0" AndAlso Me.cmbCuentaBancariaClase.SelectedIndex = -1 Then
            Return "Cargo un CBU Pero no indico la clase de Cuenta."
            Exit Function
         End If

         result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() _
                                                                                   With {.IdFiscal = txtCuitCtaBancaria.Text,
                                                                                         .SolicitaCUIT = DirectCast(Me._entidad, Entidades.Cliente).CategoriaFiscal.SolicitaCUIT And
                                                                                                         Me.ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente})
         If result.Error Then
            tbcCliente.SelectedTab = Me.tbpOtros
            txtCuitCtaBancaria.Focus()
            Return result.MensajeError
         End If
      End If

      '**************************

      If Not String.IsNullOrEmpty(Me.txtVersionNro.Text.Trim()) And Not Me.dtpFechaActualizacion.Checked Then
         Return "ATENCION: Indico el Numero de Version pero falta cargar la Fecha de Actualizacion."
      End If

      If Me.cboBackupAutoConfig.Text = "SI" And String.IsNullOrEmpty(Me.txtBackupAutomaCuenta.Text.Trim()) Then
         Return "ATENCION: Indico que tiene Backup automatico pero falta cargar la cuenta de correo asociada."
      End If

      If Me.cboBackupAutoConfig.Text = "SI" And String.IsNullOrEmpty(Me.txtBackupNroVersion.Text.Trim()) Then
         Return "ATENCION: Indico que tiene Backup automatico pero falta cargar el Numero de Version."
      End If

      'If Me.chbAplicacion.Checked And Me.cmbAplicaciones.SelectedIndex = -1 Then
      '   Me.cmbAplicaciones.Focus()
      '   Return "ATENCION: Activo la Aplicacion. Debe elegir una."
      'End If

      'If Me.chbEdicion.Checked And Me.cmbEdicion.SelectedIndex = -1 Then
      '   Me.cmbEdicion.Focus()
      '   Return "ATENCION: Activo la Edicion. Debe elegir una."
      'End If

      If Me.tbcCliente.TabPages.Contains(Me.tbpLicencias) Then

         If Me.cmbAplicaciones.SelectedIndex = -1 Then
            Me.cmbAplicaciones.Focus()
            Return "ATENCION: Debe elegir una Aplicacion."
         End If

         If Me.cmbEdicion.SelectedIndex = -1 Then
            Me.cmbEdicion.Focus()
            Return "ATENCION: Debe elegir una Edicion."
         End If
      End If

      If String.IsNullOrEmpty(bscCodigoZonaGeografica.Text) Or String.IsNullOrEmpty(bscNombreZonaGeografica.Text) Then
         tbcCliente.SelectedTab = tbpDatos
         bscCodigoZonaGeografica.Focus()
         Return "Debe elegir una Zona Geográfica."
      End If

      If txtNivelAutorizacion.Visible Then
         If Not IsNumeric(txtNivelAutorizacion.Text) Then txtNivelAutorizacion.Text = "1"
         If Short.Parse(txtNivelAutorizacion.Text) > actual.NivelAutorizacion Then
            tbcCliente.SelectedTab = tbpDatos
            Me.txtNivelAutorizacion.Focus()
            Return "ATENCION: El nivel de autorización ingresado es superior al suyo."
         End If         'If Short.Parse(txtNivelAutorizacion.Text) > actual.NivelAutorizacion Then
      End If

      '   Dim dt1 As DataTable = New Reglas.Clientes().GetFiltradoPorCodigoClienteLetras(Me.txtCodigoClienteLetras.Text.Trim())

      'PE-30972
      If chbCambioCategoria.Checked Then
         If String.IsNullOrEmpty(cmbCambioCategoria.Text) Then
            cmbCambioCategoria.Focus()
            Return "ATENCION: Activó el Cambio de Categoría. Debe elegir una. "
         End If
      End If


      'Return vacio
      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()

      If Me.StateForm = Win.StateForm.Actualizar Then
         If (_tmpNombreCliente <> txtNombre.Text) And (_ExistFactBlanco = True) And (ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente) Then
            If MessageBox.Show("El cliente tiene registradas facturas, desea  cambiar el nombre de cliente", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
               HayError = True
               Exit Sub
            End If
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

         'PE-30972
         If Me.chbCambioCategoria.Checked Then
            DirectCast(Me._entidad, Entidades.Cliente).FechaCambioCategoria = Me.dtpFechaCambioCategoria.Value
         End If
      End If

      '-.PE-32383.-
      'Valido si Existe por Tipo/Nro. Documento.
      If txtNroDoc.ValorNumericoPorDefecto(0L) <> 0 Then
         Dim clientesLiviandos = New Reglas.Clientes().GetClientesLiviando(cmbTipoDoc.ValorSeleccionado(Of String),
                                                                           txtNroDoc.ValorNumericoPorDefecto(0L))
         Dim miIdCliente = If(StateForm = StateForm.Insertar, 0L, Cliente.IdCliente)
         If clientesLiviandos.Exists(Function(c) c.IdCliente <> miIdCliente) Then
            Dim stb = New StringBuilder()
            stb.AppendFormatLine("Los siguientes clientes ya están cargados con {0} {1}",
                                 cmbTipoDoc.ValorSeleccionado(Of String), txtNroDoc.ValorNumericoPorDefecto(0L)).AppendLine()
            clientesLiviandos.Where(Function(c) c.IdCliente <> miIdCliente).All(
               Function(c)
                  stb.AppendFormatLine("    {0} - {1}", c.CodigoCliente, c.NombreCliente)
                  Return True
               End Function)
            stb.AppendLine().AppendFormat("¿Desea continuar?")
            If ShowPregunta(stb.ToString(), MessageBoxDefaultButton.Button2) = DialogResult.No Then
               txtNroDoc.Focus()
               HayError = True
               Exit Sub
            End If
         End If
      End If


      '# Vuelvo a validar los horarios por si no fueron actualizados
      HorarioClienteCompleto()

      Cliente.Actividades = _actividades
      Cliente.Direcciones = _direcciones
      Cliente.Contactos = _contactos
      Cliente.ContactosBorrados = _contactosBorrados
      Cliente.ModulosAdic = _modulosAdic

      Cliente.DescuentosDataSet = New DataSet().Add("DescuentosMarcas", ugDescuentosMarcas.DataSource(Of DataTable).Copy()).
                                                Add("DescuentosRubros", ugDescuentosRubros.DataSource(Of DataTable).Copy()).
                                                Add("DescuentosProductos", ugDescuentosProductos.DataSource(Of DataTable).Copy())

      If Me.cmbEdicion.SelectedValue IsNot Nothing Then
         DirectCast(Me._entidad, Entidades.Cliente).Edicion = Me.cmbEdicion.SelectedValue.ToString()
      End If
      If Me.cmbAplicaciones.SelectedValue IsNot Nothing Then
         DirectCast(Me._entidad, Entidades.Cliente).IdAplicacion = Me.cmbAplicaciones.SelectedValue.ToString()
      End If

      If chbActivo.Checked Then
         Cliente.FechaBaja = Nothing
      End If

      If Not dtpFechaSUS.Checked Then
         Cliente.FechaSUS = Nothing
      End If

      ' Lista de Precios asociada al cliente
      DirectCast(Me._entidad, Entidades.Cliente).IdListaPrecios = cmbListasDePrecios.ValorSeleccionado(Of Integer)

      ''DirectCast(Me._entidad, Entidades.Cliente).Alicuota2deProducto = Me.CmbAlicuota2deProducto.Text

      Cliente.IdConceptoCM05 = cmbAFIPConceptoCM05.ValorSeleccionado(Of Integer?)(chbAFIPConceptoCM05, Nothing)
      'If chbAFIPConceptoCM05.Checked Then
      '   Cliente.IdConceptoCM05 = cmbAFIPConceptoCM05.ValorSeleccionado(Of Integer?)()
      'Else
      '   Cliente.IdConceptoCM05 = Nothing
      'End If

      If chbCertificadoMiPyme.Checked Then
         Cliente.FechaDesdeCertificado = dtpFechaDesdeCertificado.Value
         Cliente.FechaHastaCertificado = dtpFechaHastaCertificado.Value
      Else
         Cliente.FechaDesdeCertificado = Nothing
         Cliente.FechaHastaCertificado = Nothing
      End If

      If Not Me.chbInscriptoIB.Checked Then
         Cliente.IdTipoDeExension = -1
      End If

      btnGeolocalizar.PerformClick()

      If Not Me.dtpFechaInicio.Checked Then
         DirectCast(Me._entidad, Entidades.Cliente).FechaInicio = Nothing
      End If
      If Not Me.dtpFechaInicioReal.Checked Then
         DirectCast(Me._entidad, Entidades.Cliente).FechaInicioReal = Nothing
      End If
      If Not Me.dtpFechaActualizacion.Checked Then
         DirectCast(Me._entidad, Entidades.Cliente).FechaActualizacionVersion = Nothing
      End If
      If Not Me.dtpVencimientoLicencia.Checked Then
         DirectCast(Me._entidad, Entidades.Cliente).VencimientoLicencia = Nothing
      End If

      If Not Me.dtpActualizadorFechaInstalacion.Checked Then
         DirectCast(Me._entidad, Entidades.Cliente).ActualizadorFechaInstalacion = Nothing
      End If

      DirectCast(Me._entidad, Entidades.Cliente).MotorBaseDatos = Me.cboMotorBaseDatos.Text

      'Campos SILIVE
      DirectCast(Me._entidad, Entidades.Cliente).VerEnConsultas = True
      If Not _clienteUtilizaCalle Then
         DirectCast(Me._entidad, Entidades.Cliente).Calle = New Reglas.Calles().GetUna(1)
         DirectCast(Me._entidad, Entidades.Cliente).Altura = 0
      End If
      DirectCast(Me._entidad, Entidades.Cliente).Calle2 = New Reglas.Calles().GetUna(1)
      DirectCast(Me._entidad, Entidades.Cliente).Altura2 = 0
      'DirectCast(Me._entidad, Entidades.Cliente).DadoAltaPor = DirectCast(Me._entidad, Entidades.Cliente).Vendedor
      DirectCast(Me._entidad, Entidades.Cliente).Direccion2 = "."
      DirectCast(Me._entidad, Entidades.Cliente).IdLocalidad2 = 2000

      'GAR: 07/03/2018 - Tal vez cambia con el Enum.

      Cliente.BackupAutoConfig = GetValorDeComboSiNoPend(cboBackupAutoConfig)
      Cliente.TienePreciosConIVA = GetValorDeComboSiNoPend(cboTienePreciosConIVA)
      Cliente.ConsultaPreciosConIVA = GetValorDeComboSiNoPend(cboConsultaPreciosConIVA)
      Cliente.TieneServidorDedicado = GetValorDeComboSiNoPend(cboTieneServidorDedicado)

      If Reglas.Publicos.TieneModuloContabilidad Then
         DirectCast(_entidad, Entidades.Cliente).CuentaContable = UcCuentas1.Cuenta
      Else
         DirectCast(_entidad, Entidades.Cliente).CuentaContable = Nothing
      End If

      If Long.Parse(txtCodigoCliente.Text) = _proximoCodigoClienteTemp Then
         DirectCast(Me._entidad, Entidades.Cliente).CodigoCliente = 0
      End If

      DirectCast(_entidad, Entidades.Cliente).DescuentoRecargoPorc = txtDescuentoRecargoPorc.ValorNumericoPorDefecto(0D)
      DirectCast(_entidad, Entidades.Cliente).DescuentoRecargoPorc2 = txtDescuentoRecargoPorc2.ValorNumericoPorDefecto(0D)

      MyBase.Aceptar()

      If Not Me.HayError Then Me.Close()

      '# Vuelvo a asignar el Código de Cliente(temporal) para que no se visualice un 0 en pantalla.
      If Not Me.StateForm = Win.StateForm.Actualizar Then
         '-- REQ-36033.- -----------------------------------------------------------------------------
         If DirectCast(Me._entidad, Entidades.Cliente).CodigoCliente < _proximoCodigoClienteTemp Then
            DirectCast(Me._entidad, Entidades.Cliente).CodigoCliente = _proximoCodigoClienteTemp
         End If
         '--------------------------------------------------------------------------------------------
         Me.txtCodigoCliente.Focus()
      End If

   End Sub

   'Protected Overrides Sub LimpiarControles()
   '   MyBase.LimpiarControles()
   '   Me.cmbTipoDoc.Text = Publicos.TipoDocumentoCliente()
   '   Me.cmbLocalidad.SelectedIndex = -1
   '   Me.cmbZonaGeografica.SelectedIndex = -1
   '   Me.cmbCategoriaFiscal.SelectedIndex = -1
   '   Me.cmbCategorias.SelectedIndex = -1
   '   Me.cmbVendedor.SelectedIndex = -1
   '   Me.cmbListasDePrecios.SelectedIndex = 0   'Pongo la lista Base.
   '   Me.cmbLocalidadTrabajo.SelectedIndex = -1
   '   Me.chbActivo.Checked = True
   'End Sub

#End Region

#Region "Eventos"
   Private Sub Horarios_Leave(sender As Object, e As EventArgs) Handles dtpHoraDesde.Leave,
      dtpHoraHasta.Leave, dtpHoraDesde2.Leave, dtpHoraHasta2.Leave,
      dtpHoraSabDesde.Leave, dtpHoraSabHasta.Leave, dtpHoraSabDesde2.Leave, dtpHoraSabHasta2.Leave,
      dtpHoraDomDesde.Leave, dtpHoraDomHasta.Leave, dtpHoraDomDesde2.Leave, dtpHoraDomHasta2.Leave,
      chbHorarioCorrido.CheckedChanged, chbHorarioCorridoSab.CheckedChanged, chbHorarioCorridoDom.CheckedChanged
      Try
         Me.HorarioClienteCompleto()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ClientesDetalle_Shown(sender As Object, e As EventArgs) Handles Me.Shown
      Try
         If Me.StateForm = Eniac.Win.StateForm.Actualizar Then
            If DirectCast(Me._entidad, Entidades.Cliente).Vendedor.IdEmpleado > 0 Then
               Me.cmbVendedor.SelectedItem = Me.GetVendedorCombo(DirectCast(Me._entidad, Entidades.Cliente).Vendedor.IdEmpleado)
            End If
            If DirectCast(Me._entidad, Entidades.Cliente).Cobrador.IdEmpleado > 0 Then
               Me.cmbCobrador.SelectedItem = Me.GetCobradorCombo(DirectCast(Me._entidad, Entidades.Cliente).Cobrador.IdEmpleado)
            End If
            Me.txtNombre.Focus()
         Else
            Me.txtCodigoCliente.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   'AR: NO APLICA MAS
   Private Sub cmbTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDoc.SelectedIndexChanged

      '   If Me.cmbTipoDoc.SelectedIndex >= 0 And Me.StateForm = Eniac.Win.StateForm.Insertar Then

      '      Dim oRegTipoDoc As Reglas.TiposDocumento = New Reglas.TiposDocumento()
      '      Dim oTipoDoc As Entidades.TipoDocumento

      '      oTipoDoc = oRegTipoDoc.GetUno(Me.cmbTipoDoc.SelectedValue)

      '      If oTipoDoc.EsAutoincremental Then
      '         Dim oRegCliente As Reglas.Clientes = New Reglas.Clientes()
      '         Dim ProximoCliente As Long
      '             ProximoCliente = oRegCliente.GetCodigoClienteMaximo(Me.cmbTipoDoc.SelectedValue) + 1
      '         Me.txtNroDoc.Text = ProximoCliente.ToString()
      '      Else
      '         Me.txtNroDoc.Text = "0"
      '      End If

      '   End If

   End Sub

   'AR: NO APLICA MAS
   Private Sub txtNroDoc_LostFocus(sender As Object, e As EventArgs) Handles txtNroDoc.LostFocus
      'If Me.StateForm = Eniac.Win.StateForm.Insertar And (Me.cmbTipoDoc.Text = "CUIL" Or Me.cmbTipoDoc.Text = "CUIT") Then
      '   Me.txtCUIT.Text = Me.txtNroDoc.Text
      'End If
   End Sub

   Private Sub lnkLocalidad_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkLocalidad.LinkClicked
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

   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidad)
         Me.bscCodigoLocalidad.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidad.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.bscCodigoZonaGeografica.Focus()
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
            Me.bscCodigoZonaGeografica.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#Region "Eventos Busqueda Calle"
   Private Sub bscCodigoCalles_BuscadorClick() Handles bscCodigoCalles.BuscadorClick
      TryCatched(
      Sub()
         Dim oCalles = New Reglas.Calles()
         _publicos.PreparaGrillaCalles(bscCalles)

         Dim idLoca = bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I)
         bscCalles.Datos = oCalles.GetPorId(bscCodigoCalles.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscCalles_BuscadorClick() Handles bscCalles.BuscadorClick
      TryCatched(
      Sub()
         Dim oCalles = New Reglas.Calles()
         _publicos.PreparaGrillaCalles(bscCalles)

         Dim idLoca = bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I)
         bscCalles.Datos = oCalles.GetPorLocalidadYNombre(idLoca, bscCalles.Text)
      End Sub)
   End Sub
   Private Sub bscCalles_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCalles.BuscadorSeleccion, bscCalles.BuscadorSeleccion
      TryCatched(
      Sub()
         If e.FilaDevuelta IsNot Nothing Then
            Dim calle = New Reglas.Calles().GetUna(Integer.Parse(e.FilaDevuelta.Cells("IdCalle").Value.ToString()))
            bscCalles.Text = calle.NombreCalle
            bscCodigoCalles.Text = calle.IdCalle.ToString()

            bscCalles.Selecciono = True
            bscCodigoCalles.Selecciono = True

            Cliente.Calle = calle
         End If
      End Sub)
   End Sub
   Private Sub lnkCalle_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCalle.LinkClicked
      TryCatched(
      Sub()
         bscCodigoCalles.Text = String.Empty
         Dim calle = New Entidades.Calle()
         If Not String.IsNullOrWhiteSpace(bscNombreLocalidad.Text) Then
            calle.Localidad = New Eniac.Reglas.Localidades().GetUna(Integer.Parse(bscCodigoLocalidad.Text.ToString()))
         End If
         Using frmCalles = New CallesDetalle(calle)
            frmCalles.StateForm = StateForm.Insertar
            If frmCalles.ShowDialog() = Windows.Forms.DialogResult.OK Then
               If calle IsNot Nothing Then
                  bscCodigoLocalidad.Text = frmCalles._idLocalidad.ToString()
                  bscCodigoCalles.Text = frmCalles._idCalle.ToString()
                  bscCodigoCalles.PresionarBoton()
               End If
            End If
         End Using
      End Sub)
   End Sub

#End Region

   Private Sub chbTieneGarante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTieneGarante.CheckedChanged

      Me.grbGarante.Enabled = Me.chbTieneGarante.Checked
      'Lo limpio para qie se grabe en la base.
      If Not Me.chbTieneGarante.Checked Then
         Me.bscCodigoGarante.Text = String.Empty
         Me.bscCodigoGarante.Tag = Nothing

         Me.bscGarante.Text = String.Empty

         Me._validaGarante = False
         DirectCast(Me._entidad, Entidades.Cliente).IdClienteGarante = 0

      End If

   End Sub

   Private Sub cmbVendedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVendedor.SelectedIndexChanged
      Try
         If Not Me._estaCargando Then
            If Me.cmbVendedor.SelectedIndex <> -1 Then
               DirectCast(Me._entidad, Entidades.Cliente).Vendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado)
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbAsociaSucursal_CheckedChanged(sender As Object, e As EventArgs) Handles chbAsociaSucursal.CheckedChanged
      If Not Me.chbAsociaSucursal.Checked Then
         Me.cmbSucursales.SelectedIndex = -1
         DirectCast(Me._entidad, Entidades.Cliente).IdSucursalAsociada = 0
      End If
      Me.cmbSucursales.Enabled = Me.chbAsociaSucursal.Checked
   End Sub

   Private Sub chbComprobanteFacturacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbComprobanteFacturacion.CheckedChanged

      If Not Me.chbComprobanteFacturacion.Checked Then
         Me.cmbTiposComprobantes.SelectedIndex = -1
         DirectCast(Me._entidad, Entidades.Cliente).IdTipoComprobante = ""
      End If

      Me.cmbTiposComprobantes.Enabled = Me.chbComprobanteFacturacion.Checked

      If Me.chbComprobanteFacturacion.Checked Then
         Me.cmbTiposComprobantes.Focus()
      End If

   End Sub

   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged

      If Not Me.chbFormaPago.Checked Then
         Me.cmbFormaPago.SelectedIndex = -1
         DirectCast(Me._entidad, Entidades.Cliente).IdFormasPago = 0
      End If

      Me.cmbFormaPago.Enabled = Me.chbFormaPago.Checked

      If Me.chbFormaPago.Checked Then
         Me.cmbFormaPago.Focus()
      End If

   End Sub

   Private Sub chbAFIPConceptoCM05_CheckedChanged(sender As Object, e As EventArgs) Handles chbAFIPConceptoCM05.CheckedChanged

      If Not chbAFIPConceptoCM05.Checked Then
         cmbAFIPConceptoCM05.SelectedIndex = -1
         Cliente.IdConceptoCM05 = Nothing
      End If

      cmbAFIPConceptoCM05.Enabled = chbAFIPConceptoCM05.Checked

      If chbAFIPConceptoCM05.Checked Then
         cmbAFIPConceptoCM05.Select()
      End If

   End Sub

   Private Sub chbTransportista_CheckedChanged(sender As Object, e As EventArgs) Handles chbTransportista.CheckedChanged

      If Not Me.chbTransportista.Checked Then
         Me.bscCodigoTransportista.Text = ""
         Me.bscNombreTransportista.Text = ""
         DirectCast(Me._entidad, Entidades.Cliente).IdTransportista = 0
      End If

      Me.bscNombreTransportista.Enabled = Me.chbTransportista.Checked

      If Me.chbTransportista.Checked Then
         Me.bscNombreTransportista.Focus()
      End If

   End Sub

   Private Sub bscCodigoTransportista_BuscadorClick() Handles bscCodigoTransportista.BuscadorClick
      Try
         Me._publicos.PreparaGrillaTransportistas(Me.bscCodigoTransportista)
         Dim oTransportistas As Reglas.Transportistas = New Reglas.Transportistas
         Me.bscCodigoTransportista.Datos = oTransportistas.GetFiltradoPorCodigo(Long.Parse("0" & Me.bscCodigoTransportista.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoTransportista_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoTransportista.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTransportista(e.FilaDevuelta)
            Me.btnAceptar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreTransportista_BuscadorClick() Handles bscNombreTransportista.BuscadorClick
      Try
         Me._publicos.PreparaGrillaTransportistas(Me.bscNombreTransportista)
         Dim oTransportistas As Reglas.Transportistas = New Reglas.Transportistas
         Me.bscNombreTransportista.Datos = oTransportistas.GetFiltradoPorNombre(Me.bscNombreTransportista.Text.Trim(), True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub bscNombreTransportista_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreTransportista.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTransportista(e.FilaDevuelta)
            Me.btnAceptar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         '  Me.Nuevo()
      End Try
   End Sub

   Private Sub chbCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chbCaja.CheckedChanged
      If Not Me.chbCaja.Checked Then
         Me.cmbCajas.SelectedIndex = -1
         DirectCast(Me._entidad, Entidades.Cliente).IdCaja = 0
      End If
      Me.cmbCajas.Enabled = Me.chbCaja.Checked()
   End Sub

   Private Sub btnLimpiarImagen_Click(sender As Object, e As EventArgs) Handles btnLimpiarImagen.Click
      Try
         DirectCast(Me._entidad, Entidades.Cliente).Foto = Nothing
         Me.pcbFoto.Image = Nothing
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBuscarImagen_Click(sender As Object, e As EventArgs) Handles btnBuscarImagen.Click
      Try
         If Me.ofdArchivos.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.ofdArchivos.FileName) Then
               If System.IO.File.ReadAllBytes(Me.ofdArchivos.FileName).Length > Reglas.Publicos.TamañoMaximoImagenes Then
                  MessageBox.Show("El tamaño de la imagen no puede ser mayor a " + (Reglas.Publicos.TamañoMaximoImagenes / 1000).ToString() + "KB", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
               Me.pcbFoto.Image = New System.Drawing.Bitmap(Me.ofdArchivos.FileName)
               DirectCast(Me._entidad, Entidades.Cliente).Foto = Me.pcbFoto.Image
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkTipoCliente_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTipoCliente.LinkClicked
      Try
         Dim PantTiposClientes As TiposClientesDetalle = New TiposClientesDetalle(New Entidades.TipoCliente())
         PantTiposClientes.StateForm = Win.StateForm.Insertar
         PantTiposClientes.CierraAutomaticamente = True
         If PantTiposClientes.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me._publicos.CargaComboTipoClientes(Me.cmbTipoCliente)
            Me.cmbTipoCliente.SelectedValue = PantTiposClientes.IdTipoCliente
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
            If MessageBox.Show("Esta seguro de eliminar la Actividad seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.cmbProvincia.Focus()
               Me.EliminarLineaActividad()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscActividades_BuscadorClick() Handles bscActividades.BuscadorClick
      Try
         Me._publicos.PreparaGrillaActividades(Me.bscActividades)
         Dim oActividades As Reglas.Actividades = New Reglas.Actividades
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

   Private Sub chbLote_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroLote.CheckedChanged
      If Not Me.chbNumeroLote.Checked Then
         Me.txtNumeroLote.Text = ""
         DirectCast(Me._entidad, Entidades.Cliente).NumeroLote = 0
      End If

      Me.txtNumeroLote.Enabled = Me.chbNumeroLote.Checked

      If Me.chbNumeroLote.Checked Then
         Me.txtNumeroLote.Focus()
      End If
   End Sub

   Private Sub cmbTipoMapa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoMapa.SelectedIndexChanged
      Try
         Select Case Me.cmbTipoMapa.Text
            Case "Google Maps"
               Me.gmcMapa.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance
            Case "Google Satelite Maps"
               Me.gmcMapa.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance
            Case Else
         End Select
         ' Me.gmcMapa.ReloadMap()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnGeolocalizar_Click(sender As Object, e As EventArgs) Handles btnGeolocalizar.Click
      Me.CargarMapa()
   End Sub

   Private Sub tcbZoom_Scroll(sender As Object, e As EventArgs) Handles tcbZoom.Scroll
      Me.gmcMapa.Zoom = Me.tcbZoom.Value
   End Sub

   Private Sub txtDireccion_TextChanged(sender As Object, e As EventArgs) Handles txtDireccion.TextChanged
      If Not _estaCargando Then
         Me.txtGeoLocalizacionLat.Text = "0"
         Me.txtGeoLocalizacionLng.Text = "0"
      End If
   End Sub

   Private Sub cmbCategoriaFiscal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoriaFiscal.SelectedIndexChanged
      If Me._estaCargando Then Exit Sub
      DirectCast(Me._entidad, Entidades.Cliente).CategoriaFiscal = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)
      Me.CargarActividades()
      chbInscriptoIB.Enabled = True
      chbInscriptoIB.Checked = Reglas.Publicos.RetieneIIBB AndAlso DirectCast(Me._entidad, Entidades.Cliente).CategoriaFiscal.EsPasiblePercIIBB
      chbInscriptoIB.Enabled = False
   End Sub

   Private Sub bscCodigoGarante_BuscadorClick() Handles bscCodigoGarante.BuscadorClick
      Dim codigoGarante As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoGarante)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes(ModoClienteProspecto)
         If Me.bscCodigoGarante.Text.Trim.Length > 0 Then
            codigoGarante = Long.Parse(Me.bscCodigoGarante.Text.Trim())
         End If
         Me.bscCodigoGarante.Datos = oClientes.GetFiltradoPorCodigo(codigoGarante, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoGarante_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoGarante.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosGarante(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscGarante_BuscadorClick() Handles bscGarante.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscGarante)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes(ModoClienteProspecto)
         Me.bscGarante.Datos = oClientes.GetFiltradoPorNombre(Me.bscGarante.Text.Trim(), True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscGarante_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscGarante.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosGarante(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkLocalidadDir_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkLocalidadDir.LinkClicked
      Try
         Dim PantLocalidad As LocalidadesDetalle = New LocalidadesDetalle(New Entidades.Localidad())
         PantLocalidad.StateForm = Win.StateForm.Insertar
         PantLocalidad.CierraAutomaticamente = True
         If PantLocalidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoLocalidadDir.Text = PantLocalidad.IdLocalidad.ToString()
            Me.bscCodigoLocalidadDir.PresionarBoton()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidadDir_BuscadorClick() Handles bscCodigoLocalidadDir.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidadDir)
         Me.bscCodigoLocalidadDir.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidadDir.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidadDir_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidadDir.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidadDir(e.FilaDevuelta)
         End If
         Me.btnInsertarDir.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidadDir_BuscadorClick() Handles bscNombreLocalidadDir.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscNombreLocalidadDir)
         Me.bscNombreLocalidadDir.Datos = oLocalidades.GetPorNombre(Me.bscNombreLocalidadDir.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidadDir_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreLocalidadDir.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidadDir(e.FilaDevuelta)
         End If
         Me.btnInsertarDir.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Public Sub btnInsertarDir_Click(sender As Object, e As EventArgs) Handles btnInsertarDir.Click
      Try
         If Me.bscCodigoLocalidadDir.Text <> "" Then
            If txtDirecciones.Text <> "" Then
               AgregarDireccion()
               RefrescarDirecciones()

            Else
               MessageBox.Show("No ingreso la Dirección", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         Else
            MessageBox.Show("No ingreso la Localidad", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarDir_Click(sender As Object, e As EventArgs) Handles btnEliminarDir.Click
      Try
         If Me.dgvDirecciones.SelectedRows.Count > 0 Then
            If StateForm = StateForm.Actualizar Then
               Dim rCD = New Reglas.ClientesDirecciones()
               Dim idDireccion = Integer.Parse(dgvDirecciones.SelectedRows(0).Cells("ugDirIdDireccion").Value.ToString())
               rCD.PuedoBorrarDireccion(Cliente.IdCliente, idDireccion)

            End If
            If MessageBox.Show("Esta seguro de eliminar la Dirección seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               EliminarLineaDireccion()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnRefreshDir_Click(sender As Object, e As EventArgs) Handles btnRefreshDir.Click
      TryCatched(
         Sub()
            ChcBxMantener.Checked = False
            RefrescarDirecciones()
         End Sub)
   End Sub

   Private Sub chbClienteCtaCte_CheckedChanged(sender As Object, e As EventArgs) Handles chbClienteCtaCte.CheckedChanged
      If Not Me.chbClienteCtaCte.Checked Then
         Me.bscCodigoClienteCtaCte.Text = ""
         Me.bscNombreClienteCtaCte.Text = ""
         DirectCast(Me._entidad, Entidades.Cliente).IdClienteCtaCte = 0
      End If
      Me.bscCodigoClienteCtaCte.Enabled = Me.chbClienteCtaCte.Checked
      Me.bscNombreClienteCtaCte.Enabled = Me.chbClienteCtaCte.Checked

      If Me.chbClienteCtaCte.Checked Then
         Me.bscCodigoClienteCtaCte.Focus()
      End If
   End Sub

   Private Sub bscCodigoClienteCtaCte_BuscadorClick() Handles bscCodigoClienteCtaCte.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoClienteCtaCte)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes(ModoClienteProspecto)
         If Me.bscCodigoClienteCtaCte.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoClienteCtaCte.Text.Trim())
         End If
         Me.bscCodigoClienteCtaCte.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoClienteCtaCte.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteCtaCte(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreClienteCtaCte_BuscadorClick() Handles bscNombreClienteCtaCte.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscNombreClienteCtaCte)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes(ModoClienteProspecto)
         Me.bscNombreClienteCtaCte.Datos = oClientes.GetFiltradoPorNombre(Me.bscNombreClienteCtaCte.Text.Trim(), True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreClienteCtaCte_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreClienteCtaCte.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteCtaCte(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvDirecciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDirecciones.CellDoubleClick
      TryCatched(
         Sub()
            LimpiarCampos()
            CargarLineaCompleta(dgvDirecciones.Rows(e.RowIndex))
            EliminarLinea()
         End Sub)
   End Sub

   Private Sub btnConvertirEnCliente_Click(sender As Object, e As EventArgs) Handles btnConvertirEnCliente.Click
      Try

         Dim MensajeAlerta As String

         MensajeAlerta = Me.ValidarClienteDesdeProspecto()

         If MensajeAlerta <> "" Then
            MessageBox.Show(MensajeAlerta, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
         End If

         'Valido si Existe por CUIT o Tipo/Nro. Documento.

         Dim oCLi As Reglas.Clientes = New Reglas.Clientes()
         If Me.txtCUIT.Text <> "" Then
            Dim C1 As Entidades.Cliente = oCLi.GetUnoPorCUIT(Me.txtCUIT.Text)
            If C1 IsNot Nothing Then
               MessageBox.Show("El Cliente ya existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If
         Else
            If Long.Parse("0" & Me.txtNroDoc.Text) <> 0 Then
               Dim C2 As Entidades.Cliente = oCLi.GetUnoPorTipoYNroDocumento(Me.cmbTipoDoc.SelectedValue.ToString(), Long.Parse(Me.txtNroDoc.Text.ToString()))
               If C2 IsNot Nothing Then
                  MessageBox.Show("El Cliente ya Existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
            End If
         End If
         '-----------------------------------------------

         If MessageBox.Show("¿Esta Seguro de Grabar el Prospecto como Cliente?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim oCLi1 As Reglas.Clientes = New Reglas.Clientes()
            Dim Cliente As Entidades.Cliente = New Entidades.Cliente()
            Cliente = DirectCast(Me._entidad, Entidades.Cliente)
            Dim ProximoCliente As Long
            ProximoCliente = oCLi1.GetCodigoClienteMaximo(Entidades.Cliente.Columnas.CodigoCliente.ToString()) + 1
            Cliente.IdCliente = ProximoCliente
            Cliente.CodigoCliente = ProximoCliente
            Cliente.CodigoClienteLetras = ProximoCliente.ToString()
            Cliente.Cuit = Me.txtCUIT.Text
            Cliente.TipoDocCliente = Me.cmbTipoDoc.SelectedValue.ToString()
            Cliente.NroDocCliente = Long.Parse(txtNroDoc.Text)
            Cliente.FechaAlta = Date.Now
            Cliente.Contactos = Me._contactos
            Cliente.Actividades = Me._actividades
            Cliente.Direcciones = Me._direcciones
            Cliente.ModulosAdic = Me._modulosAdic
            If Cliente.IdClienteCtaCte > 0 Then
               If MessageBox.Show("El Prospecto posee un Prospecto Vinculado, de grabar perdera la vinculación. ¿Desea Continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                  Cliente.IdClienteCtaCte = Nothing
               Else
                  Exit Sub
               End If
            End If

            oCLi1.Insertar(Cliente)
            MessageBox.Show("El Cliente se ingresó correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub txtCUIT_Leave(sender As Object, e As EventArgs) Handles txtCUIT.Leave
      Try

         If txtCUIT.Text <> "" Then
            Dim cl As Entidades.Cliente = New Reglas.Clientes().GetUnoPorCUIT(txtCUIT.Text)
            If Me.StateForm = Eniac.Win.StateForm.Actualizar Then
               If cl IsNot Nothing AndAlso cl.CodigoCliente <> Long.Parse(txtCodigoCliente.Text) Then
                  ShowMessage(String.Format(My.Resources.RTextos.CuitAsignadoOtro, "cliente", cl.NombreCliente, cl.CodigoCliente))
               End If
            ElseIf Me.StateForm = Eniac.Win.StateForm.Insertar Then
               If cl IsNot Nothing Then
                  ShowMessage(String.Format(My.Resources.RTextos.CuitAsignadoOtro, "cliente", cl.NombreCliente, cl.CodigoCliente))
               End If
            End If
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnInsertarContacto_Click(sender As Object, e As EventArgs) Handles btnInsertarContacto.Click
      Try
         If Me.txtNombreContacto.Text <> "" Then
            If Me.cmbTipoContacto.SelectedIndex <> -1 Then
               If Me.bscCodigoLocalidadContacto.Selecciono Or Me.bscNombreLocalidadContacto.Selecciono Then
                  Me.AgregarContacto()
                  Me.RefrescarContactos()
               Else
                  MessageBox.Show("No selecciono la Localidad del Contacto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.bscCodigoLocalidadContacto.Focus()
               End If
            Else
               MessageBox.Show("No selecciono el tipo de Contacto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.cmbTipoContacto.Focus()
            End If
         Else
            MessageBox.Show("No ingreso el nombre del Contacto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNombreContacto.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarContacto_Click(sender As Object, e As EventArgs) Handles btnEliminarContacto.Click
      Try
         If Me.dgvContactos.SelectedRows.Count > 0 Then
            'solo controlo si esta en uso si es un Cliente, para un Prospecto no es necesario
            If ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente Then
               If Boolean.Parse(dgvContactos.SelectedRows(0).Cells("EnUso").Value.ToString()) Then
                  ShowMessage("El contacto que desea eliminar ya fue utilizado. No es posible eliminarlo. Podrá inactivar el mismo si así lo desea.")
                  Exit Sub
               End If
            End If
            If MessageBox.Show("Esta seguro de eliminar el Contacto seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaContacto(False)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnRefrescarContacto_Click(sender As Object, e As EventArgs) Handles btnRefrescarContacto.Click
      Try
         Me.RefrescarContactos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidadContacto_BuscadorClick() Handles bscCodigoLocalidadContacto.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidadContacto)
         Me.bscCodigoLocalidadContacto.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidadContacto.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidadContacto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidadContacto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidadContacto(e.FilaDevuelta)
         End If
         Me.txtTelefonoContacto.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidadContacto_BuscadorClick() Handles bscNombreLocalidadContacto.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscNombreLocalidadContacto)
         Me.bscNombreLocalidadContacto.Datos = oLocalidades.GetPorNombre(Me.bscNombreLocalidadContacto.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidadContacto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreLocalidadContacto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidadContacto(e.FilaDevuelta)
         End If
         Me.txtTelefonoContacto.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkLocalidadContacto_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkLocalidadContacto.LinkClicked
      Try
         Dim PantLocalidad As LocalidadesDetalle = New LocalidadesDetalle(New Entidades.Localidad())
         PantLocalidad.StateForm = Win.StateForm.Insertar
         PantLocalidad.CierraAutomaticamente = True
         If PantLocalidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoLocalidadContacto.Text = PantLocalidad.IdLocalidad.ToString()
            Me.bscCodigoLocalidadContacto.PresionarBoton()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvContactos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvContactos.CellDoubleClick
      Try
         If e.RowIndex > -1 Then
            'Limpia los textbox, y demas controles
            Me.RefrescarContactos()

            'Carga el Comprobante seleccionado de la grilla en los textbox 
            Me.CargarContactosCompleto(Me.dgvContactos.Rows(e.RowIndex))

            'Elimina el comprobantede la grilla
            Me.EliminarLineaContacto(True)

            Me.txtNombreContacto.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub controlesContactos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombreContacto.KeyDown, txtTelefonoContacto.KeyDown, txtObservacionContacto.KeyDown, txtMailContacto.KeyDown, txtDireccionContacto.KeyDown, txtCelularContacto.KeyDown, cmbTipoContacto.KeyDown, chbActivoContacto.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub chbHorarioCorridoLaV_CheckedChanged(sender As Object, e As EventArgs) Handles chbHorarioCorrido.CheckedChanged
      Try
         If Me.chbHorarioCorrido.Checked Then
            Me.dtpHoraDesde2.Value = DateTime.Today
            Me.dtpHoraDomDesde2.MinDate = DateTime.Today
            Me.dtpHoraDesde2.Enabled = False
            Me.dtpHoraHasta.Value = DateTime.Today
            Me.dtpHoraHasta.MinDate = DateTime.Today
            Me.dtpHoraHasta.Enabled = False
         Else
            Me.dtpHoraDesde2.Enabled = True
            Me.dtpHoraHasta.Enabled = True
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbHorarioCorridoDom_CheckedChanged(sender As Object, e As EventArgs) Handles chbHorarioCorridoDom.CheckedChanged
      Try
         If Me.chbHorarioCorridoDom.Checked Then
            Me.dtpHoraDomDesde2.Value = DateTime.Today
            Me.dtpHoraDomDesde2.MinDate = DateTime.Today
            Me.dtpHoraDomDesde2.Enabled = False
            Me.dtpHoraDomHasta.Value = DateTime.Today
            Me.dtpHoraDomHasta.MinDate = DateTime.Today
            Me.dtpHoraDomHasta.Enabled = False
         Else
            Me.dtpHoraDomDesde2.Enabled = True
            Me.dtpHoraDomHasta.Enabled = True
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   'PE-30972
   Private Sub chbFechaCambioCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCambioCategoria.CheckedChanged
      If Me.chbCambioCategoria.Checked Then
         Me.dtpFechaCambioCategoria.Enabled = True
         Me.dtpFechaCambioCategoria.Focus()

         Me.cmbCambioCategoria.Enabled = True
         Me.txtObservacionCambioCategoria.Enabled = True
      Else
         Me.dtpFechaCambioCategoria.Enabled = False

         Me.cmbCambioCategoria.Enabled = False
         Me.cmbCambioCategoria.SelectedIndex = -1
         'DirectCast(Me._entidad, Entidades.Cliente).Categoria = ""

         Me.txtObservacionCambioCategoria.Enabled = False
         Me.chbCambioCategoria.Checked = False
         Return
      End If
      Me.dtpFechaCambioCategoria.Enabled = Me.chbCambioCategoria.Checked

   End Sub

   Private Sub chbActivo_CheckedChanged(sender As Object, e As EventArgs) Handles chbActivo.CheckedChanged
      TryCatched(
      Sub()
         If Not _estaCargando Then
            dtpFechaBaja.Enabled = Not chbActivo.Checked
            If Not chbActivo.Checked Then
               dtpFechaBaja.Value = Date.Today
            End If
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub HorarioClienteCompleto()

      Dim horarioClienteCompleto As StringBuilder = New StringBuilder
      With horarioClienteCompleto

         '# Lunes a Viernes
         If dtpHoraDesde.Value.TimeOfDay.ToString() <> "00:00:00" Then
            .AppendFormat("Lun A Vie: {0} a {1}", dtpHoraDesde.Value.ToString("HH:mm"), If(chbHorarioCorrido.Checked, dtpHoraHasta2.Value.ToString("HH:mm"), dtpHoraHasta.Value.ToString("HH:mm")))
            If Not chbHorarioCorrido.Checked AndAlso dtpHoraDesde2.Value.TimeOfDay.ToString() <> "00:00:00" Then
               .AppendFormat(" Y de {0} a {1}", dtpHoraDesde2.Value.ToString("HH:mm"), dtpHoraHasta2.Value.ToString("HH:mm"))
            End If
         End If

         '# Sábados
         If dtpHoraSabDesde.Value.TimeOfDay.ToString() <> "00:00:00" Then
            .AppendFormat(" - Sab: {0} a {1}", dtpHoraSabDesde.Value.ToString("HH:mm"), If(chbHorarioCorridoSab.Checked, dtpHoraSabHasta2.Value.ToString("HH:mm"), dtpHoraSabHasta.Value.ToString("HH:mm")))
            If Not chbHorarioCorridoSab.Checked AndAlso dtpHoraSabDesde2.Value.TimeOfDay.ToString() <> "00:00:00" Then
               .AppendFormat(" Y de {0} a {1}", dtpHoraSabDesde2.Value.ToString("HH:mm"), dtpHoraSabHasta2.Value.ToString("HH:mm"))
            End If
         End If

         '# Domingos
         If dtpHoraDomDesde.Value.TimeOfDay.ToString() <> "00:00:00" Then
            .AppendFormat(" - Dom: {0} a {1}", dtpHoraDomDesde.Value.ToString("HH:mm"), If(chbHorarioCorridoDom.Checked, dtpHoraDomHasta2.Value.ToString("HH:mm"), dtpHoraDomHasta.Value.ToString("HH:mm")))
            If Not chbHorarioCorridoDom.Checked AndAlso dtpHoraDomDesde2.Value.TimeOfDay.ToString() <> "00:00:00" Then
               .AppendFormat(" Y de {0} a {1}.", dtpHoraDomDesde2.Value.ToString("HH:mm"), dtpHoraDomHasta2.Value.ToString("HH:mm"))
            End If
         End If

      End With

      Me.txtHorarioClienteCompleto.Text = If(Not String.IsNullOrEmpty(horarioClienteCompleto.ToString()), horarioClienteCompleto.ToString(), String.Empty)
   End Sub

   Private Function ValidarClienteDesdeProspecto() As String

      Dim result As Reglas.Validaciones.ValidacionResult
      result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() _
                                                                                With {.IdFiscal = txtCUIT.Text,
                                                                                      .SolicitaCUIT = DirectCast(Me._entidad, Entidades.Cliente).CategoriaFiscal.SolicitaCUIT And
                                                                                                       Me.ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente})
      If result.Error Then
         tbcCliente.SelectedTab = Me.tbpDatos
         txtCUIT.Focus()
         Return result.MensajeError
      End If

      Return ""

   End Function

   Private Sub CargarProximoCodigo()

      Dim oCliente As Reglas.Clientes = New Reglas.Clientes(ModoClienteProspecto)
      Dim ProximoCliente As Long

      ProximoCliente = oCliente.GetCodigoClienteMaximo(Entidades.Cliente.Columnas.CodigoCliente.ToString()) + 1
      _proximoCodigoClienteTemp = ProximoCliente
      Me.txtCodigoCliente.Text = ProximoCliente.ToString()
      Me.txtCodigoClienteLetras.Text = ProximoCliente.ToString()
      'Me.txtCodigoCliente.Tag = Me.txtCodigoCliente.Text

      If ProximoCliente > Long.Parse(Me.txtCodigoCliente.Text) Then
         Me.txtNroDoc.Text = Me.txtCodigoCliente.Text
      End If

   End Sub

   Private Sub CargarLocalidad(dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.Cliente).Localidad = New Reglas.Localidades().GetUna(Integer.Parse(dr.Cells("IdLocalidad").Value.ToString()))
      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      _idProvinciaCliente = dr.Cells("IdProvincia").Value.ToString()
      Me.txtProvinciaLocalidad.Text = dr.Cells("NombreProvincia").Value.ToString()
      Me.CargarActividades()
      SetLocalidadContactoDefault()

      HabilitaIdImpositivoOtroPais()
   End Sub

   Private _provEmpresa As Entidades.Provincia
   Private Sub HabilitaIdImpositivoOtroPais()
      Dim prov = New Reglas.Provincias().GetUno(Cliente.Localidad.IdProvincia, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
      If _provEmpresa Is Nothing Then
         Dim locEmpresa = New Reglas.Localidades().GetUna(Publicos.LocalidadEmpresa)
         _provEmpresa = New Reglas.Provincias().GetUno(locEmpresa.IdProvincia, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
      End If

      txtIdImpositivoOtroPais.ReadOnly = prov Is Nothing OrElse prov.IdPais = _provEmpresa.IdPais
   End Sub

   Private Sub CargarLocalidadDir(dr As DataGridViewRow)
      Me.bscCodigoLocalidadDir.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidadDir.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.txtProvinciaLocalidadDir.Text = dr.Cells("NombreProvincia").Value.ToString()
   End Sub

   Private Sub CargarLocalidadContacto(dr As DataGridViewRow)
      Me.bscCodigoLocalidadContacto.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidadContacto.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.txtProvinciaContacto.Text = dr.Cells("NombreProvincia").Value.ToString()
   End Sub

   Private Sub CargarDatosTransportista(dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.Cliente).IdTransportista = Integer.Parse(dr.Cells("IdTransportista").Value.ToString())
      Me.bscCodigoTransportista.Text = dr.Cells("IdTransportista").Value.ToString()
      Me.bscNombreTransportista.Text = dr.Cells("NombreTransportista").Value.ToString()
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

   Private Function GetCobradorCombo(Id As Integer) As Object
      If Me.cmbCobrador.DataSource IsNot Nothing Then
         Dim empleados As List(Of Entidades.Empleado) = DirectCast(Me.cmbCobrador.DataSource, List(Of Entidades.Empleado))
         For Each emp As Entidades.Empleado In empleados
            If Id = emp.IdEmpleado Then
               Return emp
            End If
         Next
      End If
      Return Nothing
   End Function

   Private Sub AgregarActividad()

      Dim dr As DataRow = Me._actividades.NewRow()

      dr("IdCliente") = DirectCast(Me._entidad, Entidades.Cliente).IdCliente
      dr("IdProvincia") = Me.bscActividades.FilaDevuelta.Cells("IdProvincia").Value.ToString()
      dr("NombreProvincia") = Me.bscActividades.FilaDevuelta.Cells("NombreProvincia").Value.ToString()
      dr("IdActividad") = Me.bscActividades.FilaDevuelta.Cells("IdActividad").Value.ToString()
      dr("NombreActividad") = Me.bscActividades.FilaDevuelta.Cells("NombreActividad").Value.ToString()
      dr("Porcentaje") = Me.bscActividades.FilaDevuelta.Cells("Porcentaje").Value.ToString()

      Me._actividades.Rows.Add(dr)

      Me.dgvDetalle.DataSource = Me._actividades

   End Sub

   Public Sub AgregarDireccion()

      Dim tipoDir = New Reglas.TiposDirecciones().GetUna(Integer.Parse(Me.cmbTiposDirecciones.SelectedValue.ToString()))

      For Each dgRw As DataGridViewRow In Me.dgvDirecciones.Rows
         Dim valor As String = dgRw.Cells("IdDireccion").Value.ToString()
         If (dgRw.Cells("IdDireccion").Value.ToString() = Me.txtDirecciones.Text) And
            (dgRw.Cells("NombreLocalidad").Value.ToString() = Me.bscNombreLocalidadDir.Text) And
            (dgRw.Cells("NombreProvinciaD").Value.ToString() = Me.txtProvinciaLocalidadDir.Text) And
            (dgRw.Cells("NombreAbrevTipoDireccion").Value.ToString() = tipoDir.NombreAbrevTipoDireccion) And
            (dgRw.Cells("DireccionAdicional").Value.ToString() = Me.txtDireccionAdicionalDir.Text) Then
            Throw New Exception("La dirección ya esta agregada")
         End If
      Next

      Dim dr As DataRow = Me._direcciones.NewRow()

      Dim id = txtIdDireccion.ValorNumericoPorDefecto(0I)
      If id > 0 Then
         dr("IdDireccion") = id
      End If
      dr("IdCliente") = Cliente.IdCliente
      dr("Direccion") = txtDirecciones.Text
      dr("IdLocalidad") = bscCodigoLocalidadDir.Text
      dr("NombreLocalidad") = bscNombreLocalidadDir.Text
      dr("NombreProvincia") = txtProvinciaLocalidadDir.Text
      dr("IdTipoDireccion") = tipoDir.IdTipoDireccion
      dr("NombreAbrevTipoDireccion") = tipoDir.NombreAbrevTipoDireccion
      dr("DireccionAdicional") = txtDireccionAdicionalDir.Text

      dr("Descripcion") = txtDescripcion.Text
      dr("Observacion") = txtObservacionDomic.Text

      _direcciones.Rows.Add(dr)

      dgvDirecciones.DataSource = _direcciones

   End Sub

   Private Sub AgregarContacto()

      Dim dr As DataRow
      If _contactoEditado IsNot Nothing Then
         dr = _contactoEditado
      Else
         dr = Me._contactos.NewRow()
         'solo voy a controlar si esta en uso si es un Cliente, para los prospectos no es necesario
         If ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente Then
            dr("EnUso") = False
         End If
      End If

      If ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Prospecto Then
         dr("IdProspecto") = DirectCast(Me._entidad, Entidades.Cliente).IdCliente
      Else
         dr("IdCliente") = DirectCast(Me._entidad, Entidades.Cliente).IdCliente
      End If

      Dim tipoCont As Entidades.TipoContacto = New Reglas.TiposContactos().GetUna(Integer.Parse(Me.cmbTipoContacto.SelectedValue.ToString()))
      dr("IdTipoContacto") = tipoCont.IdTipoContacto
      dr("NombreTipoContacto") = tipoCont.NombreTipoContacto
      dr("Activo") = Me.chbActivoContacto.Checked
      dr("NombreContacto") = Me.txtNombreContacto.Text
      dr("Telefono") = Me.txtTelefonoContacto.Text
      dr("Celular") = Me.txtCelularContacto.Text
      dr("CorreoElectronico") = Me.txtMailContacto.Text
      dr("Direccion") = Me.txtDireccionContacto.Text
      dr("IdLocalidad") = Me.bscCodigoLocalidadContacto.Text
      dr("NombreLocalidad") = Me.bscNombreLocalidadContacto.Text
      dr("NombreProvincia") = Me.txtProvinciaContacto.Text
      dr("Observacion") = Me.txtObservacionContacto.Text
      dr("IdUsuario") = actual.Nombre

      Me._contactos.Rows.Add(dr)
      _contactoEditado = Nothing

      Me.dgvContactos.DataSource = Me._contactos

   End Sub


   Private Sub EliminarLineaActividad()

      Me._actividades.Rows(Me.dgvDetalle.SelectedRows(0).Index).Delete()
      Me.dgvDetalle.DataSource = Me._actividades

      If Me.dgvDetalle.Rows.Count > 0 Then
         Me.dgvDetalle.FirstDisplayedScrollingRowIndex = Me.dgvDetalle.Rows.Count - 1
         Me.dgvDetalle.Rows(Me.dgvDetalle.Rows.Count - 1).Selected = True
      End If

   End Sub

   Private Sub EliminarLineaDireccion()

      Me._direcciones.Rows(Me.dgvDirecciones.SelectedRows(0).Index).Delete()
      Me.dgvDirecciones.DataSource = Me._direcciones

      If Me.dgvDirecciones.Rows.Count > 0 Then
         Me.dgvDirecciones.FirstDisplayedScrollingRowIndex = Me.dgvDirecciones.Rows.Count - 1
         Me.dgvDirecciones.Rows(Me.dgvDirecciones.Rows.Count - 1).Selected = True
      End If

   End Sub

   Private Sub EliminarLineaContacto(paraEditar As Boolean)
      If dgvContactos.SelectedRows.Count > 0 AndAlso
         dgvContactos.SelectedRows(0).DataBoundItem IsNot Nothing AndAlso
         TypeOf (dgvContactos.SelectedRows(0).DataBoundItem) Is DataRowView AndAlso
         DirectCast(dgvContactos.SelectedRows(0).DataBoundItem, DataRowView).Row IsNot Nothing Then

         Dim index As Integer = dgvContactos.SelectedRows(0).Index

         If paraEditar Then
            _contactoEditado = _contactos.NewRow()
            _contactoEditado.ItemArray = DirectCast(dgvContactos.SelectedRows(0).DataBoundItem, DataRowView).Row.ItemArray
         Else
            Dim drParaBorrar As DataRow = _contactosBorrados.NewRow()
            drParaBorrar.ItemArray = DirectCast(dgvContactos.SelectedRows(0).DataBoundItem, DataRowView).Row.ItemArray
            _contactosBorrados.Rows.Add(drParaBorrar)
         End If
         Me._contactos.Rows.Remove(DirectCast(dgvContactos.SelectedRows(0).DataBoundItem, DataRowView).Row)
         Me.dgvContactos.DataSource = Me._contactos

         If Me.dgvContactos.Rows.Count > 0 Then
            If index > dgvContactos.Rows.Count - 1 Then
               index = dgvContactos.Rows.Count - 1
            End If

            Me.dgvContactos.Rows(index).Selected = True
            Me.dgvContactos.FirstDisplayedScrollingRowIndex = index
         End If
         '_contactos.AcceptChanges()
      End If
   End Sub

   Private Sub CargarDatosActividad(dr As DataGridViewRow)

      Me.bscActividades.Text = dr.Cells("NombreActividad").Value.ToString()
      Me.txtPorcentaje.Text = dr.Cells("Porcentaje").Value.ToString()
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

      Dim reg As Reglas.ClientesActividades

      reg = New Reglas.ClientesActividades()

      Dim idCategoriaFiscalCliente As Integer = 0
      If cmbCategoriaFiscal.SelectedIndex >= 0 Then
         idCategoriaFiscalCliente = DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IdCategoriaFiscal
      End If
      Me._actividades = reg.GetClientesActividades(IdCliente, _idProvinciaCliente, idCategoriaFiscalCliente)

      Me.ChequeaEstructuraActividades()

      Me.dgvDetalle.DataSource = Me._actividades

   End Sub

   Public Sub CargarDirecciones()

      Dim IdCliente As Long = 0

      IdCliente = DirectCast(Me._entidad, Entidades.Cliente).IdCliente

      Dim reg As Reglas.ClientesDirecciones

      reg = New Reglas.ClientesDirecciones(ModoClienteProspecto)

      Me._direcciones = If(_domicilios Is Nothing, reg.GetClientesDirecciones(IdCliente), _domicilios)

      ' Me.ChequeaEstructuraActividades()

      Me.dgvDirecciones.DataSource = Me._direcciones

   End Sub

   Public Sub CargarContactos()

      Dim IdCliente As Long = 0

      IdCliente = DirectCast(Me._entidad, Entidades.Cliente).IdCliente

      Dim reg As Reglas.ClientesContactos

      reg = New Reglas.ClientesContactos(ModoClienteProspecto)

      Me.ChequeaEstructuraContactos()

      Me._contactos = reg.GetClientesContactos(IdCliente)
      _contactosBorrados = _contactos.Clone()

      Me.dgvContactos.DataSource = Me._contactos
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

   Private Sub ChequeaEstructuraDirecciones()
      If Me._direcciones Is Nothing Then
         Me._direcciones = New DataTable()
         Me._direcciones.Columns.Add("IdCliente", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("IdDireccion", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("Direccion", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("IdLocalidad", System.Type.GetType("System.Int32"))
         Me._direcciones.Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("NombreProvincia", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("IdTipoDireccion", System.Type.GetType("System.Int32"))
         Me._direcciones.Columns.Add("NombreAbrevTipoDireccion", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("DireccionAdicional", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("Descripcion", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("Observacion", System.Type.GetType("System.String"))
      End If

   End Sub

   Private Sub ChequeaEstructuraModulosAdicionales()
      If Me._modulosAdic Is Nothing Then
         Me._modulosAdic = New DataTable()
         Me._modulosAdic.Columns.Add("IdCliente", System.Type.GetType("System.String"))
         Me._modulosAdic.Columns.Add("IdModulo", System.Type.GetType("System.Int32"))
         Me._modulosAdic.Columns.Add("NombreModulo", System.Type.GetType("System.String"))
      End If

   End Sub

   Private Sub ChequeaEstructuraContactos()
      If Me._contactos Is Nothing Then
         Me._contactos = New DataTable()
         If ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Prospecto Then
            Me._contactos.Columns.Add("IdProspecto", System.Type.GetType("System.String"))
         Else
            Me._contactos.Columns.Add("IdCliente", System.Type.GetType("System.String"))
         End If
         Me._contactos.Columns.Add("IdTipoContacto", System.Type.GetType("System.Int32"))
         Me._contactos.Columns.Add("NombreTipoContacto", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("IdContacto", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("NombreContacto", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("Telefono", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("Celular", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("Observacion", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("CorreoElectronico", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("Direccion", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("IdLocalidad", System.Type.GetType("System.Int32"))
         Me._contactos.Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("NombreProvincia", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("Activo", System.Type.GetType("System.Boolean"))
         Me._contactos.Columns.Add("IdUsuario", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("EnUso", System.Type.GetType("System.Boolean"))
         _contactosBorrados = _contactos.Clone()
      End If

   End Sub

   Public Sub CargarModulosAdic()

      Dim IdCliente As Long = 0

      IdCliente = DirectCast(Me._entidad, Entidades.Cliente).IdCliente

      Dim reg As Reglas.ClientesAplicacionesModulos

      reg = New Reglas.ClientesAplicacionesModulos(ModoClienteProspecto)

      Me._modulosAdic = reg.GetClientesModulos(IdCliente)

      Me.ugModulos.DataSource = Me._modulosAdic

   End Sub
   Public Sub Refrescar()
      Me.bscActividades.Text = ""
      Me.txtPorcentaje.Text = "0.00"
      Me.cmbProvincia.Text = New Reglas.Localidades().GetUna(Publicos.LocalidadEmpresa).NombreProvincia.ToString()
      Me.bscActividades.Enabled = True
      Me.txtPorcentaje.Enabled = True
      Me.cmbProvincia.Enabled = True
      Me.cmbProvincia.Focus()
   End Sub

   Public Sub RefrescarDirecciones()
      txtIdDireccion.Text = ""
      If ChcBxMantener.Checked = False Then
         txtDirecciones.Text = ""
         bscCodigoLocalidadDir.Text = ""
         bscNombreLocalidadDir.Text = ""
         txtProvinciaLocalidadDir.Text = ""
         txtDireccionAdicionalDir.Text = ""
         txtDescripcion.Text = String.Empty
         txtObservacionDomic.Text = String.Empty
      End If
      txtDirecciones.Focus()
   End Sub

   Public Sub RefrescarModulos()
      Me.cmbModulos.SelectedIndex = -1
   End Sub

   Private Sub SetLocalidadContactoDefault()
      Me.bscNombreLocalidadContacto.Text = ""
      Me.bscCodigoLocalidadContacto.Text = bscCodigoLocalidad.Text
      If Not String.IsNullOrWhiteSpace(bscCodigoLocalidadContacto.Text) Then
         bscCodigoLocalidadContacto.PresionarBoton()
      End If
   End Sub

   Public Sub RefrescarContactos()
      If _contactoEditado IsNot Nothing Then
         _contactos.Rows.Add(_contactoEditado)
         _contactoEditado = Nothing
      End If
      Me.txtNombreContacto.Text = ""
      If Me.cmbTipoContacto.Items.Count = 1 Then
         Me.cmbTipoContacto.SelectedIndex = 0
      End If
      Me.txtDireccionContacto.Text = ""
      SetLocalidadContactoDefault()
      Me.txtProvinciaContacto.Text = ""
      Me.txtTelefonoContacto.Text = ""
      Me.txtCelularContacto.Text = ""
      Me.txtMailContacto.Text = ""
      Me.txtObservacionContacto.Text = ""
      Me.txtNombreContacto.Focus()
   End Sub

   Private Sub CargarMapa()

      Me.gmcMapa.Overlays.Clear()

      Dim direccion As String
      Dim nombre As String
      Dim gp As GMap.NET.GeocodingProvider = MapProviders.GMapProviders.OpenStreetMap
      Dim pt As PointLatLng
      Dim ov As GMapOverlay = New GMapOverlay("direcciones")
      Dim i As Integer = 0
      Dim provincia As String
      provincia = New Reglas.Localidades().GetUna(Integer.Parse(Me.bscCodigoLocalidad.Text.ToString())).NombreProvincia

      direccion = Me.txtDireccion.Text.ToString() + "," + Me.bscCodigoLocalidad.Text.ToString() + "," + provincia + ",Argentina"
      nombre = Me.txtNombre.Text.ToString()

      Try
         pt = gp.GetPoint(direccion, GeoCoderStatusCode.G_GEO_UNKNOWN_ADDRESS).Value

      Catch ex As Exception
         Me.bscNombreLocalidad.Focus()
         MessageBox.Show("No se encontro la Dirección en el Mapa.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End Try


      If Not pt.IsEmpty Then
         If Me.txtGeoLocalizacionLat.Text = "0" Then
            ov.Markers.Add(Me.GetMarca(pt.Lat, pt.Lng, Me.txtDireccion.Text.ToString(), nombre))
            Me.gmcMapa.Overlays.Add(ov)

            Me.gmcMapa.SetZoomToFitRect(Me.gmcMapa.GetRectOfAllMarkers("direcciones").Value)


            Me.txtGeoLocalizacionLat.Text = pt.Lat.ToString()
            Me.txtGeoLocalizacionLng.Text = pt.Lng.ToString()
         Else
            ov.Markers.Add(Me.GetMarca(Double.Parse(Me.txtGeoLocalizacionLat.Text.ToString()), Double.Parse(Me.txtGeoLocalizacionLng.Text.ToString()), Me.txtDireccion.Text.ToString(), nombre))
            Me.gmcMapa.Overlays.Add(ov)

            Me.gmcMapa.SetZoomToFitRect(Me.gmcMapa.GetRectOfAllMarkers("direcciones").Value)
         End If
      End If

      Me.gmcMapa.Zoom = 13

   End Sub

   Private Sub Ubicacion()

      Me.gmcMapa.Overlays.Clear()

      Dim nombre As String
      Dim ov As GMapOverlay = New GMapOverlay("direcciones")
      Dim i As Integer = 0
      nombre = Me.txtNombre.Text.ToString()
      If Not String.IsNullOrEmpty(Me.txtGeoLocalizacionLat.Text.ToString()) Then
         ov.Markers.Add(Me.GetMarca(Double.Parse(Me.txtGeoLocalizacionLat.Text.ToString()), Double.Parse(Me.txtGeoLocalizacionLng.Text.ToString()), Me.txtDireccion.Text.ToString(), nombre))
         Me.gmcMapa.Overlays.Add(ov)

         Me.gmcMapa.SetZoomToFitRect(gmcMapa.GetRectOfAllMarkers("direcciones").Value)

         Me.gmcMapa.Zoom = 13

      End If

   End Sub

   Private Function GetMarca(latitud As Double, longitud As Double, direccion As String, nombre As String) As GMarkerGoogle
      Dim marker As GMarkerGoogle = New GMarkerGoogle(New PointLatLng(latitud, longitud), GMarkerGoogleType.green)
      marker.ToolTip = New GMap.NET.WindowsForms.GMapToolTip(marker)
      marker.ToolTipText = nombre + "-" + direccion
      Return marker
   End Function

   Private Sub CargarDatosGarante(dr As DataGridViewRow)

      Me.bscGarante.Text = dr.Cells("Nombre" + ModoClienteProspecto.ToString()).Value.ToString()
      Me.bscCodigoGarante.Text = dr.Cells("Codigo" + ModoClienteProspecto.ToString()).Value.ToString()

      DirectCast(Me._entidad, Entidades.Cliente).IdClienteGarante = Long.Parse(dr.Cells("Id" + ModoClienteProspecto.ToString()).Value.ToString())

      Me._validaGarante = True

   End Sub

   Private Sub CargarDatosClienteCtaCte(dr As DataGridViewRow)

      bscNombreClienteCtaCte.Text = dr.Cells("Nombre" + ModoClienteProspecto.ToString()).Value.ToString()
      bscCodigoClienteCtaCte.Text = dr.Cells("Codigo" + ModoClienteProspecto.ToString()).Value.ToString()
      bscCodigoClienteCtaCte.Tag = dr.Cells("Id" + ModoClienteProspecto.ToString()).Value.ToString()

      DirectCast(_entidad, Entidades.Cliente).IdClienteCtaCte = Long.Parse(dr.Cells("Id" + ModoClienteProspecto.ToString()).Value.ToString())

   End Sub

   Private Sub LimpiarCampos()
      txtIdDireccion.Text = "0"
      txtDirecciones.Text = ""
      bscCodigoLocalidadDir.Text = ""
      bscNombreLocalidadDir.Text = ""
      txtProvinciaLocalidadDir.Text = ""
      cmbTiposDirecciones.SelectedIndex = 0
   End Sub

   Private Sub CargarLineaCompleta(dr As DataGridViewRow)
      txtIdDireccion.Text = dr.Cells("ugDirIdDireccion").Value.ToString()
      txtDirecciones.Text = dr.Cells("IdDireccion").Value.ToString()
      bscCodigoLocalidadDir.Text = dr.Cells("IdLocalidad").Value.ToString()
      bscCodigoLocalidadDir.PresionarBoton()
      Dim tipDir = New Reglas.TiposDirecciones().GetUna(Integer.Parse(dr.Cells("IdTipoDireccion").Value.ToString()))
      cmbTiposDirecciones.Text = tipDir.NombreTipoDireccion
      txtDireccionAdicionalDir.Text = dr.Cells("DireccionAdicional").Value.ToString()

      txtDescripcion.Text = dr.Cells("Descripcion").Value.ToString()
      txtObservacionDomic.Text = dr.Cells("Observacion").Value.ToString()

   End Sub

   Private Sub EliminarLinea()
      Me._direcciones.Rows.RemoveAt(Me.dgvDirecciones.SelectedRows(0).Index)
      Me.dgvDirecciones.DataSource = Me._direcciones
   End Sub

   Private Sub EliminarLineaC()
      Me._contactos.Rows.RemoveAt(Me.dgvContactos.SelectedRows(0).Index)
      Me.dgvContactos.DataSource = Me._contactos
   End Sub

   Private Sub CargarContactosCompleto(dr As DataGridViewRow)

      Me.txtNombreContacto.Text = dr.Cells("NombreContacto").Value.ToString()
      Me.cmbTipoContacto.SelectedValue = dr.Cells("IdTipoContacto").Value.ToString()
      Me.txtDireccionContacto.Text = dr.Cells("Direccion").Value.ToString()
      Me.bscCodigoLocalidadContacto.Text = dr.Cells("IdLocalidad1").Value.ToString()
      Me.bscCodigoLocalidadContacto.Selecciono = True
      Me.bscNombreLocalidadContacto.Text = dr.Cells("NombreLocalidad1").Value.ToString()
      Me.txtProvinciaContacto.Text = dr.Cells("NombreProvincia1").Value.ToString()
      Me.txtTelefonoContacto.Text = dr.Cells("Telefono").Value.ToString()
      Me.txtCelularContacto.Text = dr.Cells("Celular").Value.ToString()
      Me.txtMailContacto.Text = dr.Cells("CorreoElectronico").Value.ToString()
      Me.txtObservacionContacto.Text = dr.Cells("Observacion").Value.ToString()
      Me.chbActivoContacto.Checked = Boolean.Parse(dr.Cells("Activo").Value.ToString())

   End Sub

   Private Sub SetearHorasEnCero()
      Dim horaCero As DateTime = New DateTime(Today.Year, Today.Month, Today.Day, 0, 0, 0, 0)
      Me.dtpHoraDesde.Value = horaCero
      Me.dtpHoraHasta.Value = horaCero
      Me.dtpHoraDesde2.Value = horaCero
      Me.dtpHoraHasta2.Value = horaCero
      Me.dtpHoraSabDesde.Value = horaCero
      Me.dtpHoraSabHasta.Value = horaCero
      Me.dtpHoraSabDesde2.Value = horaCero
      Me.dtpHoraSabHasta2.Value = horaCero
      Me.dtpHoraDomDesde.Value = horaCero
      Me.dtpHoraDomHasta.Value = horaCero
      Me.dtpHoraDomDesde2.Value = horaCero
      Me.dtpHoraDomHasta2.Value = horaCero
   End Sub

#End Region

   Private Sub chkCuentaBancariaGroup_CheckedChanged(sender As Object, e As EventArgs) Handles chkCuentaBancariaGroup.CheckedChanged
      If Not Me.chkCuentaBancariaGroup.Checked Then
         Me.txtCBU.Text = ""
         Me.txtNumeroCuentaBancaria.Text = ""
         Me.cmbCuentaBancariaClase.SelectedIndex = -1
         Me.cmbBanco.SelectedIndex = -1
         Me.txtCuitCtaBancaria.Text = ""

         DirectCast(Me._entidad, Entidades.Cliente).CuentaBancariaClase.IdCuentaBancariaClase = -1
         DirectCast(Me._entidad, Entidades.Cliente).Banco.IdBanco = -1

      End If

      Me.txtCBU.Enabled = Me.chkCuentaBancariaGroup.Checked
      Me.txtNumeroCuentaBancaria.Enabled = Me.chkCuentaBancariaGroup.Checked
      Me.cmbCuentaBancariaClase.Enabled = Me.chkCuentaBancariaGroup.Checked
      Me.cmbBanco.Enabled = Me.chkCuentaBancariaGroup.Checked
      Me.txtCuitCtaBancaria.Enabled = Me.chkCuentaBancariaGroup.Checked
   End Sub

   Private Sub btnInsertarAdjunto_Click(sender As Object, e As EventArgs) Handles btnInsertarAdjunto.Click
      Dim adjunto As Entidades.ClienteAdjunto = New Entidades.ClienteAdjunto()
      Using frm As Adjunto = New Adjunto(adjunto, New Reglas.ClientesAdjuntos())
         frm.StateForm = Win.StateForm.Insertar
         If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Cliente.Adjuntos.Add(adjunto)
            ugAdjunto.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
         End If
      End Using
   End Sub

   Private Sub ugAdjunto_DoubleClickRow(sender As Object, e As UltraWinGrid.DoubleClickRowEventArgs) Handles ugAdjunto.DoubleClickRow
      Try
         Dim adjunto As Entidades.ClienteAdjunto = GetCurrentAdjunto()
         If adjunto IsNot Nothing Then
            Using frm As Adjunto = New Adjunto(adjunto, New Reglas.ClientesAdjuntos())
               frm.StateForm = Win.StateForm.Actualizar
               If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  ugAdjunto.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
                  ugAdjunto.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
               End If
            End Using
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnEliminarAdjunto_Click(sender As Object, e As EventArgs) Handles btnEliminarAdjunto.Click
      Try
         Dim adjunto As Entidades.ClienteAdjunto = GetCurrentAdjunto()
         If adjunto IsNot Nothing Then
            If ShowPregunta("¿Desea eliminar el adjunto seleccionado?") = Windows.Forms.DialogResult.Yes Then
               Cliente.Adjuntos.Remove(adjunto)
               ugAdjunto.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function GetCurrentAdjunto() As Entidades.ClienteAdjunto
      If ugAdjunto.ActiveRow IsNot Nothing AndAlso
         ugAdjunto.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugAdjunto.ActiveRow.ListObject) Is Entidades.ClienteAdjunto Then
         Return DirectCast(ugAdjunto.ActiveRow.ListObject, Entidades.ClienteAdjunto)
      End If
      Return Nothing
   End Function

   'Public Enum OpcionesCombo
   '   <Description("  ")> 
   '   <Description("SI")> 1
   '   <Description("NO")> 2
   'End Enum

   Private Sub txtVersionNro_TextChanged(sender As Object, e As EventArgs)

      If Me._estaCargando Then Exit Sub

      'Al cambiar la version limpio el combo para obligarlo a cargarlo
      Me.dtpFechaActualizacion.Checked = False

   End Sub

   Private Sub ugAdjunto_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugAdjunto.ClickCellButton
      Try
         If e.Cell.Column.Key = "ClipArchivoAdjunto" Then
            Dim adjunto As Entidades.ClienteAdjunto = GetCurrentAdjunto()
            If adjunto IsNot Nothing Then
               Using frm As Adjunto = New Adjunto(adjunto, New Reglas.ClientesAdjuntos())
                  frm.StateForm = Win.StateForm.Consultar
                  If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     ugAdjunto.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
                     ugAdjunto.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
                  End If
               End Using
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugAdjunto_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles ugAdjunto.InitializeRow
      Try
         If e.Row IsNot Nothing Then
            e.Row.Cells("ClipArchivoAdjunto").ButtonAppearance.Image = My.Resources.paper_clip_64
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub btnCopiarSoporte_Click(sender As Object, e As EventArgs) Handles btnCopiarSoporte.Click
      CopiarImagenPortapapeles(pnlVincularSoporte.BackgroundImage)
   End Sub
   Private Sub btnCopiarCobranza_Click(sender As Object, e As EventArgs) Handles btnCopiarCobranza.Click
      CopiarImagenPortapapeles(pnlVincularCobranza.BackgroundImage)
   End Sub

   Private Sub btnCopiarPedido_Click(sender As Object, e As EventArgs) Handles btnCopiarPedido.Click
      CopiarImagenPortapapeles(pnlVincularPedido.BackgroundImage)
   End Sub

   Private Sub MostrarCodigos()
      Try
         Cursor = Cursors.WaitCursor

         solicitarSoporte = New Reglas.SolicitarSoporte()
         sincronizacion = New Reglas.ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil()


         Try
            MostrarCodigosSoporte()
         Catch ex As Exception
            ShowError(ex)
         End Try
         Try
            MostrarCodigosCobranza()
         Catch ex As Exception
            ShowError(ex)
         End Try
         Try
            MostrarCodigosPedidos()
         Catch ex As Exception
            ShowError(ex)
         End Try
      Catch ex As Exception
         ShowError(ex)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub MostrarCodigosSoporte()
      MostrarCodigo(pnlVincularSoporte, Ayudante.QRCodeHelper.GenerarQR(solicitarSoporte.GetInfoParaVinculacion(Long.Parse(Me.txtCodigoCliente.Text), txtNombre.Text, txtCUIT.Text, String.Empty)))
   End Sub
   Private Sub MostrarCodigosPedidos()
      MostrarCodigo(pnlVincularPedido, Ayudante.QRCodeHelper.GenerarQR(sincronizacion.GetInfoParaVinculacion(Long.Parse(Me.txtCodigoCliente.Text), txtNombre.Text, txtCUIT.Text, String.Empty)))
   End Sub
   Private Sub MostrarCodigosCobranza()
      MostrarCodigo(pnlVincularCobranza, Ayudante.QRCodeHelper.GenerarQR(sincronizacion.GetInfoParaVinculacion(Long.Parse(Me.txtCodigoCliente.Text), txtNombre.Text, txtCUIT.Text, String.Empty)))
   End Sub
   Private Sub MostrarCodigo(pnl As Panel, img As Image)
      Dim imgTemp As Image = Nothing
      If pnl.BackgroundImage IsNot Nothing Then
         imgTemp = pnl.BackgroundImage
      End If
      pnl.BackgroundImage = img
      If imgTemp IsNot Nothing Then
         imgTemp.Dispose()
      End If
   End Sub
   Private Sub CopiarImagenPortapapeles(imagen As Image)
      Try
         Clipboard.SetImage(imagen)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbAplicaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAplicaciones.SelectedIndexChanged
      Try
         If cmbAplicaciones.SelectedIndex > -1 Then
            Me._publicos.CargaComboAplicacionesEdiciones(cmbEdicion, Me.cmbAplicaciones.SelectedValue.ToString())
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub AgregarLineaModulo()

      Dim modulo As Entidades.AplicacionModulo = New Reglas.AplicacionesModulos().GetUno(Integer.Parse(Me.cmbModulos.SelectedValue.ToString()))

      For Each dgRw As UltraGridRow In Me.ugModulos.Rows
         Dim valor As String = dgRw.Cells("IdModulo").Value.ToString()
         If (Integer.Parse(dgRw.Cells("IdModulo").Value.ToString()) = Integer.Parse(Me.cmbModulos.SelectedValue.ToString())) Then
            Throw New Exception("El modulo ya esta agregado")
         End If
      Next

      Dim dr As DataRow = Me._modulosAdic.NewRow()
      dr("IdCliente") = DirectCast(Me._entidad, Entidades.Cliente).IdCliente
      dr("IdModulo") = Integer.Parse(Me.cmbModulos.SelectedValue.ToString())
      dr("NombreModulo") = Me.cmbModulos.Text

      Me._modulosAdic.Rows.Add(dr)

      Me.ugModulos.DataSource = Me._modulosAdic
   End Sub

   Private Sub LimpiaLineaModulo()
      Me.cmbModulos.SelectedIndex = -1
   End Sub

   Private Function ValidaLineaModulo() As Boolean
      If Me.cmbModulos.SelectedIndex = -1 Then
         Me.cmbModulos.Focus()
         Throw New Exception("Desde seleccionar un módulo.")
      End If
      Return True
   End Function

   Private Sub EliminarLineaModulo()

      Me._modulosAdic.Rows(Me.ugModulos.ActiveRow.Index).Delete()
      Me.ugModulos.DataSource = Me._modulosAdic

      If Me.ugModulos.Rows.Count > 0 Then
         '  Me.ugModulos.FirstDisplayedScrollingRowIndex = Me.ugModulos.Rows.Count - 1
         Me.ugModulos.Rows(Me.ugModulos.Rows.Count - 1).Selected = True
      End If
   End Sub

   Private Sub btnInsertarModulo_Click(sender As Object, e As EventArgs) Handles btnInsertarModulo.Click
      Try
         If ValidaLineaModulo() Then
            Me.AgregarLineaModulo()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarModulo_Click(sender As Object, e As EventArgs) Handles btnEliminarModulo.Click
      Try
         EliminarLineaModulo()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtCantidadLocal_Leave(sender As Object, e As EventArgs) Handles txtCantidadLocal.Leave
      If Not String.IsNullOrWhiteSpace(txtCantidadLocal.Text) And Not String.IsNullOrWhiteSpace(txtCantidadRemota.Text) Then
         TryCatched(Sub() txtCantidadDePCs.Text = (txtCantidadLocal.ValorNumericoPorDefecto(0I) + txtCantidadRemota.ValorNumericoPorDefecto(0I)).ToString())
      End If
   End Sub

   Private Sub txtCantidadRemota_Leave(sender As Object, e As EventArgs) Handles txtCantidadRemota.Leave
      TryCatched(Sub() txtCantidadDePCs.Text = (txtCantidadLocal.ValorNumericoPorDefecto(0I) + txtCantidadRemota.ValorNumericoPorDefecto(0I)).ToString())
   End Sub

   Private Sub chbCertificadoMiPyme_CheckedChanged(sender As Object, e As EventArgs) Handles chbCertificadoMiPyme.CheckedChanged
      Try
         dtpFechaDesdeCertificado.Enabled = chbCertificadoMiPyme.Checked
         dtpFechaHastaCertificado.Enabled = chbCertificadoMiPyme.Checked
      Catch ex As Exception
         chbCertificadoMiPyme.Checked = False
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbCobrador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCobrador.SelectedIndexChanged
      Try
         If Not Me._estaCargando Then
            If Me.cmbCobrador.SelectedIndex <> -1 Then
               DirectCast(Me._entidad, Entidades.Cliente).Cobrador = DirectCast(Me.cmbCobrador.SelectedItem, Entidades.Empleado)
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private _txtValorizacionCoeficienteFacturacionAnterior As Decimal
   Private _txtValorizacionCoeficienteDeudaAnterior As Decimal
   Private _txtValorizacionProyectoAnterior As Decimal

   Private Sub txtValorizacionCoeficienteFacturacion_Enter(sender As Object, e As EventArgs) Handles txtValorizacionCoeficienteFacturacion.Enter
      Try
         _txtValorizacionCoeficienteFacturacionAnterior = txtValorizacionCoeficienteFacturacion.Text.ValorNumericoPorDefecto(0D)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub txtValorizacionCoeficienteDeuda_Enter(sender As Object, e As EventArgs) Handles txtValorizacionCoeficienteDeuda.Enter
      Try
         _txtValorizacionCoeficienteDeudaAnterior = txtValorizacionCoeficienteDeuda.Text.ValorNumericoPorDefecto(0D)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub txtValorizacionProyecto_Enter(sender As Object, e As EventArgs) Handles txtValorizacionProyecto.Enter
      Try
         _txtValorizacionProyectoAnterior = txtValorizacionProyecto.Text.ValorNumericoPorDefecto(0D)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub txtValorizacionCoeficienteFacturacion_Leave(sender As Object, e As EventArgs) Handles txtValorizacionCoeficienteFacturacion.Leave
      Try
         If _txtValorizacionCoeficienteFacturacionAnterior <> txtValorizacionCoeficienteFacturacion.Text.ValorNumericoPorDefecto(0D) Then
            RecalculaValorizacionFacturacion()
            RecalculaValorizacionCliente()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub txtValorizacionCoeficienteDeuda_Leave(sender As Object, e As EventArgs) Handles txtValorizacionCoeficienteDeuda.Leave
      Try
         If _txtValorizacionCoeficienteDeudaAnterior <> txtValorizacionCoeficienteDeuda.Text.ValorNumericoPorDefecto(0D) Then
            RecalculaValorizacionDeuda()
            RecalculaValorizacionCliente()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub txtValorizacionProyecto_Leave(sender As Object, e As EventArgs) Handles txtValorizacionProyecto.Leave
      Try
         If _txtValorizacionProyectoAnterior <> txtValorizacionProyecto.Text.ValorNumericoPorDefecto(0D) Then
            RecalculaValorizacionCliente()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub RecalculaValorizacionFacturacion()
      txtValorizacionFacturacion.Text = (txtValorizacionFacturacionMensual.Text.ValorNumericoPorDefecto(0D) *
                                         txtValorizacionCoeficienteFacturacion.Text.ValorNumericoPorDefecto(0D)).ToString(txtValorizacionFacturacion.Formato)
   End Sub
   Private Sub RecalculaValorizacionDeuda()
      txtValorizacionDeuda.Text = (txtValorizacionImporteAdeudado.Text.ValorNumericoPorDefecto(0D) *
                                   txtValorizacionCoeficienteDeuda.Text.ValorNumericoPorDefecto(0D)).ToString(txtValorizacionDeuda.Formato)
   End Sub

   Private Sub RecalculaValorizacionCliente()
      txtValorizacionCliente.Text = (txtValorizacionFacturacion.Text.ValorNumericoPorDefecto(0D) +
                                     txtValorizacionDeuda.Text.ValorNumericoPorDefecto(0D) +
                                     txtValorizacionProyecto.Text.ValorNumericoPorDefecto(0D)).ToString(txtValorizacionDeuda.Formato)
      txtValorizacionEstrellas.Text = "0"
      lblValorizacionEstrellasNota.Visible = True
   End Sub

   Private Sub chbNumeroAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroAutomatico.CheckedChanged

      Me.txtCodigoCliente.ReadOnly = Me.chbNumeroAutomatico.Checked
      If Me.chbNumeroAutomatico.Checked Then
         CargarProximoCodigo()
      End If

   End Sub

   Private _txtValorizacionFacturacionMensualAnterior As Decimal
   Private Sub txtValorizacionFacturacionMensual_Enter(sender As Object, e As EventArgs) Handles txtValorizacionFacturacionMensual.Enter
      TryCatched(Sub() _txtValorizacionFacturacionMensualAnterior = txtValorizacionFacturacionMensual.ValorNumericoPorDefecto(0D))
   End Sub
   Private Sub txtValorizacionFacturacionMensual_Leave(sender As Object, e As EventArgs) Handles txtValorizacionFacturacionMensual.Leave
      Try
         If _txtValorizacionFacturacionMensualAnterior <> txtValorizacionFacturacionMensual.ValorNumericoPorDefecto(0D) Then
            RecalculaValorizacionFacturacion()
            RecalculaValorizacionCliente()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private _txtValorizacionImporteAdeudadoAnterior As Decimal
   Private Sub txtValorizacionImporteAdeudado_Enter(sender As Object, e As EventArgs) Handles txtValorizacionImporteAdeudado.Enter
      TryCatched(Sub() _txtValorizacionImporteAdeudadoAnterior = txtValorizacionImporteAdeudado.ValorNumericoPorDefecto(0D))
   End Sub
   Private Sub txtValorizacionImporteAdeudado_Leave(sender As Object, e As EventArgs) Handles txtValorizacionImporteAdeudado.Leave
      Try
         If _txtValorizacionImporteAdeudadoAnterior <> txtValorizacionImporteAdeudado.ValorNumericoPorDefecto(0D) Then
            RecalculaValorizacionDeuda()
            RecalculaValorizacionCliente()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#Region "Eventos Busquedas Zonas Geográficas"

   Private Sub bscCodigoZonaGeografica_BuscadorClick() Handles bscCodigoZonaGeografica.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaZonasGeograficas2(bscCodigoZonaGeografica)
            If _estaCargando Then
               bscCodigoZonaGeografica.Datos = New Reglas.ZonasGeograficas().GetPorCodigoExacto(bscCodigoZonaGeografica.Text)
            Else
               bscCodigoZonaGeografica.Datos = New Reglas.ZonasGeograficas().GetPorCodigo(bscCodigoZonaGeografica.Text)
            End If
         End Sub)
   End Sub
   Private Sub bscNombreZonaGeografica_BuscadorClick() Handles bscNombreZonaGeografica.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaZonasGeograficas2(bscNombreZonaGeografica)
            bscNombreZonaGeografica.Datos = New Reglas.ZonasGeograficas().GetPorNombre(bscNombreZonaGeografica.Text)
         End Sub)
   End Sub

   Private Sub bscCodigoZonaGeografica_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoZonaGeografica.BuscadorSeleccion
      TryCatched(Sub() CargarZonaGeografica(e.FilaDevuelta))
      Me.cmbVendedor.Focus()
   End Sub

   Private Sub bscNombreZonaGeografica_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreZonaGeografica.BuscadorSeleccion
      TryCatched(Sub() CargarZonaGeografica(e.FilaDevuelta))
      Me.cmbVendedor.Focus()
   End Sub

   Private Sub CargarZonaGeografica(dr As DataGridViewRow)
      If dr IsNot Nothing Then

         DirectCast(Me._entidad, Entidades.Cliente).ZonaGeografica = New Reglas.ZonasGeograficas().GetUno(dr.Cells("IdZonaGeografica").Value.ToString())
         Me.bscCodigoZonaGeografica.Text = dr.Cells("IdZonaGeografica").Value.ToString()
         Me.bscNombreZonaGeografica.Text = dr.Cells("NombreZonaGeografica").Value.ToString()

      End If
   End Sub

   Private Sub chbComprobanteInvocacionMasiva_CheckedChanged(sender As Object, e As EventArgs) Handles chbComprobanteInvocacionMasiva.CheckedChanged
      If Not Me.chbComprobanteInvocacionMasiva.Checked Then
         Me.cmbComprobanteInvocacionMasiva.SelectedIndex = -1
         DirectCast(Me._entidad, Entidades.Cliente).IdTipoComprobanteInvocacionMasiva = ""
      End If

      Me.cmbComprobanteInvocacionMasiva.Enabled = Me.chbComprobanteInvocacionMasiva.Checked

      If Me.chbComprobanteInvocacionMasiva.Checked Then
         Me.cmbComprobanteInvocacionMasiva.Focus()
      End If
   End Sub

   Private Sub chbVariacionDolarSistema_CheckedChanged(sender As Object, e As EventArgs) Handles chbVariacionDolarSistema.CheckedChanged
      If Not Me.chbVariacionDolarSistema.Checked Then
         Me.txtVariacionDolarSistema.Text = ""
         DirectCast(Me._entidad, Entidades.Cliente).VarPesosCotizDolar = 0
      End If

      Me.txtVariacionDolarSistema.Enabled = Me.chbVariacionDolarSistema.Checked

      If Me.chbVariacionDolarSistema.Checked Then
         Me.txtVariacionDolarSistema.Focus()
      End If

   End Sub


#End Region

#Region "Descuentos Marcas"
   Private Sub btnRefrescarMarcas_Click(sender As Object, e As EventArgs) Handles btnRefrescarMarcas.Click
      TryCatched(Sub() LimpiaDescuentoMarcas())
   End Sub
   Private Sub btnInsertarMarca_Click(sender As Object, e As EventArgs) Handles btnInsertarMarca.Click
      TryCatched(
      Sub()
         If ValidaMarca() Then
            AgregarMarca()
            LimpiaDescuentoMarcas()
         End If
      End Sub)
   End Sub
   Private Sub btnEliminarMarca_Click(sender As Object, e As EventArgs) Handles btnEliminarMarca.Click
      TryCatched(
      Sub()
         Dim dr = ugDescuentosMarcas.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            If ShowPregunta("¿Esta seguro de eliminar el Descuento seleccionado?") = Windows.Forms.DialogResult.Yes Then
               EliminarLineaMarca(dr)
            End If
         End If
      End Sub)
   End Sub
   Private Sub controlesMarcas_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbMarcas.KeyDown, txtDescuentoMarcas.KeyDown, txtDescuentoMarcas2.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub LimpiaDescuentoMarcas()
      cmbMarcas.SelectedIndex = -1
      txtDescuentoMarcas.SetValor(0D)
      txtDescuentoMarcas2.SetValor(0D)
      cmbMarcas.Focus()
   End Sub
   Private Function ValidaMarca() As Boolean
      If cmbMarcas.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar una Marca")
         cmbMarcas.Focus()
         Return False
      End If
      If ExisteMarca(cmbMarcas.ValorSeleccionado(0I)) Then
         ShowMessage("Ya existe la Marca.")
         cmbMarcas.Focus()
         Return False
      End If
      If txtDescuentoMarcas.ValorNumericoPorDefecto(0D) = 0D And txtDescuentoMarcas2.ValorNumericoPorDefecto(0D) = 0D Then
         ShowMessage("Debe cargar algún descuento de marca")
         txtDescuentoMarcas.Focus()
         Return False
      End If
      If txtDescuentoMarcas.ValorNumericoPorDefecto(0D) >= 100 Then
         ShowMessage("El descuento 1 de Marca no puede debe ser menor a 100%")
         txtDescuentoMarcas.Focus()
         Return False
      End If
      If txtDescuentoMarcas2.ValorNumericoPorDefecto(0D) >= 100 Then
         ShowMessage("El descuento 2 de Marca no puede debe ser menor a 100%")
         txtDescuentoMarcas2.Focus()
         Return False
      End If
      Return True
   End Function
   Private Function ExisteMarca(idMarca As Integer) As Boolean
      Return ugDescuentosMarcas.DataSource(Of DataTable).Any(Function(dr) dr.RowState <> DataRowState.Deleted AndAlso dr.Field(Of Integer)("IdMarca") = idMarca)
   End Function
   Private Sub AgregarMarca()
      Dim dr = ugDescuentosMarcas.DataSource(Of DataTable).NewRow()

      dr("IdCliente") = DirectCast(_entidad, Entidades.Cliente).IdCliente
      dr("IdMarca") = cmbMarcas.ValorSeleccionado(0I)
      dr("NombreMarca") = cmbMarcas.Text
      dr("DescuentoRecargoPorc1") = txtDescuentoMarcas.ValorNumericoPorDefecto(0D)
      dr("DescuentoRecargoPorc2") = txtDescuentoMarcas2.ValorNumericoPorDefecto(0D)

      ugDescuentosMarcas.DataSource(Of DataTable).Rows.Add(dr)
      ugDescuentosMarcas.Rows.Refresh(RefreshRow.ReloadData)
   End Sub
   Private Sub EliminarLineaMarca(dr As DataRow)
      If dr IsNot Nothing Then
         dr.Delete()
         ugDescuentosMarcas.Rows.Refresh(RefreshRow.ReloadData)
      End If
   End Sub

#End Region
#Region "Descuentos Rubros"
   Private Sub btnRefrescarRubros_Click(sender As Object, e As EventArgs) Handles btnRefrescarRubros.Click
      TryCatched(Sub() LimpiaDescuentoRubros())
   End Sub
   Private Sub btnInsertarRubros_Click(sender As Object, e As EventArgs) Handles btnInsertarRubros.Click
      TryCatched(
      Sub()
         If ValidaRubro() Then
            AgregarRubro()
            LimpiaDescuentoRubros()
         End If
      End Sub)
   End Sub
   Private Sub btnEliminarRubro_Click(sender As Object, e As EventArgs) Handles btnEliminarRubros.Click
      TryCatched(
      Sub()
         Dim dr = ugDescuentosRubros.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            If ShowPregunta("¿Esta seguro de eliminar el Descuento seleccionado?") = Windows.Forms.DialogResult.Yes Then
               EliminarLineaRubro(dr)
            End If
         End If
      End Sub)
   End Sub
   Private Sub controlesRubros_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbRubros.KeyDown, txtDescuentoRubro.KeyDown, txtDescuentoRubro2.KeyDown
      PresionarTab(e)
   End Sub

   Public Sub LimpiaDescuentoRubros()
      cmbRubros.SelectedIndex = -1
      txtDescuentoRubro.SetValor(0D)
      txtDescuentoRubro2.SetValor(0D)
      cmbRubros.Focus()
   End Sub
   Private Function ValidaRubro() As Boolean
      If cmbRubros.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar una Rubro")
         cmbRubros.Focus()
         Return False
      End If
      If ExisteRubro(cmbRubros.ValorSeleccionado(0I)) Then
         ShowMessage("Ya existe la Rubro.")
         cmbRubros.Focus()
         Return False
      End If
      If txtDescuentoRubro.ValorNumericoPorDefecto(0D) = 0D And txtDescuentoRubro2.ValorNumericoPorDefecto(0D) = 0D Then
         ShowMessage("Debe cargar algún descuento de rubro")
         txtDescuentoRubro.Focus()
         Return False
      End If
      If txtDescuentoRubro.ValorNumericoPorDefecto(0D) >= 100 Then
         ShowMessage("El descuento 1 de Rubro no puede debe ser menor a 100%")
         txtDescuentoRubro.Focus()
         Return False
      End If
      If txtDescuentoRubro2.ValorNumericoPorDefecto(0D) >= 100 Then
         ShowMessage("El descuento 2 de Rubro no puede debe ser menor a 100%")
         txtDescuentoRubro2.Focus()
         Return False
      End If
      Return True
   End Function
   Private Function ExisteRubro(idRubro As Integer) As Boolean
      Return ugDescuentosRubros.DataSource(Of DataTable).Any(Function(dr) dr.RowState <> DataRowState.Deleted AndAlso dr.Field(Of Integer)("IdRubro") = idRubro)
   End Function
   Private Sub AgregarRubro()
      Dim dr = ugDescuentosRubros.DataSource(Of DataTable).NewRow()

      dr("IdCliente") = Cliente.IdCliente
      dr("IdRubro") = cmbRubros.ValorSeleccionado(0I)
      dr("NombreRubro") = cmbRubros.Text
      dr("DescuentoRecargoPorc1") = txtDescuentoRubro.ValorNumericoPorDefecto(0D)
      dr("DescuentoRecargoPorc2") = txtDescuentoRubro2.ValorNumericoPorDefecto(0D)

      ugDescuentosRubros.DataSource(Of DataTable).Rows.Add(dr)
      ugDescuentosRubros.Rows.Refresh(RefreshRow.ReloadData)
   End Sub
   Private Sub EliminarLineaRubro(dr As DataRow)
      If dr IsNot Nothing Then
         dr.Delete()
         ugDescuentosRubros.Rows.Refresh(RefreshRow.ReloadData)
      End If
   End Sub

#End Region
#Region "Descuentos Productos"
   Private Sub btnRefrescarProductos_Click(sender As Object, e As EventArgs) Handles btnRefrescarProductos.Click
      TryCatched(Sub() LimpiaDescuentoProductos())
   End Sub
   Private Sub btnInsertarProductos_Click(sender As Object, e As EventArgs) Handles btnInsertarProductos.Click
      TryCatched(
      Sub()
         If ValidaProducto() Then
            AgregarProducto()
            LimpiaDescuentoProductos()
         End If
      End Sub)
   End Sub
   Private Sub btnEliminarProductos_Click(sender As Object, e As EventArgs) Handles btnEliminarProductos.Click
      TryCatched(
      Sub()
         Dim dr = ugDescuentosProductos.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            If ShowPregunta("¿Esta seguro de eliminar el Descuento seleccionado?") = Windows.Forms.DialogResult.Yes Then
               EliminarLineaMarca(dr)
            End If
         End If
      End Sub)
   End Sub
   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto)
         bscCodigoProducto.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, 0, "VENTAS")
      End Sub)
   End Sub
   Private Sub bscProducto_BuscadorClick() Handles bscProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto)
         bscProducto.Datos = New Reglas.Productos().GetPorNombre(bscProducto.Text.Trim(), actual.Sucursal.Id, 0, "VENTAS")
      End Sub)
   End Sub
   Private Sub bscCodigoProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion, bscProducto.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
      If Not e.FilaDevuelta Is Nothing Then
         Me.CargarProducto(e.FilaDevuelta)
      End If
   End Sub
   Private Sub controlesProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescuentoProducto.KeyDown, txtDescuentoProducto2.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub LimpiaDescuentoProductos()
      bscCodigoProducto.Text = ""
      bscProducto.Text = ""
      txtDescuentoProducto.SetValor(0D)
      txtDescuentoProducto2.SetValor(0D)
      bscCodigoProducto.Permitido = True
      bscProducto.Permitido = True
      bscCodigoProducto.Focus()
   End Sub
   Private Function ValidaProducto() As Boolean
      If Not bscCodigoProducto.Selecciono And Not bscProducto.Selecciono Then
         ShowMessage("Debe seleccionar una Producto")
         bscCodigoProducto.Focus()
         Return False
      End If
      If ExisteProducto(bscCodigoProducto.Text) Then
         ShowMessage("Ya existe el Producto.")
         bscCodigoProducto.Focus()
         Return False
      End If
      If txtDescuentoProducto.ValorNumericoPorDefecto(0D) = 0D And txtDescuentoProducto2.ValorNumericoPorDefecto(0D) = 0D Then
         ShowMessage("Debe cargar algún descuento de producto")
         txtDescuentoProducto.Focus()
         Return False
      End If
      If txtDescuentoProducto.ValorNumericoPorDefecto(0D) >= 100 Then
         ShowMessage("El descuento 1 de Producto no puede debe ser menor a 100%")
         txtDescuentoProducto.Focus()
         Return False
      End If
      If txtDescuentoProducto2.ValorNumericoPorDefecto(0D) >= 100 Then
         ShowMessage("El descuento 2 de Producto no puede debe ser menor a 100%")
         txtDescuentoProducto2.Focus()
         Return False
      End If
      Return True
   End Function
   Private Function ExisteProducto(idProducto As String) As Boolean
      Return ugDescuentosProductos.DataSource(Of DataTable).Any(Function(dr) dr.RowState <> DataRowState.Deleted AndAlso dr.Field(Of String)("IdProducto") = idProducto)
   End Function
   Private Sub AgregarProducto()
      Dim dr = ugDescuentosProductos.DataSource(Of DataTable).NewRow()

      dr("IdCliente") = Cliente.IdCliente
      dr("IdProducto") = bscCodigoProducto.Text
      dr("NombreProducto") = Me.bscProducto.Text
      dr("DescuentoRecargoPorc1") = txtDescuentoProducto.ValorNumericoPorDefecto(0D)
      dr("DescuentoRecargoPorc2") = txtDescuentoProducto2.ValorNumericoPorDefecto(0D)

      ugDescuentosProductos.DataSource(Of DataTable).Rows.Add(dr)
      ugDescuentosProductos.Rows.Refresh(RefreshRow.ReloadData)
   End Sub
   Private Sub EliminarLineaProducto(dr As DataRow)
      If dr IsNot Nothing Then
         dr.Delete()
         ugDescuentosProductos.Rows.Refresh(RefreshRow.ReloadData)
      End If
   End Sub
   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto.Permitido = False
         bscProducto.Permitido = False
         txtDescuentoProducto.Focus()
      End If
   End Sub



#End Region

End Class