Public Class ProveedoresDetalle

#Region "Campos"

   Public ReadOnly Property Proveedor() As Entidades.Proveedor
      Get
         Return DirectCast(_entidad, Entidades.Proveedor)
      End Get
   End Property

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private _ExistCompraBlanco As Boolean = False
   Private _tmpNombreProveedor As String

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.Proveedor)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      _publicos = New Publicos()

      _publicos.CargaComboTipoDocumento(cmbTipoDoc, Entidades.Publicos.SiNoTodos.SI)
      _publicos.CargaComboCategoriasFiscales(cmbCategoriaFiscal)
      _publicos.CargaComboCategoriasProveedores(cmbCategorias)
      _publicos.CargaComboRubrosCompras(cboRubro)
      _publicos.CargaComboRegimenes(cmbRegimenes, Entidades.TipoImpuesto.Tipos.RGANA.ToString()) '' "RGANA")
      _publicos.CargaComboRegimenes(cmbRegimenesGan, Entidades.TipoImpuesto.Tipos.RGANA.ToString()) '' "RGANA")
      _publicos.CargaComboRegimenes(cmbRegimenesIVA, Entidades.TipoImpuesto.Tipos.RIVA.ToString()) '' "RIVA")
      _publicos.CargaComboRegimenes(cmbRegimenesIIBB, Entidades.TipoImpuesto.Tipos.RIIBB.ToString()) '' "RIIBB")
      _publicos.CargaComboRegimenes(cmbRegimenesIIBBComplem, Entidades.TipoImpuesto.Tipos.RIIBC.ToString()) '' "RIIBBComplem")
      _publicos.CargaComboFormasDePago(cmbFormaPago, "COMPRAS")
      _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, False, "COMPRAS", , , , True)

      _publicos.CargaComboAFIPConceptoCM05(cmbAFIPConceptoCM05, Entidades.AFIPConceptoCM05.TiposConceptosCM05.GASTOS)

      _liSources.Add("CategoriaFiscal", Proveedor.CategoriaFiscal)
      _liSources.Add("Categoria", Proveedor.Categoria)
      _liSources.Add("RubroCompra", Proveedor.RubroCompra)
      _liSources.Add("CuentaDeCaja", Proveedor.CuentaDeCaja)
      _liSources.Add("CuentaBanco", Proveedor.CuentaBanco)
      _liSources.Add("Regimen", Proveedor.Regimen)
      _liSources.Add("RegimenGAN", Proveedor.RegimenGan)
      _liSources.Add("RegimenIVA", Proveedor.RegimenIVA)
      _liSources.Add("RegimenIIBB", Proveedor.RegimenIIBB)
      '-- REQ-43842.- ----------------------------------------------------
      _liSources.Add("RegimenIIBBComplem", Proveedor.RegimenIIBBComplem)
      '-------------------------------------------------------------------

      BindearControles(_entidad, _liSources)

      tbcProveedor.SelectedTab = Me.tbpImpuestos

      cmbRegimenes.Enabled = False
      cmbRegimenesGan.Enabled = False
      cmbRegimenesIVA.Enabled = False
      cmbRegimenesIIBB.Enabled = False
      cmbRegimenesIIBBComplem.Enabled = False
      chbPasibleRetencion.Checked = Proveedor.EsPasibleRetencion
      chbPasibleRetencionIVA.Checked = Proveedor.EsPasibleRetencionIVA
      chbPasibleRetencionIIBB.Checked = Proveedor.EsPasibleRetencionIIBB

      If StateForm = StateForm.Insertar Then

         'Me.cmbTipoDoc.Text = Publicos.TipoDocumentoProveedor()

         chbActivo.Checked = True

         tbcProveedor.SelectedTab = tbpDatos

         'Me.bscCodigoLocalidad.Text = actual.Sucursal.Localidad.IdLocalidad.ToString()
         If DirectCast(_entidad, Entidades.Proveedor).IdLocalidadProveedor = 0 Then
            bscCodigoLocalidad.Text = actual.Sucursal.LocalidadComercial.IdLocalidad.ToString()
         Else
            bscCodigoLocalidad.Text = DirectCast(_entidad, Entidades.Proveedor).IdLocalidadProveedor.ToString()
         End If
         bscCodigoLocalidad.PresionarBoton()

         tbcProveedor.SelectedTab = tbpDatos

         If cmbCategorias.Items.Count = 1 Then
            cmbCategorias.SelectedIndex = 0
         End If

         bscCuentaCaja.Text = Reglas.Publicos.CtaCajaPago.ToString()
         bscCuentaCaja.PresionarBoton()


         bscCuentaBanco.Text = Reglas.Publicos.CtaBancoTransfBancaria.ToString()
         bscCuentaBanco.PresionarBoton()

         If Reglas.Publicos.TieneModuloContabilidad Then
            UcCuentas1.Cuenta = Nothing
         Else
            If tbcProveedor.TabPages.Contains(tbpContabilidad) Then tbcProveedor.TabPages.Remove(tbpContabilidad)
         End If

         'Me.txtNroDoc.Focus()      'No funciona
         CargarProximoCodigo()

      Else
         txtCodigoProveedor.Tag = Proveedor.IdProveedor

         tbcProveedor.SelectedTab = tbpDatos

         bscCodigoLocalidad.PresionarBoton()

         tbcProveedor.SelectedTab = tbpDatos

         If Proveedor.IdTipoComprobante <> "" Then
            chbComprobanteDeCompras.Checked = True
            cmbTiposComprobantes.SelectedValue = Proveedor.IdTipoComprobante
         End If

         If Proveedor.IdFormasPago <> 0 Then
            chbFormaPago.Checked = True
         End If

         If DirectCast(Me._entidad, Entidades.Proveedor).IdTransportista <> 0 Then
            Me.bscCodigoTransportista.Text = DirectCast(Me._entidad, Entidades.Proveedor).IdTransportista.ToString()
            Me.bscCodigoTransportista.PresionarBoton()
            Me.bscNombreTransportista.Selecciono = True
            Me.chbTransportista.Checked = True
         End If

         bscCuentaCaja.Text = Proveedor.CuentaDeCaja.IdCuentaCaja.ToString()
         bscCuentaCaja.PresionarBoton()
         bscNombreCuentaCaja.Selecciono = True

         bscCuentaBanco.Text = Proveedor.CuentaBanco.IdCuentaBanco.ToString()
         bscCuentaBanco.PresionarBoton()

         If Proveedor.PorCtaOrden Then
            chbPorCtaOrden.Checked = True
         End If

         pcbFoto.Image = Proveedor.Foto

         chbPasibleRetencion2.Checked = Proveedor.RegimenGan.IdRegimen > 0
         '-- REG-43842.- -------------------------------------------------------------
         chbRetencionIIBBComplem.Checked = Proveedor.RegimenIIBBComplem.IdRegimen > 0
         '----------------------------------------------------------------------------
         If Reglas.Publicos.TieneModuloContabilidad Then
            UcCuentas1.Cuenta = Proveedor.CuentaContable
         Else
            If tbcProveedor.TabPages.Contains(tbpContabilidad) Then tbcProveedor.TabPages.Remove(tbpContabilidad)
         End If

         txtNivelAutorizacion.Visible = New Reglas.Usuarios().TienePermisos("Proveedores-NivelAutorizacion")
         txtNivelAutorizacion.LabelAsoc.Visible = txtNivelAutorizacion.Visible

         Dim rCompras = New Reglas.Compras()

         _tmpNombreProveedor = Proveedor.NombreProveedor
         _ExistCompraBlanco = rCompras.ProveedorPoseeFacturas(Proveedor.IdProveedor, True)
         chbEsProveedorGenerico.Enabled = Not New Reglas.Compras().ProveedorPoseeFacturas(Proveedor.IdProveedor, grabaLibro:=Nothing)

         If _ExistCompraBlanco Then
            If Not String.IsNullOrWhiteSpace(txtCuit.Text) AndAlso Publicos.EsCuitValido(txtCuit.Text) Then
               txtCuit.ReadOnly = True
            End If
            If txtNroDoc.ValorNumericoPorDefecto(0L) <> 0 Then
               cmbTipoDoc.Enabled = False
               txtNroDoc.ReadOnly = True
            Else
               cmbTipoDoc.Enabled = True
               txtNroDoc.ReadOnly = False
            End If
         End If

         chbAFIPConceptoCM05.Checked = Proveedor.IdConceptoCM05.HasValue

         If Not Reglas.Publicos.AFIPUtilizaCM05 Then
            chbAFIPConceptoCM05.Checked = False
            chbAFIPConceptoCM05.Enabled = False
         End If

         If Proveedor.IdClienteVinculado.HasValue Then
            Dim prevTab = tbcProveedor.SelectedTab
            tbcProveedor.SelectedTab = tbpOtros
            Dim clienteCtaCte = New Reglas.Clientes().GetUnoLiviando(Proveedor.IdClienteVinculado.Value)
            chbClienteVinculado.Checked = True
            bscCodigoClienteVinculado.Text = clienteCtaCte.CodigoCliente.ToString()
            bscCodigoClienteVinculado.PresionarBoton()
            tbcProveedor.SelectedTab = prevTab
         End If
      End If

      bscCuentaCaja.Visible = False
      bscCuentaBanco.Visible = False

      If Not Reglas.Publicos.RetieneGanancias Then
         chbPasibleRetencion.Visible = False
         lblRegimen.Visible = False
         cmbRegimenes.Visible = False
         lblNroRegimen.Visible = False
         chbPasibleRetencion2.Visible = False
         cmbRegimenesGan.Visible = False
         lblNroRegimenGan.Visible = False
         chbPasibleRetencionIVA.Visible = False
         cmbRegimenesIVA.Visible = False
         lblNroRegimenIVA.Visible = False
         chbPasibleRetencionIIBB.Visible = False
         cmbRegimenesIIBB.Visible = False
         lblNroRegimenIIBB.Visible = False
         '-- REQ-43842.- ---------------------------
         chbRetencionIIBBComplem.Visible = False
         cmbRegimenesIIBBComplem.Visible = False
         lblNroRegimenIIBBComplem.Visible = False
         '------------------------------------------
      End If

      tbcProveedor.SelectedTab = tbpDatos

      _estaCargando = False

      If Not Reglas.Publicos.TieneModuloContratistas Then
         tbcProveedor.TabPages.Remove(tbpContratistas)
      End If
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Proveedores()
   End Function

   Protected Overrides Sub Aceptar()
      If StateForm = StateForm.Actualizar Then
         If (_tmpNombreProveedor <> txtNombre.Text) And (_ExistCompraBlanco = True) Then
            If MessageBox.Show("El proveedor tiene registradas facturas, desea  cambiar el nombre de proveedor", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
               HayError = True
               Exit Sub
            End If
         End If
      End If

      Proveedor.EsPasibleRetencion = chbPasibleRetencion.Checked
      Proveedor.EsPasibleRetencionIVA = chbPasibleRetencionIVA.Checked
      Proveedor.EsPasibleRetencionIIBB = chbPasibleRetencionIIBB.Checked

      If cmbRegimenes.SelectedItem IsNot Nothing And chbPasibleRetencion.Checked Then
         Proveedor.Regimen = cmbRegimenes.ItemSeleccionado(Of Entidades.Regimen)
      Else
         Proveedor.Regimen = Nothing
      End If
      If cmbRegimenesGan.SelectedItem IsNot Nothing And chbPasibleRetencion2.Checked Then
         Proveedor.RegimenGan = cmbRegimenesGan.ItemSeleccionado(Of Entidades.Regimen)
      Else
         Proveedor.RegimenGan = Nothing
      End If
      If cmbRegimenesIVA.SelectedItem IsNot Nothing And chbPasibleRetencionIVA.Checked Then
         Proveedor.RegimenIVA = cmbRegimenesIVA.ItemSeleccionado(Of Entidades.Regimen)
      Else
         Proveedor.RegimenIVA = Nothing
      End If
      If cmbRegimenesIIBB.SelectedItem IsNot Nothing And chbPasibleRetencionIIBB.Checked Then
         Proveedor.RegimenIIBB = cmbRegimenesIIBB.ItemSeleccionado(Of Entidades.Regimen)
      Else
         Proveedor.RegimenIIBB = Nothing
      End If
      '-- REG-43842.- ---------------------------------------------------------------------------------
      If cmbRegimenesIIBBComplem.SelectedItem IsNot Nothing And chbRetencionIIBBComplem.Checked Then
         Proveedor.RegimenIIBBComplem = cmbRegimenesIIBBComplem.ItemSeleccionado(Of Entidades.Regimen)
      Else
         Proveedor.RegimenIIBBComplem = Nothing
      End If
      '-------------------------------------------------------------------------------------------------
      Proveedor.IdConceptoCM05 = cmbAFIPConceptoCM05.ValorSeleccionado(Of Integer?)(chbAFIPConceptoCM05, Nothing)

      If Not dtpFechaHigSeg.Checked Then
         Proveedor.FechaHigSeg = Nothing
      End If
      If Not dtpFechaRes559.Checked Then
         Proveedor.FechaRes559 = Nothing
      End If
      If Not dtpFechaIndiceInc.Checked Then
         Proveedor.FechaIndiceInc = Nothing
      End If

      If Not dtpFechaIndemnidad.Checked Then
         Proveedor.FechaIndemnidad = Nothing
      End If

      If Reglas.Publicos.TieneModuloContabilidad Then
         Proveedor.CuentaContable = UcCuentas1.Cuenta
      Else
         Proveedor.CuentaContable = Nothing
      End If

      If chbClienteVinculado.Checked Then
         Proveedor.IdClienteVinculado = If(IsNumeric(bscCodigoClienteVinculado.Tag), Long.Parse(bscCodigoClienteVinculado.Tag.ToString()), Nothing)
      Else
         Proveedor.IdClienteVinculado = Nothing
      End If

      MyBase.Aceptar()

      If Not HayError Then Close()
      txtCodigoProveedor.Focus()

   End Sub

   Protected Overrides Function ValidarDetalle() As String

      Dim result = New Reglas.Validaciones.ValidacionResult()

      '######################################################################
      '# Si el proveedor es eventual, no se verificará el ingreso del CUIT  #
      '######################################################################
      If Not chbEsProveedorGenerico.Checked Then
         'valido que si la categoria fiscal solicita CUIT controle que el campo de CUIT lo haya cargado en el ABM
         result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() _
                                                                                   With {.IdFiscal = txtCuit.Text,
                                                                                         .SolicitaCUIT = Proveedor.CategoriaFiscal.SolicitaCUIT})
      End If

      If result.Error Then
         tbcProveedor.SelectedTab = tbpDatos
         txtCuit.Focus()
         Return result.MensajeError
      End If

      '# CBU Cuit
      result = New Reglas.Validaciones.ValidacionResult()
      If Not chbEsProveedorGenerico.Checked Then
         'valido que si la categoria fiscal solicita CUIT controle que el campo de CUIT lo haya cargado en el ABM
         result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() _
                                                                                   With {.IdFiscal = txtCBUCuit.Text,
                                                                                         .SolicitaCUIT = False}) '# El campo es opcional, por lo que no debe validar si la categoría fiscal solicita CUIT
      End If
      If result.Error Then
         tbcProveedor.SelectedTab = tbpOtros
         txtCuit.Focus()
         Return result.MensajeError
      End If

      If Long.Parse("0" & txtNroDoc.Text) > 0 And cmbTipoDoc.SelectedIndex = -1 Then
         Return "Falta Indicar el Tipo de Documento."
      End If

      If Long.Parse("0" & txtNroDoc.Text) <> 0 And cmbTipoDoc.SelectedIndex <> -1 Then
         If Long.Parse(txtNroDoc.Text.ToString()) < 1000000 Then
            Return "Numero de documento no válido"
         End If
      End If

      If String.IsNullOrEmpty(txtDireccion.Text) Then
         Return "El campo Dirección es requerido."
      End If

      If Not bscNombreCuentaCaja.Selecciono Then
         bscNombreCuentaCaja.Focus()
         Return "No selecciono la Cuenta de Caja."
      End If

      If Not bscNombreCuentaBanco.Selecciono Then
         bscNombreCuentaBanco.Focus()
         Return "No selecciono la Cuenta de Banco."
      End If

      If chbPasibleRetencion.Checked Then
         If cmbRegimenes.SelectedIndex = -1 Then
            cmbRegimenes.Focus()
            Return "Si es pasible de retencion de ganancias debe seleccionar un Régimen para el mismo."
         End If
      End If

      If chbPasibleRetencion2.Checked Then
         If cmbRegimenesGan.SelectedIndex = -1 Then
            cmbRegimenesGan.Focus()
            Return "Si es pasible de retencion de ganancias debe seleccionar un Régimen para el mismo."
         End If
      End If

      If chbPasibleRetencionIVA.Checked Then
         If cmbRegimenesIVA.SelectedIndex = -1 Then
            cmbRegimenesIVA.Focus()
            Return "Si es pasible de retencion de IVA debe seleccionar un Régimen para el mismo."
         End If
      End If

      If chbPasibleRetencionIIBB.Checked Then
         If cmbRegimenesIIBB.SelectedIndex = -1 Then
            cmbRegimenesIIBB.Focus()
            Return "Si es pasible de retencion de IIBB debe seleccionar un Régimen para el mismo."
         End If
      End If
      '-- REQ-43842.- -------------------------------------------------------------------------------------------
      If chbRetencionIIBBComplem.Checked Then
         If cmbRegimenesIIBBComplem.SelectedIndex = -1 Then
            cmbRegimenesIIBBComplem.Focus()
            Return "Si es pasible de retencion de IIBB Complementaria debe seleccionar un Régimen para el mismo."
         End If
      End If
      '----------------------------------------------------------------------------------------------------------

      If chbAFIPConceptoCM05.Checked And cmbAFIPConceptoCM05.SelectedIndex = -1 Then
         tbcProveedor.SelectedTab = tbpImpuestos
         cmbAFIPConceptoCM05.Select()
         Return "ATENCION: Activo el Concepto de CM05 pero no seleccionó uno. Debe elegir una."
      End If

      If chbComprobanteDeCompras.Checked And cmbTiposComprobantes.SelectedIndex = -1 Then
         tbcProveedor.SelectedTab = tbpOtros
         cmbTiposComprobantes.Focus()
         Return "ATENCION: Activo el Comprobante de Compras por Defecto. Debe elegir uno."
      End If

      If chbFormaPago.Checked And cmbFormaPago.SelectedIndex = -1 Then
         cmbFormaPago.Focus()
         Return "ATENCION: Activo la Forma de Pago por Defecto. Debe elegir una."
      End If

      If chbTransportista.Checked And bscNombreTransportista.Text = String.Empty Then
         bscNombreTransportista.Focus()
         Return "ATENCION: Activo el Transportista por Defecto. Debe elegir un Transportista."
      End If

      If chbPorCtaOrden.Checked And pcbFoto.Image Is Nothing Then
         btnBuscarImagen.Focus()
         Return "ATENCION: Activo Por Cuenta y Orden. Debe elegir un Logo."
      End If

      If Not String.IsNullOrEmpty(txtCBU.Text.Trim()) AndAlso txtCBU.Text.Trim() <> "0" AndAlso txtCBU.Text.Trim().Length <> 22 Then
         txtCBU.Focus()
         Return "El CBU es Inválido, debe contener 22 digitos y es de " & Me.txtCBU.Text.Trim.Length.ToString() & "'."
      End If

      If Not String.IsNullOrEmpty(txtCBUAlias.Text.Trim()) AndAlso txtCBUAlias.Text.Trim().Length < 6 Then
         txtCBUAlias.Focus()
         Return "El CBU Alias debe contener entre 6 y 20 caracteres alfanuméricos y es de " & Me.txtCBUAlias.Text.Trim.Length.ToString() & "."
      End If

      '# Si el proveedor asignó un CBU o Alias CBU, es obligatorio que ingrese el CUIT del CBU.-
      If ((Not String.IsNullOrEmpty(txtCBU.Text) AndAlso txtCBU.Text <> "0") Or Not String.IsNullOrEmpty(txtCBUAlias.Text)) AndAlso
         String.IsNullOrEmpty(txtCBUCuit.Text) Then
         txtCBUCuit.Focus()
         Return "Debe ingresar el CUIT asociado al CBU/Alias ingresado."
      End If

      If txtNivelAutorizacion.Visible Then
         If Not IsNumeric(txtNivelAutorizacion.Text) Then txtNivelAutorizacion.Text = "1"
         If Short.Parse(txtNivelAutorizacion.Text) > actual.NivelAutorizacion Then
            tbcProveedor.SelectedTab = tbpDatos
            txtNivelAutorizacion.Focus()
            Return "ATENCION: El nivel de autorización ingresado es superior al suyo."
         End If         'If Short.Parse(txtNivelAutorizacion.Text) > actual.NivelAutorizacion Then
      End If            'If txtNivelAutorizacion.Visible Then

      If chbClienteVinculado.Checked And Not bscCodigoClienteVinculado.Selecciono And Not bscNombreClienteVinculado.Selecciono Then
         tbcProveedor.SelectedTab = tbpOtros
         bscCodigoClienteVinculado.Focus()
         Return "Activo el Cliente Vinculado pero no seleccionó uno."
      End If

      Return MyBase.ValidarDetalle()
   End Function

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
      'Me.cmbTipoDoc.Text = Publicos.TipoDocumentoProveedor()
      'Me.cmbLocalidad.SelectedIndex = -1
      cmbCategoriaFiscal.SelectedIndex = -1
      chbActivo.Checked = True
      'Me.txtCodigoProveedor.Text = String.Empty
   End Sub

#End Region

#Region "Eventos"

   Private Sub ProveedoresDetalle_Shown(sender As Object, e As EventArgs) Handles Me.Shown
      TryCatched(
         Sub()
            If StateForm = StateForm.Actualizar Then
               txtNombre.Focus()
            Else
               txtCodigoProveedor.Focus()
            End If
         End Sub)
   End Sub

   Private Sub lnkLocalidad_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkLocalidad.LinkClicked
      TryCatched(
         Sub()
            Using frmPantLocalidad = New LocalidadesDetalle(New Entidades.Localidad())
               frmPantLocalidad.StateForm = StateForm.Insertar
               frmPantLocalidad.CierraAutomaticamente = True
               If frmPantLocalidad.ShowDialog() = DialogResult.OK Then
                  bscCodigoLocalidad.Text = frmPantLocalidad.txtIdLocalidad.Text
                  bscCodigoLocalidad.PresionarBoton()
               End If
            End Using
         End Sub)
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      TryCatched(
         Sub()
            Dim oLocalidades = New Reglas.Localidades()
            _publicos.PreparaGrillaLocalidades(bscCodigoLocalidad)
            bscCodigoLocalidad.Datos = oLocalidades.GetPorCodigo(bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarLocalidad(e.FilaDevuelta)
               cmbCategoriaFiscal.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNombreLocalidad.BuscadorClick
      TryCatched(
         Sub()
            Dim oLocalidades = New Reglas.Localidades()
            _publicos.PreparaGrillaLocalidades(bscNombreLocalidad)
            bscNombreLocalidad.Datos = oLocalidades.GetPorNombre(bscNombreLocalidad.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscNombreLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreLocalidad.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarLocalidad(e.FilaDevuelta)
               cmbCategoriaFiscal.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscNombreCuentaCaja_BuscadorClick() Handles bscNombreCuentaCaja.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeCajas(bscNombreCuentaCaja)
            Dim oCuentasDeCaja = New Reglas.CuentasDeCajas()
            bscNombreCuentaCaja.Datos = oCuentasDeCaja.GetPorNombre(bscNombreCuentaCaja.Text)
         End Sub)
   End Sub

   Private Sub bscNombreCuentaCaja_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreCuentaCaja.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosCuentaDeCaja(e.FilaDevuelta)
               txtIngresosBrutos.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscCuentaCaja_BuscadorClick() Handles bscCuentaCaja.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeCajas(bscCuentaCaja)
            Dim oCuentasDeCaja = New Reglas.CuentasDeCajas()
            bscCuentaCaja.Datos = oCuentasDeCaja.GetTodas(bscCuentaCaja.Text)
         End Sub)
   End Sub

   Private Sub bscCuentaCaja_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaCaja.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosCuentaDeCaja(e.FilaDevuelta)
               txtIngresosBrutos.Focus()
            End If
         End Sub)
   End Sub

   Private Sub txtCuit_Leave(sender As Object, e As EventArgs) Handles txtCuit.Leave
      TryCatched(
         Sub()
            If String.IsNullOrEmpty(txtCBUCuit.Text) Then
               txtCBUCuit.Text = txtCuit.Text
            End If
         End Sub)
   End Sub

   Private Sub txtCuit_LostFocus(sender As Object, e As EventArgs) Handles txtCuit.LostFocus
      TryCatched(
         Sub()
            If Not String.IsNullOrEmpty(txtCuit.Text) Then
               Dim oProv = New Reglas.Proveedores()
               Using dtCUITs = oProv.GetFiltradoPorCUIT(txtCuit.Text.Trim())
                  For Each dr As DataRow In dtCUITs.Rows
                     If Long.Parse(dr("CodigoProveedor").ToString()) <> Long.Parse(txtCodigoProveedor.Text) Then
                        ShowMessage(String.Format(My.Resources.RTextos.CuitAsignadoOtro, "proveedor", dr("NombreProveedor"), dr("CodigoProveedor")))
                     End If
                  Next
               End Using
            End If
         End Sub)
   End Sub

   Private Sub chbPasibleRetencion_CheckedChanged(sender As Object, e As EventArgs) Handles chbPasibleRetencion.CheckedChanged
      TryCatched(
         Sub()
            If chbPasibleRetencion.Checked Then
               cmbRegimenes.Enabled = True
               chbPasibleRetencion2.Enabled = True
            Else
               cmbRegimenes.Enabled = False
               chbPasibleRetencion2.Enabled = False
            End If
            chbPasibleRetencion2_CheckedChanged(sender, e)
         End Sub)
   End Sub

   Private Sub chbPasibleRetencion2_CheckedChanged(sender As Object, e As EventArgs) Handles chbPasibleRetencion2.CheckedChanged
      TryCatched(Sub() cmbRegimenesGan.Enabled = chbPasibleRetencion2.Checked)
   End Sub

   Private Sub chbPasibleRetencionIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbPasibleRetencionIVA.CheckedChanged
      TryCatched(Sub() cmbRegimenesIVA.Enabled = chbPasibleRetencionIVA.Checked)
   End Sub

   Private Sub chbPasibleRetencionIIBB_CheckedChanged(sender As Object, e As EventArgs) Handles chbPasibleRetencionIIBB.CheckedChanged
      TryCatched(
         Sub()
            cmbRegimenesIIBB.Enabled = chbPasibleRetencionIIBB.Checked
            chbRetencionIIBBComplem.Enabled = chbPasibleRetencionIIBB.Checked
            If Not chbPasibleRetencionIIBB.Checked Then
               chbRetencionIIBBComplem.Checked = False
            End If
            chbRetencionIIBBComplem_CheckedChanged(sender, e)
         End Sub)
   End Sub

   Private Sub cmbRegimenes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRegimenes.SelectedIndexChanged
      TryCatched(
         Sub()
            If cmbRegimenes.SelectedIndex = -1 Then
               lblNroRegimen.Text = "Nro. "
            Else
               lblNroRegimen.Text = "Nro. " + DirectCast(cmbRegimenes.SelectedItem, Entidades.Regimen).IdRegimen.ToString()
            End If
         End Sub)
   End Sub

   Private Sub cmbRegimenesGan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRegimenesGan.SelectedIndexChanged
      TryCatched(
         Sub()
            If cmbRegimenesGan.SelectedIndex = -1 Then
               lblNroRegimenGan.Text = "Nro. "
            Else
               lblNroRegimenGan.Text = "Nro. " + DirectCast(cmbRegimenesGan.SelectedItem, Entidades.Regimen).IdRegimen.ToString()
            End If
         End Sub)
   End Sub

   Private Sub cmbRegimenesIVA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRegimenesIVA.SelectedIndexChanged
      TryCatched(
         Sub()
            If cmbRegimenesIVA.SelectedIndex = -1 Then
               lblNroRegimenIVA.Text = "Nro. "
            Else
               lblNroRegimenIVA.Text = "Nro. " + DirectCast(cmbRegimenesIVA.SelectedItem, Entidades.Regimen).IdRegimen.ToString()
            End If
         End Sub)
   End Sub

   Private Sub cmbRegimenesIIBB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRegimenesIIBB.SelectedIndexChanged
      TryCatched(
         Sub()
            If cmbRegimenesIIBB.SelectedIndex = -1 Then
               lblNroRegimenIIBB.Text = "Nro. "
            Else
               lblNroRegimenIIBB.Text = "Nro. " + DirectCast(cmbRegimenesIIBB.SelectedItem, Entidades.Regimen).IdRegimen.ToString()
            End If
         End Sub)
   End Sub

   Private Sub chbAFIPConceptoCM05_CheckedChanged(sender As Object, e As EventArgs) Handles chbAFIPConceptoCM05.CheckedChanged

      If Not chbAFIPConceptoCM05.Checked Then
         cmbAFIPConceptoCM05.SelectedIndex = -1
         Proveedor.IdConceptoCM05 = Nothing
      End If

      cmbAFIPConceptoCM05.Enabled = chbAFIPConceptoCM05.Checked

      If chbAFIPConceptoCM05.Checked Then
         cmbAFIPConceptoCM05.Select()
      End If

   End Sub

   Private Sub chbComprobanteFacturacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbComprobanteDeCompras.CheckedChanged
      TryCatched(
         Sub()
            If Not chbComprobanteDeCompras.Checked Then
               cmbTiposComprobantes.SelectedIndex = -1
               Proveedor.IdTipoComprobante = ""
            End If

            cmbTiposComprobantes.Enabled = chbComprobanteDeCompras.Checked

            If chbComprobanteDeCompras.Checked Then
               cmbTiposComprobantes.Focus()
            End If
         End Sub)
   End Sub

   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged
      TryCatched(
         Sub()
            If Not chbFormaPago.Checked Then
               cmbFormaPago.SelectedIndex = -1
               Proveedor.IdFormasPago = 0
            End If

            cmbFormaPago.Enabled = chbFormaPago.Checked

            If chbFormaPago.Checked Then
               cmbFormaPago.Focus()
            End If
         End Sub)
   End Sub

   Private Sub lnkLocalidad_LinkClicked_1(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLocalidad.LinkClicked
      TryCatched(
         Sub()
            Using frm = New LocalidadesDetalle(New Entidades.Localidad())
               frm.StateForm = StateForm.Insertar
               frm.CierraAutomaticamente = True
               If frm.ShowDialog() = DialogResult.OK Then
                  bscCodigoLocalidad.Text = frm.txtIdLocalidad.Text
                  bscCodigoLocalidad.PresionarBoton()
               End If
            End Using
         End Sub)
   End Sub

#Region "Eventos Buscador Cliente Vinculado"
   Private Sub chbClienteVinculado_CheckedChanged(sender As Object, e As EventArgs) Handles chbClienteVinculado.CheckedChanged
      TryCatched(Sub() chbClienteVinculado.FiltroCheckedChanged(usaPermitido:=True, bscCodigoClienteVinculado, bscNombreClienteVinculado))
   End Sub

   Private Sub bscCodigoClienteCtaCte_BuscadorClick() Handles bscCodigoClienteVinculado.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoClienteVinculado)
         Dim codigoCliente = bscCodigoClienteVinculado.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoClienteVinculado.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscNombreClienteVinculado_BuscadorClick() Handles bscNombreClienteVinculado.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscNombreClienteVinculado)
         bscNombreClienteVinculado.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscNombreClienteVinculado.Text.Trim(), True)
      End Sub)
   End Sub
   Private Sub bscCodigoClienteVinculado_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoClienteVinculado.BuscadorSeleccion, bscNombreClienteVinculado.BuscadorSeleccion
      TryCatched(Sub() CargarDatosClienteVinculado(e.FilaDevuelta))
   End Sub
#End Region


   Private Sub btnBuscarImagen_Click(sender As Object, e As EventArgs) Handles btnBuscarImagen.Click
      TryCatched(
         Sub()
            If ofdArchivos.ShowDialog() = DialogResult.OK Then
               If Not String.IsNullOrEmpty(ofdArchivos.FileName) Then
                  If IO.File.ReadAllBytes(ofdArchivos.FileName).Length > Reglas.Publicos.TamañoMaximoImagenes Then
                     MessageBox.Show("El tamaño de la imagen no puede ser mayor a " + (Reglas.Publicos.TamañoMaximoImagenes / 1000).ToString() + "KB", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Exit Sub
                  End If
                  pcbFoto.Image = New Bitmap(ofdArchivos.FileName)
                  Proveedor.Foto = pcbFoto.Image
               End If
            End If
         End Sub)
   End Sub

   Private Sub btnLimpiarImagen_Click(sender As Object, e As EventArgs) Handles btnLimpiarImagen.Click
      TryCatched(
         Sub()
            Proveedor.Foto = Nothing
            pcbFoto.Image = Nothing
         End Sub)
   End Sub

   Private Sub cmbCategoriaFiscal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoriaFiscal.SelectedIndexChanged
      TryCatched(
         Sub()
            If _estaCargando Then Exit Sub
            Proveedor.CategoriaFiscal = DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)
         End Sub)
   End Sub

   Private Sub bscCuentaBanco_BuscadorClick() Handles bscCuentaBanco.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeBancos2(bscCuentaBanco)
            Dim oCBancos = New Reglas.CuentasBancos()
            bscCuentaBanco.Datos = oCBancos.GetTodosPorCodigo(bscCuentaBanco.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscCuentaBanco_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBanco.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosCuentaBanco(e.FilaDevuelta)
            End If
         End Sub)
   End Sub

   Private Sub bscNombreCuentaBanco_BuscadorClick() Handles bscNombreCuentaBanco.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeBancos2(bscNombreCuentaBanco)
            Dim oCBancos = New Reglas.CuentasBancos()
            bscNombreCuentaBanco.Datos = oCBancos.GetTodosPorNombre(bscNombreCuentaBanco.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscNombreCuentaBanco_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreCuentaBanco.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosCuentaBanco(e.FilaDevuelta)
            End If
         End Sub)
   End Sub

   Private Sub chbTransportista_CheckedChanged(sender As Object, e As EventArgs) Handles chbTransportista.CheckedChanged

      If Not Me.chbTransportista.Checked Then
         Me.bscCodigoTransportista.Text = ""
         Me.bscNombreTransportista.Text = ""
         DirectCast(Me._entidad, Entidades.Proveedor).IdTransportista = 0
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



#End Region

#Region "Metodos"

   Private Sub CargarProximoCodigo()
      Dim oProveedor = New Reglas.Proveedores()
      Dim ProximoProveedor = oProveedor.GetCodigoMaximo(Entidades.Proveedor.Columnas.CodigoProveedor.ToString()) + 1
      txtCodigoProveedor.Text = ProximoProveedor.ToString()
   End Sub

   Private Sub CargarLocalidad(dr As DataGridViewRow)
      Proveedor.IdLocalidadProveedor = Integer.Parse(dr.Cells("IdLocalidad").Value.ToString())
      bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
   End Sub

   Private Sub CargarDatosCuentaDeCaja(dr As DataGridViewRow)
      Proveedor.CuentaDeCaja.IdCuentaCaja = Integer.Parse(dr.Cells("IdCuentaCaja").Value.ToString())
      bscCuentaCaja.Text = dr.Cells("IdCuentaCaja").Value.ToString()
      bscNombreCuentaCaja.Text = dr.Cells("NombreCuentaCaja").Value.ToString()
      bscNombreCuentaCaja.Selecciono = True
   End Sub

   Private Sub CargarDatosCuentaBanco(dr As DataGridViewRow)
      Proveedor.CuentaBanco.IdCuentaBanco = Integer.Parse(dr.Cells("idCuentaBanco").Value.ToString())
      bscCuentaBanco.Text = dr.Cells("idCuentaBanco").Value.ToString()
      bscNombreCuentaBanco.Text = dr.Cells("NombreCuentaBanco").Value.ToString()
      bscNombreCuentaBanco.Selecciono = True
   End Sub

   Private Sub CargarDatosTransportista(dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.Proveedor).IdTransportista = Integer.Parse(dr.Cells("IdTransportista").Value.ToString())
      Me.bscCodigoTransportista.Text = dr.Cells("IdTransportista").Value.ToString()
      Me.bscNombreTransportista.Text = dr.Cells("NombreTransportista").Value.ToString()
   End Sub
   Private Sub CargarDatosClienteVinculado(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreClienteVinculado.Text = dr.Cells(Entidades.Cliente.Columnas.NombreCliente.ToString()).Value.ToString()
         bscCodigoClienteVinculado.Text = dr.Cells(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Value.ToString()
         bscCodigoClienteVinculado.Tag = dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString()
         Proveedor.IdClienteVinculado = Long.Parse(dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString())
      End If
   End Sub

   Private Sub chbRetencionIIBBComplem_CheckedChanged(sender As Object, e As EventArgs) Handles chbRetencionIIBBComplem.CheckedChanged
      TryCatched(Sub()
                    cmbRegimenesIIBBComplem.Enabled = chbRetencionIIBBComplem.Checked
                 End Sub)
   End Sub

   Private Sub cmbRegimenesIIBBComplem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRegimenesIIBBComplem.SelectedIndexChanged
      TryCatched(
         Sub()
            If cmbRegimenesIIBBComplem.SelectedIndex = -1 Then
               lblNroRegimenIIBBComplem.Text = "Nro. "
            Else
               lblNroRegimenIIBBComplem.Text = "Nro. " + DirectCast(cmbRegimenesIIBBComplem.SelectedItem, Entidades.Regimen).IdRegimen.ToString()
            End If
         End Sub)
   End Sub
#End Region

End Class
