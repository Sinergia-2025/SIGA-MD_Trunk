Option Strict On
Imports Eniac.Reglas
Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.MapProviders
Imports Infragistics.Win.UltraWinGrid
Imports Eniac.Reglas.WSPN4

Public Class EmpleadosDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private _finOnLoad As Boolean = False
   Private _titEmpleadoObjetivo As Dictionary(Of String, String)
   Private _entEmpleadoObjetivo As List(Of Entidades.EmpleadoObjetivo)
#End Region

#Region "Propiedades"

   Private ReadOnly Property Cobrador As Entidades.Empleado
      Get
         Return DirectCast(_entidad, Entidades.Empleado)
      End Get
   End Property

   Public ReadOnly Property ComisionesMarcas() As DataTable
      Get
         If DirectCast(Me._entidad, Entidades.Empleado).Comisiones IsNot Nothing Then
            If DirectCast(Me._entidad, Entidades.Empleado).Comisiones.Tables.Contains(Entidades.Empleado.ComisionesMarcasTableName) Then
               Return DirectCast(Me._entidad, Entidades.Empleado).Comisiones.Tables(Entidades.Empleado.ComisionesMarcasTableName)
            End If
         End If
         Return Nothing
      End Get
   End Property

   Public ReadOnly Property ComisionesProductos() As DataTable
      Get
         If DirectCast(Me._entidad, Entidades.Empleado).Comisiones IsNot Nothing Then
            If DirectCast(Me._entidad, Entidades.Empleado).Comisiones.Tables.Contains(Entidades.Empleado.ComisionesProductosTableName) Then
               Return DirectCast(Me._entidad, Entidades.Empleado).Comisiones.Tables(Entidades.Empleado.ComisionesProductosTableName)
            End If
         End If
         Return Nothing
      End Get
   End Property

   Public ReadOnly Property ComisionesRubros() As DataTable
      Get
         If DirectCast(Me._entidad, Entidades.Empleado).Comisiones IsNot Nothing Then
            If DirectCast(Me._entidad, Entidades.Empleado).Comisiones.Tables.Contains(Entidades.Empleado.ComisionesRubrosTableName) Then
               Return DirectCast(Me._entidad, Entidades.Empleado).Comisiones.Tables(Entidades.Empleado.ComisionesRubrosTableName)
            End If
         End If
         Return Nothing
      End Get
   End Property
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.Empleado)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      _publicos = New Publicos()

      _publicos.CargaComboTipoDocumento(Me.cmbTipoDocEmpleado)
      _publicos.CargaComboUsuarios(Me.cmbUsuario)
      _publicos.CargaComboUsuarios(Me.cmbUsuarioMovil)

      _publicos.CargaComboMarcas(Me.cmbMarcas)
      _publicos.CargaComboRubros(Me.cmbRubros)

      _publicos.CargaComboBancos(Me.cmbBanco)
      _publicos.CargaComboCajas(cmbCaja, {actual.Sucursal}, False, False, False)

      _publicos.CargaComboCategoriasEmpleados(cmbCategoriaEmpleado)

      CargaEntidadCobranza(cmbEntidadCobranza)

      '-.PE-31509.-
      Me._publicos.CargaComboTarjetas(Me.cmbTarTarjeta)

      _liSources.Add("EmpleadoSucursal", DirectCast(Me._entidad, Entidades.Empleado).EmpleadoSucursal)

      Me.BindearControles(Me._entidad, Me._liSources)

      If Reglas.Publicos.EmpleadoUtilizaGeolocalizacion Then
         Me.cmbTipoMapa.Text = "Google Maps"
         GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly
         Me.gmcMapa.SetPositionByKeywords("Rosario, Argentina")
         GMapProvider.Language = LanguageType.Spanish
         Me.gmcMapa.Zoom = 11
         Me.gmcMapa.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance
         'CargarMapa()
      End If

      Me.tbcEmpleado.SelectedTab = Me.tbpObjetivos
      _titEmpleadoObjetivo = GetColumnasVisiblesGrilla(ugObjetivos)

      Me._entEmpleadoObjetivo = DirectCast(Me._entidad, Entidades.Empleado).EmpleadoObjetivo
      Me.ugObjetivos.DataSource = Me._entEmpleadoObjetivo

      txtValorHora.Formato = "#0.00"

      FormateaGrilla()
      Dim rFunc = New Reglas.Funciones().ExisteFuncion("MRPProcesosProductivosABM")

      If Not rFunc Then
         Me.tbcEmpleado.TabPages.Remove(tbpProduccion)
      End If


      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
         Me.cmbTipoDocEmpleado.Text = Reglas.Publicos.TipoDocumentoCliente()
         Me.chbEsVendedor.Checked = True
         Me.chbEsComprador.Checked = True
         Me.chbEsCobrador.Checked = True

         cmbCategoriaEmpleado.SelectedIndex = 0

         '-- REQ-33530.- -------------------------------------------------------------
         chbEsTransportista.Checked = False
         bscCodigoTransportista.Text = ""
         bscTransportista.Text = ""
         '----------------------------------------------------------------------------

         'Me.bscCodigoLocalidad.Text = actual.Sucursal.Localidad.IdLocalidad.ToString()
         Me.bscCodigoLocalidad.Text = actual.Sucursal.LocalidadComercial.IdLocalidad.ToString()
         Me.bscCodigoLocalidad.PresionarBoton()
         Me.tbcEmpleado.SelectedTab = Me.tbpDatos
      Else
         '-- REQ-43851.- -------------------------------------------------------------
         cmbEntidadCobranza.SelectedIndex = If(cmbEntidadCobranza.FindStringExact(DirectCast(Me._entidad, Entidades.Empleado).EntidadCobranza) = -1, 0, cmbEntidadCobranza.FindStringExact(DirectCast(Me._entidad, Entidades.Empleado).EntidadCobranza))
         '-- REQ-33530.- -------------------------------------------------------------
         chbEsTransportista.Checked = DirectCast(Me._entidad, Entidades.Empleado).EsChofer
         If chbEsTransportista.Checked Then
            bscCodigoTransportista.Text = DirectCast(Me._entidad, Entidades.Empleado).IdTransportista.ToString()
            bscCodigoTransportista.PresionarBoton()
         End If
         '-- REQ-38946.- -------------------------------------------------------------
         chbResponsableProd.Checked = DirectCast(Me._entidad, Entidades.Empleado).EsRespProd
         '----------------------------------------------------------------------------

         chbColor.Checked = DirectCast(Me._entidad, Entidades.Empleado).Color.HasValue
         btnColor.Enabled = chbColor.Checked
         txtColor.Enabled = chbColor.Checked

         If DirectCast(Me._entidad, Entidades.Empleado).Color.HasValue Then
            Me.txtColor.BackColor = System.Drawing.Color.FromArgb(DirectCast(Me._entidad, Entidades.Empleado).Color.Value)
         Else
            Me.txtColor.BackColor = Nothing
         End If

         Me.tbcEmpleado.SelectedTab = Me.tbpMapa

         If Reglas.Publicos.EmpleadoUtilizaGeolocalizacion AndAlso
            DirectCast(Me._entidad, Entidades.Empleado).GeoLocalizacionLat <> 0 Then
            Me.Ubicacion()
            Me.gmcMapa.ReloadMap()
         End If

         If Not String.IsNullOrEmpty(DirectCast(Me._entidad, Entidades.Empleado).IdUsuario) Then
            Me.chbUsuario.Checked = True
         End If

         If Not String.IsNullOrEmpty(DirectCast(Me._entidad, Entidades.Empleado).IdUsuarioMovil) Then
            Dim usr = DirectCast(Me._entidad, Entidades.Empleado).IdUsuarioMovil
            Me.chbUsuarioMovil.Checked = True
            cmbUsuarioMovil.SelectedValue = usr
         End If

         Me.tbcEmpleado.SelectedTab = Me.tbpComisiones

         Me.dgvComisionesMarcas.DataSource = Me.ComisionesMarcas
         Me.dgvComisionesRubros.DataSource = Me.ComisionesRubros

         Me.dgvComisionesSubRubros.DataSource = Me.ComisionesSubRubros
         Me.dgvComisionesSubSubRubros.DataSource = Me.ComisionesSubSubRubros

         Me.dgvComisionesProductos.DataSource = Me.ComisionesProductos

         If rFunc Then
            Me.tbcEmpleado.SelectedTab = Me.tbpProduccion
            chbValorHoraProd.Checked = Decimal.Parse(DirectCast(Me._entidad, Entidades.Empleado).ValorHoraProduccion.ToString("N2")) <> 0
            txtValorHora.Text = DirectCast(Me._entidad, Entidades.Empleado).ValorHoraProduccion.ToString("N2")
         End If

         Me.tbcEmpleado.SelectedTab = Me.tbpDatos
         Me.bscCodigoLocalidad.PresionarBoton()

         txtNivelAutorizacion.Visible = New Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "Empleados-NivelAutorizacion")
         txtNivelAutorizacion.LabelAsoc.Visible = txtNivelAutorizacion.Visible

         chbCaja.Checked = Cobrador.IdCaja.HasValue


      End If

      If Not Reglas.Publicos.EmpleadoUtilizaGeolocalizacion Then
         tbcEmpleado.TabPages.Remove(tbpMapa)
      End If

      _finOnLoad = True
      _estaCargando = False

      CargaCategoriaEmpleados()

   End Sub
   Private Sub CargaEntidadCobranza(combo As ComboBox)
      Dim dt = New DataTable("Tabla")
      dt.Columns.Add("Codigo")
      dt.Columns.Add("Descripcion")

      Dim dr = dt.NewRow()
      dr("Codigo") = "NINGUNO"
      dr("Descripcion") = "NINGUNO"
      dt.Rows.Add(dr)
      If Reglas.Publicos.CtaCte.CobranzaElectronicaHabilitaRoela Then
         dr = dt.NewRow()
         dr("Codigo") = "ROELA"
         dr("Descripcion") = "ROELA"
         dt.Rows.Add(dr)
      End If
      If Reglas.Publicos.CtaCte.CobranzaElectronicaHabilitaSirPlus Then
         dr = dt.NewRow()
         dr("Codigo") = "SIRPLUS"
         dr("Descripcion") = "SIRPLUS"
         dt.Rows.Add(dr)
      End If
      With combo
         .DataSource = dt
         .ValueMember = "Codigo"
         .DisplayMember = "Descripcion"
      End With
      combo.SelectedIndex = 0
   End Sub
   Private Sub FormateaGrilla()
      AjustarColumnasGrilla(ugObjetivos, _titEmpleadoObjetivo)
      Me.ugObjetivos.DisplayLayout.Bands(0).Columns(Entidades.PeriodoFiscal.Columnas.PeriodoFiscal.ToString()).FormatearColumna("Periodo", 1, 55, HAlign.Center, , "0000/00")
      ugObjetivos.AgregarFiltroEnLinea({})
   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Empleados
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If chbEsTransportista.Checked And Not bscCodigoTransportista.Selecciono And Not bscTransportista.Selecciono Then
         tbcEmpleado.SelectedTab = tbpChofer
         bscCodigoTransportista.Select()
         Return "ATENCION: No Selecciono un Transportista."
      End If


      If Not Me.bscCodigoLocalidad.Selecciono And Not Me.bscNombreLocalidad.Selecciono Then
         'Me.tbcCliente.SelectedTab = Me.tbpUbicacion
         Me.bscCodigoLocalidad.Focus()
         Return "ATENCION: No Selecciono la Localidad."
      End If

      If Me.chbUsuario.Checked And Me.cmbUsuario.SelectedIndex = -1 Then
         Me.cmbUsuario.Focus()
         Return "ATENCION: Activo el Usuario por Defecto. Debe elegir uno."
      End If

      If Me.chbUsuario.Checked And Not Me.chbEsVendedor.Checked Then
         Me.chbEsVendedor.Focus()
         Return "ATENCION: Debe establecer al Empleado como Vendedor porque tiene Usuario Asociado."
      End If

      If Not chbEsVendedor.Checked Then
         Dim clientes As DataTable = New Clientes().GetFiltradoPorVendedor(txtIdEmpleado.Text.ValorNumericoPorDefecto(0I))
         If clientes.Rows.Count > 0 Then
            Return String.Format("ATENCION: Existen {0} clientes que tienen a este empleado como Vendedor.", clientes.Rows.Count)
         End If
      End If

      If Me.chbUsuarioMovil.Checked And Me.cmbUsuarioMovil.SelectedIndex = -1 Then
         Me.cmbUsuarioMovil.Focus()
         Return "ATENCION: Activo el Usuario Movil por Defecto. Debe elegir uno."
      End If

      If txtNivelAutorizacion.Visible Then
         If Not IsNumeric(txtNivelAutorizacion.Text) Then txtNivelAutorizacion.Text = "1"
         If Short.Parse(txtNivelAutorizacion.Text) > actual.NivelAutorizacion Then
            tbcEmpleado.SelectedTab = tbpDatos
            Me.txtNivelAutorizacion.Focus()
            Return "ATENCION: El nivel de autorización ingresado es superior al suyo."
         End If         'If Short.Parse(txtNivelAutorizacion.Text) > actual.NivelAutorizacion Then
      End If            'If txtNivelAutorizacion.Visible Then

      'PE-31509
      If Me.chbDebitoDirecto.Checked And Me.chbDebitoTarjeta.Checked Then
         Me.chbDebitoDirecto.Focus()
         Return "No se puede seleccionar Débito Directo y Débito Tarjeta para el mismo Empleado. Por favor seleccione solo uno."
      End If

      If Me.chbDebitoDirecto.Checked Then
         If Me.cmbBanco.Text = "" Then
            Me.cmbBanco.Focus()
            Return "Debe ingresar un Banco para Debito Directo"
         End If
      End If

      If Me.chbDebitoTarjeta.Checked Then
         If Me.cmbTarTarjeta.Text = "" Then
            Me.cmbTarTarjeta.Focus()
            Return "Debe ingresar una Tarjeta para Debito Tarjeta"
         End If
      End If

      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
      Me.chbEsVendedor.Checked = True
      Me.chbEsComprador.Checked = True
   End Sub

   Protected Overrides Sub Aceptar()
      Me.btnGeolocalizar.PerformClick()
      If Not chbColor.Checked Then
         DirectCast(Me._entidad, Entidades.Empleado).Color = Nothing
      End If
      With DirectCast(Me._entidad, Entidades.Empleado)
         .ValorHoraProduccion = Decimal.Parse(txtValorHora.Text())
         .EntidadCobranza = cmbEntidadCobranza.SelectedValue.ToString()
      End With
      _estaCargando = True

      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   Private Sub EmpleadosDetalle_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
      Try
         If Me.StateForm = Eniac.Win.StateForm.Actualizar Then
            'If DirectCast(Me._entidad, Entidades.Cliente).Vendedor.TipoDocEmpleado.Length > 0 Then
            '   Me.cmbVendedor.SelectedItem = Me.GetVendedorCombo(DirectCast(Me._entidad, Entidades.Cliente).Vendedor.TipoDocEmpleado, DirectCast(Me._entidad, Entidades.Cliente).Vendedor.NroDocEmpleado)
            'End If
            Me.txtNombreEmpleado.Focus()
         Else
            Me.txtNroDocEmpleado.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbUsuario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUsuario.CheckedChanged
      If Not Me.chbUsuario.Checked Then
         Me.cmbUsuario.SelectedIndex = -1
         DirectCast(Me._entidad, Entidades.Empleado).IdUsuario = ""
      End If
      Me.cmbUsuario.Enabled = Me.chbUsuario.Checked
   End Sub

   Private Sub chbUsuarioMovil_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUsuarioMovil.CheckedChanged
      TryCatched(Sub()
                    chbUsuarioMovil.FiltroCheckedChanged(cmbUsuarioMovil)
                    If chbUsuario.Checked And chbUsuarioMovil.Checked Then
                       cmbUsuarioMovil.SelectedValue = cmbUsuario.SelectedValue
                    End If
                    If cmbUsuarioMovil.SelectedIndex = -1 Then
                       DirectCast(Me._entidad, Entidades.Empleado).IdUsuarioMovil = ""
                    End If
                 End Sub)
   End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.cmbTipoDocEmpleado.Focus()
   End Sub

   Private Sub lnkLocalidad_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLocalidad.LinkClicked
      Try
         Dim PantLocalidad As LocalidadesDetalle = New LocalidadesDetalle(New Entidades.Localidad())
         PantLocalidad.StateForm = Win.StateForm.Insertar
         PantLocalidad.CierraAutomaticamente = True
         If PantLocalidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoLocalidad.Text = PantLocalidad.txtIdLocalidad.Text
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

   Private Sub bscCodigoLocalidad_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.btnGeolocalizar.Focus()
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

   Private Sub bscNombreLocalidad_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.btnGeolocalizar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbTipoMapa_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTipoMapa.SelectedIndexChanged
      Try
         Select Case Me.cmbTipoMapa.Text
            Case "Google Maps"
               Me.gmcMapa.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance
            Case "Google Satelite Maps"
               Me.gmcMapa.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance
            Case Else
         End Select
         If _finOnLoad Then _
               Me.gmcMapa.ReloadMap()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnGeolocalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeolocalizar.Click
      Me.CargarMapa()
   End Sub

   Private Sub tcbZoom_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tcbZoom.Scroll
      Me.gmcMapa.Zoom = Me.tcbZoom.Value
   End Sub

   'Private Sub txtDireccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDireccion.TextChanged
   '     If Not _estaCargando Then
   '         Me.txtGeoLocalizacionLat.Text = "0"
   '         Me.txtGeoLocalizacionLng.Text = "0"
   '     End If
   'End Sub


   Private Sub btnEliminarMarca_Click(sender As Object, e As EventArgs) Handles btnEliminarMarca.Click
      Try
         If Me.dgvComisionesMarcas.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar la comisión seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaMarca()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarRubros_Click(sender As Object, e As EventArgs) Handles btnEliminarRubros.Click
      Try
         If Me.dgvComisionesRubros.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar la comisión seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaRubro()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarProductos_Click(sender As Object, e As EventArgs) Handles btnEliminarProductos.Click
      Try
         If Me.dgvComisionesProductos.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar la comisión seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaProducto()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertarMarca_Click(sender As Object, e As EventArgs) Handles btnInsertarMarca.Click
      Try
         If Me.cmbMarcas.SelectedValue IsNot Nothing And Me.txtComisionMarcas.Text >= "0.00" Then
            If Me.ExisteMarca(Int32.Parse(Me.cmbMarcas.SelectedValue.ToString())) Then
               MessageBox.Show("Ya existe la Marca.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               Me.AgregarMarca()

            End If
            Me.cmbMarcas.Text = ""
            Me.txtComisionMarcas.Text = "0.00"
            Me.cmbMarcas.Focus()
         Else
            MessageBox.Show("La Comision es Incorrecta!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertarRubros_Click(sender As Object, e As EventArgs) Handles btnInsertarRubros.Click
      Try
         If Me.cmbRubros.SelectedValue IsNot Nothing And Me.txtComisionRubro.Text >= "0.00" Then
            If Me.ExisteRubro(Int32.Parse(Me.cmbRubros.SelectedValue.ToString())) Then
               MessageBox.Show("Ya existe el Rubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               Me.AgregarRubro()

            End If
            Me.cmbRubros.Text = ""
            Me.txtComisionRubro.Text = "0.00"
            Me.cmbRubros.Focus()
         Else
            MessageBox.Show("La Comision es Incorrecta!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

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
         If Me.bscCodigoProducto.Text IsNot Nothing And Me.txtComisionProducto.Text >= "0.00" Then
            If Me.ExisteProducto(Me.bscCodigoProducto.Text.ToString()) Then
               MessageBox.Show("Ya existe el Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               Me.AgregarProducto()

            End If
            Me.bscCodigoProducto.Text = ""
            Me.bscProducto.Text = ""
            Me.txtComisionProducto.Text = "0.00"
            Me.bscProducto.Enabled = True
            Me.bscCodigoProducto.Enabled = True
            Me.bscCodigoProducto.Focus()
         Else
            MessageBox.Show("La Comision es Incorrecta!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtComisionProducto.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnRefrescarProductos_Click(sender As Object, e As EventArgs) Handles btnRefrescarProductos.Click
      Try
         Me.bscCodigoProducto.Text = ""
         Me.bscProducto.Text = ""
         Me.txtComisionProducto.Text = "0.00"
         Me.bscProducto.Enabled = True
         Me.bscCodigoProducto.Enabled = True
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub btnRefrescarRubros_Click(sender As Object, e As EventArgs) Handles btnRefrescarRubros.Click
      Try
         Me.cmbRubros.SelectedIndex = -1
         Me.txtComisionRubro.Text = "0.00"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub btnRefrescarMarcas_Click(sender As Object, e As EventArgs) Handles btnRefrescarMarcas.Click
      Try
         Me.cmbMarcas.SelectedIndex = -1
         Me.txtComisionMarcas.Text = "0.00"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto)
         Me.bscCodigoProducto.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCodigoProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            Me.txtComisionProducto.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscProducto_BuscadorClick() Handles bscProducto.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto)
         Me.bscProducto.Datos = oProductos.GetPorNombre(Me.bscProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            Me.txtComisionProducto.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbMarcas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbMarcas.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub txtDescuentoMarcas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComisionMarcas.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub cmbRubros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbRubros.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub txtDescuentoRubro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComisionRubro.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub bscCodigoProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bscCodigoProducto.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub bscProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bscProducto.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub txtDescuentoProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComisionProducto.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcEmpleado.SelectedIndexChanged
      'If tbcEmpleado.SelectedIndex = 1 Then
      '   CargarMapa()
      '   Me.gmcMapa.ReloadMap()
      'End If
   End Sub

   Private _antDireccion As String
   Private Sub txtDireccion_Leave(sender As Object, e As EventArgs) Handles txtDireccion.Leave
      If Not _estaCargando Then
         If _antDireccion <> txtDireccion.Text Then
            Me.txtGeoLocalizacionLat.Text = "0"
            Me.txtGeoLocalizacionLng.Text = "0"
         End If
      End If
   End Sub
   Private Sub txtDireccion_Enter(sender As Object, e As EventArgs) Handles txtDireccion.Enter
      _antDireccion = txtDireccion.Text
   End Sub

   Private Sub bscCodigoLocalidad_Leave(sender As Object, e As EventArgs) Handles bscCodigoLocalidad.Leave
      If Not _estaCargando Then
         If _antDireccion <> bscCodigoLocalidad.Text Then
            Me.txtGeoLocalizacionLat.Text = "0"
            Me.txtGeoLocalizacionLng.Text = "0"
         End If
      End If
   End Sub
   Private Sub bscCodigoLocalidad_Enter(sender As Object, e As EventArgs) Handles bscCodigoLocalidad.Enter
      _antDireccion = bscCodigoLocalidad.Text
   End Sub

   Private Sub bscNombreLocalidad_Leave(sender As Object, e As EventArgs) Handles bscNombreLocalidad.Leave
      If Not _estaCargando Then
         If _antDireccion <> bscNombreLocalidad.Text Then
            Me.txtGeoLocalizacionLat.Text = "0"
            Me.txtGeoLocalizacionLng.Text = "0"
         End If
      End If
   End Sub
   Private Sub bscNombreLocalidad_Enter(sender As Object, e As EventArgs) Handles bscNombreLocalidad.Enter
      _antDireccion = bscNombreLocalidad.Text
   End Sub

   Private Function GetMarca(ByVal latitud As Double, ByVal longitud As Double, ByVal direccion As String, ByVal nombre As String) As GMarkerGoogle
      Dim marker As GMarkerGoogle = New GMarkerGoogle(New PointLatLng(latitud, longitud), GMarkerGoogleType.green)
      marker.ToolTip = New GMap.NET.WindowsForms.GMapToolTip(marker)
      marker.ToolTipText = nombre + "-" + direccion
      Return marker
   End Function

   Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
      Try
         Me.cdColor.Color = Me.txtColor.BackColor

         If Me.cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtColor.Key = Me.cdColor.Color.ToArgb().ToString()
            DirectCast(Me._entidad, Entidades.Empleado).Color = Me.cdColor.Color.ToArgb()
            Me.txtColor.BackColor = Me.cdColor.Color
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbColor_CheckedChanged(sender As Object, e As EventArgs) Handles chbColor.CheckedChanged
      btnColor.Enabled = chbColor.Checked
      txtColor.Enabled = chbColor.Checked
      If chbColor.Checked Then
         btnColor.Focus()
      End If
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Me.ValidarObjetivos() Then
            InsertarObjetivos()
            btnRefrescarObj.PerformClick()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         Dim objetivo As Entidades.EmpleadoObjetivo = ugObjetivos.FilaSeleccionada(Of Entidades.EmpleadoObjetivo)()
         If objetivo IsNot Nothing Then
            _entEmpleadoObjetivo.Remove(objetivo)
            Me.ugObjetivos.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub btnRefrescarObj_Click(sender As Object, e As EventArgs) Handles btnRefrescarObj.Click
      Me.dtpPeriodoFiscal.Value = DateTime.Today
      Me.txtImporteObjetivos.Text = "0.00"
   End Sub

   Private Sub ugObjetivos_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugObjetivos.DoubleClickRow
      Try
         Dim objetivo As Entidades.EmpleadoObjetivo = ugObjetivos.FilaSeleccionada(Of Entidades.EmpleadoObjetivo)()
         If objetivo IsNot Nothing Then
            Me.dtpPeriodoFiscal.Text = objetivo.PeriodoFiscal.ToString("0000/00")
            Me.txtImporteObjetivos.Text = objetivo.ImporteObjetivo.ToString("N2")
            _entEmpleadoObjetivo.Remove(objetivo)
            Me.ugObjetivos.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
            txtImporteObjetivos.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtImporteObjetivos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImporteObjetivos.KeyPress
      PresionarTab(e)
   End Sub
   Private Sub chbDebitoDirecto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDebitoDirecto.CheckedChanged
      Try

         Me.cmbBanco.Enabled = Me.chbDebitoDirecto.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   '-.PE-31509.-
   Private Sub chbDebitoTarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles chbDebitoTarjeta.CheckedChanged
      Try

         Me.cmbTarTarjeta.Enabled = Me.chbDebitoTarjeta.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbCaja_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCaja.CheckedChanged
      Try

         Me.cmbCaja.Enabled = Me.chbCaja.Checked

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lblCaja_Click(sender As Object, e As EventArgs) Handles lblCaja.Click
      chbCaja.Checked = Not chbCaja.Checked
   End Sub
#End Region

#Region "Métodos"

   Private Sub CargarLocalidad(ByVal dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.Empleado).IdLocalidad = Integer.Parse(dr.Cells("IdLocalidad").Value.ToString())
      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
   End Sub

   Private Sub CargarMapa()
      If Not Reglas.Publicos.EmpleadoUtilizaGeolocalizacion Then Exit Sub

      Me.gmcMapa.Overlays.Clear()

      Dim direccion As String
      Dim nombre As String
      Dim gp As GMap.NET.GeocodingProvider = MapProviders.GMapProviders.OpenStreetMap
      Dim pt As PointLatLng
      Dim ov As GMapOverlay = New GMapOverlay("direcciones")
      Dim i As Integer = 0
      Dim provincia As String
      provincia = New Reglas.Localidades().GetUna(Me.bscCodigoLocalidad.Text.ToString().ValorNumericoPorDefecto(0I)).NombreProvincia

      direccion = Me.txtDireccion.Text.ToString() + "," + Me.bscCodigoLocalidad.Text.ToString() + "," + provincia + ",Argentina"
      nombre = Me.txtNombreEmpleado.Text.ToString()

      Try
         Dim tempPt = gp.GetPoint(direccion, GeoCoderStatusCode.G_GEO_UNKNOWN_ADDRESS)
         pt = If(tempPt.HasValue, tempPt.Value, Nothing)  'gp.GetPoint(direccion, GeoCoderStatusCode.G_GEO_UNKNOWN_ADDRESS)

      Catch ex As Exception
         Me.bscNombreLocalidad.Focus()
         MessageBox.Show("No se encontro la Dirección", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End Try


      If Not pt.IsEmpty Then
         If Me.txtGeoLocalizacionLat.Text = "0" Then
            ov.Markers.Add(Me.GetMarca(pt.Lat, pt.Lng, Me.txtDireccion.Text.ToString(), nombre))
            Me.gmcMapa.Overlays.Add(ov)

            Dim tmp = Me.gmcMapa.GetRectOfAllMarkers("direcciones")
            Me.gmcMapa.SetZoomToFitRect(If(tmp.HasValue, tmp.Value, Nothing))


            Me.txtGeoLocalizacionLat.Text = pt.Lat.ToString()
            Me.txtGeoLocalizacionLng.Text = pt.Lng.ToString()
         Else
            ov.Markers.Add(Me.GetMarca(Double.Parse(Me.txtGeoLocalizacionLat.Text.ToString()), Double.Parse(Me.txtGeoLocalizacionLng.Text.ToString()), Me.txtDireccion.Text.ToString(), nombre))
            Me.gmcMapa.Overlays.Add(ov)

            Dim tmp = Me.gmcMapa.GetRectOfAllMarkers("direcciones")
            Me.gmcMapa.SetZoomToFitRect(If(tmp.HasValue, tmp.Value, Nothing))
         End If
      End If

      Me.gmcMapa.Zoom = 13

   End Sub

   Private Sub Ubicacion()

      Me.gmcMapa.Overlays.Clear()

      Dim nombre As String
      Dim ov As GMapOverlay = New GMapOverlay("direcciones")
      Dim i As Integer = 0
      nombre = Me.txtNombreEmpleado.Text.ToString()

      Dim lat As Double = 0
      Dim lon As Double = 0

      Double.TryParse(Me.txtGeoLocalizacionLat.Text, lat)
      Double.TryParse(Me.txtGeoLocalizacionLng.Text, lon)

      ov.Markers.Add(Me.GetMarca(lat, lon, Me.txtDireccion.Text, nombre))
      Me.gmcMapa.Overlays.Add(ov)

      Dim tmp = Me.gmcMapa.GetRectOfAllMarkers("direcciones")
      Me.gmcMapa.SetZoomToFitRect(If(tmp.HasValue, tmp.Value, Nothing))

      Me.gmcMapa.Zoom = 13

   End Sub

   Private Function ExisteMarca(ByVal idMarca As Integer) As Boolean
      Return ExisteClavePrimaria(ComisionesMarcas, "IdMarca", idMarca)
   End Function

   Private Sub AgregarMarca()
      If Me.ComisionesMarcas IsNot Nothing Then
         Dim dr As DataRow = Me.ComisionesMarcas.NewRow()

         dr("IdEmpleado") = DirectCast(Me._entidad, Entidades.Empleado).IdEmpleado
         dr("IdMarca") = Me.cmbMarcas.SelectedValue.ToString()
         dr("NombreMarca") = Me.cmbMarcas.Text
         dr("Comision") = Me.txtComisionMarcas.Text

         Me.ComisionesMarcas.Rows.Add(dr)

         Me.dgvComisionesMarcas.DataSource = Me.ComisionesMarcas
      End If
   End Sub
   Private Sub EliminarLineaMarca()
      EliminarLineaSeleccionada(dgvComisionesMarcas)
   End Sub

   Private Function ExisteProducto(ByVal idProducto As String) As Boolean
      If ComisionesProductos IsNot Nothing Then
         For Each dr As DataRow In ComisionesProductos.Rows
            If dr.RowState <> DataRowState.Deleted Then
               If dr.Field(Of String)("IdProducto") = idProducto Then
                  Return True
               End If
            End If
         Next
      End If
      Return False
   End Function

   Private Sub AgregarProducto()
      Dim dr As DataRow = Me.ComisionesProductos.NewRow()

      dr("IdEmpleado") = DirectCast(Me._entidad, Entidades.Empleado).IdEmpleado
      dr("IdProducto") = Me.bscCodigoProducto.Text.ToString()
      dr("NombreProducto") = Me.bscProducto.Text
      dr("Comision") = Me.txtComisionProducto.Text

      Me.ComisionesProductos.Rows.Add(dr)

      Me.dgvComisionesProductos.DataSource = Me.ComisionesProductos
   End Sub
   Private Sub EliminarLineaProducto()
      EliminarLineaSeleccionada(dgvComisionesProductos)
   End Sub

   Private Function ExisteRubro(ByVal idRubro As Integer) As Boolean
      Return ExisteClavePrimaria(ComisionesRubros, "IdRubro", idRubro)
   End Function

   Private Sub AgregarRubro()

      Dim dr As DataRow = Me.ComisionesRubros.NewRow()

      dr("IdEmpleado") = DirectCast(Me._entidad, Entidades.Empleado).IdEmpleado
      dr("IdRubro") = Me.cmbRubros.SelectedValue.ToString()
      dr("NombreRubro") = Me.cmbRubros.Text
      dr("Comision") = Me.txtComisionRubro.Text

      Me.ComisionesRubros.Rows.Add(dr)

      Me.dgvComisionesRubros.DataSource = Me.ComisionesRubros
   End Sub

   Private Sub EliminarLineaRubro()
      EliminarLineaSeleccionada(dgvComisionesRubros)
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
   Private Function ExisteClavePrimaria(dt As DataTable, keyName As String, ByVal keyValue As Integer) As Boolean
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

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)

      Me.bscProducto.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto.Enabled = False
      Me.bscCodigoProducto.Enabled = False

   End Sub

   Private Sub InsertarObjetivos()
      Dim periodo As Integer = Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM"))
      Dim objetivo As Entidades.EmpleadoObjetivo = New Entidades.EmpleadoObjetivo()
      With objetivo
         .IdEmpleado = DirectCast(Me._entidad, Entidades.Empleado).IdEmpleado
         .PeriodoFiscal = periodo
         .ImporteObjetivo = Decimal.Parse(Me.txtImporteObjetivos.Text)
      End With
      Me._entEmpleadoObjetivo.Add(objetivo)
      Me.ugObjetivos.Rows.Refresh(RefreshRow.ReloadData)
   End Sub

   Private Function ValidarObjetivos() As Boolean
      If Decimal.Parse(Me.txtImporteObjetivos.Text) <= 0 Then
         MessageBox.Show("El valor del importe objetivo no debe ser menor o igual 0 ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtImporteObjetivos.Focus()
         Return False
      End If

      For Each ent As Entidades.EmpleadoObjetivo In _entEmpleadoObjetivo
         If (ent.PeriodoFiscal = Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM"))) Then
            MessageBox.Show("Existe el objetivo para el periodo seleccionado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
         End If
      Next


      Return True
   End Function

   Private Sub CargarProximoNumero()
      Dim oEmpleados As Reglas.Empleados = New Reglas.Empleados()
      Me.txtIdEmpleado.Text = (oEmpleados.GetIdMaximo() + 1).ToString("####0")
   End Sub


   Private Sub bscCodigoTransportista_BuscadorClick() Handles bscCodigoTransportista.BuscadorClick
      Try
         Dim vIdTrans As Long = 0
         Dim oTransportistas = New Reglas.Transportistas
         Me._publicos.PreparaGrillaTransportistas(Me.bscCodigoTransportista)
         If Not String.IsNullOrEmpty(bscCodigoTransportista.Text) Then
            vIdTrans = Long.Parse(bscCodigoTransportista.Text)
         End If
         Me.bscCodigoTransportista.Datos = oTransportistas.GetFiltradoPorCodigo(vIdTrans, False)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoTransportista_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoTransportista.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTransportista(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscTransportista_BuscadorClick() Handles bscTransportista.BuscadorClick
      Try
         Me._publicos.PreparaGrillaTransportistas(Me.bscTransportista)
         Dim oTransportistas = New Reglas.Transportistas

         Me.bscTransportista.Datos = oTransportistas.GetFiltradoPorNombre(Me.bscTransportista.Text.Trim(), True)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Private Sub bscTransportista_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscTransportista.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTransportista(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub CargarDatosTransportista(dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.Empleado).IdTransportista = Integer.Parse(dr.Cells("IdTransportista").Value.ToString())
      bscCodigoTransportista.Text = dr.Cells("IdTransportista").Value.ToString()
      bscTransportista.Text = dr.Cells("NombreTransportista").Value.ToString()
   End Sub

   Private Sub chbEsTransportista_CheckedChanged(sender As Object, e As EventArgs) Handles chbEsTransportista.CheckedChanged
      bscCodigoTransportista.Enabled = chbEsTransportista.Checked
      bscTransportista.Enabled = chbEsTransportista.Checked
      If Not chbEsTransportista.Checked Then
         bscCodigoTransportista.Text = ""
         bscTransportista.Text = ""
         DirectCast(Me._entidad, Entidades.Empleado).IdTransportista = 0
      End If

   End Sub

   Private Sub chbResponsableProd_CheckedChanged(sender As Object, e As EventArgs) Handles chbResponsableProd.CheckedChanged
      '-- REQ-38946.- -------------------------------------------------------------
      pnlValorHora.Enabled = chbResponsableProd.Checked
      '----------------------------------------------------------------------------
   End Sub

   Private Sub chbValorHoraProd_CheckedChanged(sender As Object, e As EventArgs) Handles chbValorHoraProd.CheckedChanged
      '-- Activa o Desactiva el Valor.-
      txtValorHora.Enabled = chbValorHoraProd.Checked
      txtValorHora.Text = "0.00"
      If chbValorHoraProd.Checked Then
         txtValorHora.Select()
      End If
   End Sub

   Private Sub cmbCategoriaEmpleado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoriaEmpleado.SelectedIndexChanged
      CargaCategoriaEmpleados()
   End Sub

   Private Sub CargaCategoriaEmpleados()
      If Not _estaCargando Then
         Dim eEmple = New Reglas.MRPCategoriasEmpleados().GetUno(Integer.Parse(cmbCategoriaEmpleado.SelectedValue.ToString()))
         txtValorHoraCatego.Text = eEmple.ValorHoraProduccion.ToString()
      End If
   End Sub

   Private Sub btnRefrescarSubRubros_Click(sender As Object, e As EventArgs) Handles btnRefrescarSubRubros.Click
      TryCatched(
      Sub()
         bscCodigoRubro1.Text = ""
         bscNombreRubro1.Text = ""
         bscCodigoSubRubro1.Text = ""
         bscNombreSubRubro1.Text = ""
         bscCodigoRubro1.Focus()

         txtDescuentoSubRubros.Text = "0.00"
      End Sub)
   End Sub

   Private Sub bscCodigoRubro1_BuscadorClick() Handles bscCodigoRubro1.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaRubros2(bscCodigoRubro1)
         bscCodigoRubro1.Datos = New Reglas.Rubros().GetPorCodigo(bscCodigoRubro1.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreRubro1_BuscadorClick() Handles bscNombreRubro1.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaRubros2(bscNombreRubro1)
         bscNombreRubro1.Datos = New Reglas.Rubros().GetPorNombre(bscNombreRubro1.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoRubro1_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoRubro1.BuscadorSeleccion, bscNombreRubro1.BuscadorSeleccion
      TryCatched(Sub() CargarRubro(e.FilaDevuelta, bscCodigoRubro1, bscNombreRubro1, bscCodigoSubRubro1))
   End Sub
   Private Sub bscCodigoRubro1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bscCodigoRubro1.KeyPress, bscNombreRubro1.KeyPress
      PresionarTab(e)
   End Sub
   Private Sub txtDescuentoRubros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuentoSubRubros.KeyPress, txtDescuentoSubSubRubro.KeyPress
      PresionarTab(e)
   End Sub
#End Region

   Private Sub CargarRubro(dr As DataGridViewRow, bscCodigo As Eniac.Controles.Buscador2, bscNombre As Eniac.Controles.Buscador2, ctrlFocus As Control)
      If dr IsNot Nothing Then
         bscCodigo.Text = dr.Cells("IdRubro").Value.ToString()
         bscNombre.Text = dr.Cells("NombreRubro").Value.ToString()
         ctrlFocus.Focus()
      End If
   End Sub
   Private Sub CargarSubRubro(dr As DataGridViewRow, bscCodigo As Controles.Buscador2, bscNombre As Controles.Buscador2, bscRubro As Controles.Buscador2, ctrlFocus As Control)
      If dr IsNot Nothing Then
         bscCodigo.Text = dr.Cells("IdSubRubro").Value.ToString()
         bscNombre.Text = dr.Cells("NombreSubRubro").Value.ToString()

         If bscRubro.Text.ValorNumericoPorDefecto(0I) = 0 Then
            Dim tempEstaCargando As Boolean = _estaCargando
            _estaCargando = True
            bscRubro.Text = dr.Cells("IdRubro").Value.ToString()
            bscRubro.PresionarBoton()
            _estaCargando = tempEstaCargando
         End If
         ctrlFocus.Focus()
      End If
   End Sub
   Private Sub CargarSubSubRubro(dr As DataGridViewRow, bscCodigo As Controles.Buscador2, bscNombre As Controles.Buscador2, bscSubRubro As Controles.Buscador2, ctrlFocus As Control)
      If dr IsNot Nothing Then
         bscCodigo.Text = dr.Cells("IdSubSubRubro").Value.ToString()
         bscNombre.Text = dr.Cells("NombreSubSubRubro").Value.ToString()

         If bscSubRubro.Text.ValorNumericoPorDefecto(0I) = 0 Then
            Dim tempEstaCargando As Boolean = _estaCargando
            _estaCargando = True
            bscSubRubro.Text = dr.Cells("IdSubRubro").Value.ToString()
            bscSubRubro.PresionarBoton()
            _estaCargando = tempEstaCargando
         End If
      End If
      ctrlFocus.Focus()
   End Sub
   Private Sub bscCodigoSubRubro1_BuscadorClick() Handles bscCodigoSubRubro1.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaSubRubros2(bscCodigoSubRubro1)
         bscCodigoSubRubro1.Datos = New Reglas.SubRubros().GetPorCodigo(bscCodigoRubro1.Text.ValorNumericoPorDefecto(0I),
                                                                           bscCodigoSubRubro1.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreSubRubro1_BuscadorClick() Handles bscNombreSubRubro1.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaSubRubros2(bscNombreSubRubro1)
         bscNombreSubRubro1.Datos = New Reglas.SubRubros().GetPorNombre(bscCodigoRubro1.Text.ValorNumericoPorDefecto(0I),
                                                                           bscNombreSubRubro1.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoSubRubro1_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoSubRubro1.BuscadorSeleccion, bscNombreSubRubro1.BuscadorSeleccion
      TryCatched(Sub() CargarSubRubro(e.FilaDevuelta, bscCodigoSubRubro1, bscNombreSubRubro1, bscCodigoRubro1, txtDescuentoSubRubros))
   End Sub
   Private Sub bscCodigoSubRubro1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bscCodigoSubRubro1.KeyPress, bscNombreSubRubro1.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub btnEliminarSubRubros_Click(sender As Object, e As EventArgs) Handles btnEliminarSubRubros.Click
      TryCatched(
      Sub()
         If dgvComisionesSubRubros.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el item selecionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               EliminarLinea(dgvComisionesSubRubros)
            End If
         End If
      End Sub)
   End Sub
   Private Sub EliminarLinea(grilla As Eniac.Controles.DataGridView)
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
   Private Sub btnInsertarSubRubros_Click(sender As Object, e As EventArgs) Handles btnInsertarSubRubros.Click
      TryCatched(
Sub()
   If Not Me.bscCodigoRubro1.Selecciono And Not Me.bscNombreRubro1.Selecciono Then
      MessageBox.Show("Debe seleccionar un Rubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Me.bscCodigoRubro1.Focus()
      Return
   End If
   If String.IsNullOrEmpty(Me.bscCodigoRubro1.Text) Or String.IsNullOrEmpty(Me.bscNombreRubro1.Text) Then
      MessageBox.Show("Debe seleccionar un Rubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Me.bscCodigoRubro1.Focus()
      Return
   End If
   If Not Me.bscCodigoSubRubro1.Selecciono And Not Me.bscNombreSubRubro1.Selecciono Then
      MessageBox.Show("Debe seleccionar un SubRubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Me.bscCodigoSubRubro1.Focus()
      Return
   End If
   If String.IsNullOrEmpty(Me.bscCodigoSubRubro1.Text) Or String.IsNullOrEmpty(bscNombreSubRubro1.Text) Then
      MessageBox.Show("Debe seleccionar un SubRubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Me.bscCodigoSubRubro1.Focus()
      Return
   End If
   If Me.ExisteSubRubro(Int32.Parse(Me.bscCodigoSubRubro1.Text), Int32.Parse(Me.bscCodigoRubro1.Text)) Then
      MessageBox.Show("Ya existe el SubRubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Return
   End If
   Select Case Decimal.Parse(Me.txtDescuentoSubRubros.Text)
      Case = 0
         MessageBox.Show("Ingrese un valor valido de Comisión.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtDescuentoSubRubros.Focus()
         Return
      Case < 1
         MessageBox.Show("La Comision es Incorrecta!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtDescuentoSubRubros.Focus()
         Return
      Case > 100
         MessageBox.Show("El valor del  Descuento y el Recargo no debe ser mayor a 100", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtDescuentoSubRubros.Focus()
         Return
   End Select

   AgregarSubRubro()

   bscCodigoRubro1.Text = ""
   bscNombreRubro1.Text = ""
   bscCodigoSubRubro1.Text = ""
   bscNombreSubRubro1.Text = ""
   txtDescuentoSubRubros.Text = "0.00"
End Sub)
   End Sub

   Private Function ExisteSubRubro(idSubRubro As Integer, idRubro As Integer) As Boolean
      Return ExisteClavePrimariaSub(ComisionesSubRubros, "IdSubRubro", idSubRubro, "IdRubro", idRubro)
   End Function

   Private Function ExisteClavePrimariaSub(dt As DataTable, keyName1 As String, keyValue1 As Integer, keyName2 As String, keyValue2 As Integer) As Boolean
      If dt IsNot Nothing Then
         For Each dr As DataRow In dt.Rows
            If dr.RowState <> DataRowState.Deleted Then
               If (Int32.Parse(dr(keyName1).ToString()) = keyValue1) And (Int32.Parse(dr(keyName2).ToString()) = keyValue2) Then
                  Return True
               End If
            End If
         Next
      End If
      Return False
   End Function

   Public ReadOnly Property ComisionesSubSubRubros() As DataTable
      Get
         If DirectCast(Me._entidad, Entidades.Empleado).Comisiones IsNot Nothing Then
            If DirectCast(Me._entidad, Entidades.Empleado).Comisiones.Tables.Contains(Entidades.Empleado.ComisionesSubSubRubrosTableName) Then
               Return DirectCast(Me._entidad, Entidades.Empleado).Comisiones.Tables(Entidades.Empleado.ComisionesSubSubRubrosTableName)
            End If
         End If
         Return Nothing
      End Get
   End Property

   Private Sub AgregarSubRubro()

      Dim dr As DataRow = Me.ComisionesSubRubros.NewRow()
      dr("IdEmpleado") = DirectCast(Me._entidad, Entidades.Empleado).IdEmpleado
      dr("IdSubRubro") = Me.bscCodigoSubRubro1.Text
      dr("NombreSubRubro") = Me.bscNombreSubRubro1.Text
      dr("IdRubro") = Me.bscCodigoRubro1.Text
      dr("NombreRubro") = Me.bscNombreRubro1.Text
      dr("Comision") = Me.txtDescuentoSubRubros.Text

      Me.ComisionesSubRubros.Rows.Add(dr)

      Me.dgvComisionesSubRubros.DataSource = Me.ComisionesSubRubros
   End Sub

#Region "--------------Eventos SubSubRubros----------------"
   Public ReadOnly Property ComisionesSubRubros() As DataTable
      Get
         If DirectCast(Me._entidad, Entidades.Empleado).Comisiones IsNot Nothing Then
            If DirectCast(Me._entidad, Entidades.Empleado).Comisiones.Tables.Contains(Entidades.Empleado.ComisionesSubRubrosTableName) Then
               Return DirectCast(Me._entidad, Entidades.Empleado).Comisiones.Tables(Entidades.Empleado.ComisionesSubRubrosTableName)
            End If
         End If
         Return Nothing
      End Get
   End Property

   Private Sub btnInsertarSubSubRubro_Click(sender As Object, e As EventArgs) Handles btnInsertarSubSubRubro.Click
      TryCatched(
      Sub()
         If Not Me.bscCodigoRubro2.Selecciono And Not Me.bscNombreRubro2.Selecciono Then
            MessageBox.Show("Debe seleccionar un Rubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoRubro2.Focus()
            Return
         End If
         If Not Me.bscCodigoSubRubro2.Selecciono And Not Me.bscNombreSubRubro2.Selecciono Then
            MessageBox.Show("Debe seleccionar un SubRubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoSubRubro2.Focus()
            Return
         End If
         If Not Me.bscCodigoSubSubRubro2.Selecciono And Not Me.bscNombreSubSubRubro2.Selecciono Then
            MessageBox.Show("Debe seleccionar un SubSubRubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoSubSubRubro2.Focus()
            Return
         End If
         If Me.ExisteSubSubRubro(Int32.Parse(Me.bscCodigoSubSubRubro2.Text), Int32.Parse(Me.bscCodigoSubRubro2.Text), Int32.Parse(Me.bscCodigoRubro2.Text)) Then
            MessageBox.Show("Ya existe el SubSubRubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
         End If
         Select Case Decimal.Parse(Me.txtDescuentoSubSubRubro.Text)
            Case = 0
               MessageBox.Show("Ingrese un valor valido de Comisión.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.txtDescuentoSubSubRubro.Focus()
               Return
            Case < 1
               MessageBox.Show("La Comision es Incorrecta!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.txtDescuentoSubSubRubro.Focus()
               Return
            Case > 100
               MessageBox.Show("El valor del  Descuento y el Recargo no debe ser mayor a 100", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.txtDescuentoSubSubRubro.Focus()
               Return
         End Select
         AgregarSubSubRubro()

         bscCodigoRubro2.Text = ""
         bscNombreRubro2.Text = ""
         bscCodigoSubRubro2.Text = ""
         bscNombreSubRubro2.Text = ""
         bscCodigoSubSubRubro2.Text = ""
         bscNombreSubSubRubro2.Text = ""
         txtDescuentoSubSubRubro.Text = "0.00"
      End Sub)
   End Sub
   Private Function ExisteSubSubRubro(idSubSubRubro As Integer, idSubRubro As Integer, idRubro As Integer) As Boolean
      Return ExisteClavePrimariaSubSub(ComisionesSubSubRubros, "IdSubSubRubro", idSubSubRubro, "IdSubRubro", idSubRubro, "IdRubro", idRubro)
   End Function
   Private Function ExisteClavePrimariaSubSub(dt As DataTable, keyName0 As String, keyValue0 As Integer, keyName1 As String, keyValue1 As Integer, keyName2 As String, keyValue2 As Integer) As Boolean
      If dt IsNot Nothing Then
         For Each dr As DataRow In dt.Rows
            If dr.RowState <> DataRowState.Deleted Then
               If (Int32.Parse(dr(keyName0).ToString()) = keyValue0) And (Int32.Parse(dr(keyName1).ToString()) = keyValue1) And (Int32.Parse(dr(keyName2).ToString()) = keyValue2) Then
                  Return True
               End If
            End If
         Next
      End If
      Return False
   End Function
   Private Sub AgregarSubSubRubro()

      Dim dr As DataRow = Me.ComisionesSubSubRubros.NewRow()

      dr("IdEmpleado") = DirectCast(Me._entidad, Entidades.Empleado).IdEmpleado
      dr("IdRubro") = Me.bscCodigoRubro2.Text
      dr("NombreRubro") = Me.bscNombreRubro2.Text
      dr("IdSubRubro") = Me.bscCodigoSubRubro2.Text
      dr("NombreSubRubro") = Me.bscNombreSubRubro2.Text
      dr("IdSubSubRubro") = Me.bscCodigoSubSubRubro2.Text
      dr("NombreSubSubRubro") = Me.bscNombreSubSubRubro2.Text
      dr("Comision") = Me.txtDescuentoSubSubRubro.Text

      Me.ComisionesSubSubRubros.Rows.Add(dr)

      Me.dgvComisionesSubSubRubros.DataSource = Me.ComisionesSubSubRubros
   End Sub

   Private Sub bscCodigoRubro2_BuscadorClick() Handles bscCodigoRubro2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaRubros2(bscCodigoRubro2)
         bscCodigoRubro2.Datos = New Reglas.Rubros().GetPorCodigo(bscCodigoRubro2.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreRubro2_BuscadorClick() Handles bscNombreRubro2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaRubros2(bscNombreRubro2)
         bscNombreRubro2.Datos = New Reglas.Rubros().GetPorNombre(bscNombreRubro2.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoRubro2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoRubro2.BuscadorSeleccion, bscNombreRubro2.BuscadorSeleccion
      TryCatched(Sub() CargarRubro(e.FilaDevuelta, bscCodigoRubro2, bscNombreRubro2, bscCodigoSubRubro2))
   End Sub
   Private Sub bscCodigoRubro2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bscCodigoRubro2.KeyPress, bscNombreRubro2.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub bscCodigoSubRubro2_BuscadorClick() Handles bscCodigoSubRubro2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaSubRubros2(bscCodigoSubRubro2)
         bscCodigoSubRubro2.Datos = New Reglas.SubRubros().GetPorCodigo(bscCodigoRubro2.Text.ValorNumericoPorDefecto(0I),
                                                                           bscCodigoSubRubro2.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreSubRubro2_BuscadorClick() Handles bscNombreSubRubro2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaSubRubros2(bscNombreSubRubro2)
         bscNombreSubRubro2.Datos = New Reglas.SubRubros().GetPorNombre(bscCodigoRubro2.Text.ValorNumericoPorDefecto(0I), bscNombreSubRubro2.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoSubRubro2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoSubRubro2.BuscadorSeleccion, bscNombreSubRubro2.BuscadorSeleccion
      TryCatched(Sub() CargarSubRubro(e.FilaDevuelta, bscCodigoSubRubro2, bscNombreSubRubro2, bscCodigoRubro2, bscCodigoSubSubRubro2))
   End Sub
   Private Sub bscCodigoSubRubro2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bscCodigoSubRubro2.KeyPress, bscNombreSubRubro2.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub bscCodigoSubSubRubro2_BuscadorClick() Handles bscCodigoSubSubRubro2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaSubSubRubros2(bscCodigoSubSubRubro2)
         bscCodigoSubSubRubro2.Datos = New Reglas.SubSubRubros().GetPorCodigo(bscCodigoRubro2.Text.ValorNumericoPorDefecto(0I),
                                                                                 bscCodigoSubRubro2.Text.ValorNumericoPorDefecto(0I),
                                                                                 bscCodigoSubSubRubro2.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreSubSubRubro2_BuscadorClick() Handles bscNombreSubSubRubro2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaSubSubRubros2(bscNombreSubSubRubro2)
         bscNombreSubSubRubro2.Datos = New Reglas.SubSubRubros().GetPorNombre(bscCodigoRubro2.Text.ValorNumericoPorDefecto(0I),
                                                                              bscCodigoSubRubro2.Text.ValorNumericoPorDefecto(0I),
                                                                              bscNombreSubSubRubro2.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoSubSubRubro2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoSubSubRubro2.BuscadorSeleccion, bscNombreSubSubRubro2.BuscadorSeleccion
      TryCatched(Sub() CargarSubSubRubro(e.FilaDevuelta, bscCodigoSubSubRubro2, bscNombreSubSubRubro2, bscCodigoSubRubro2, txtDescuentoSubSubRubro))
   End Sub
   Private Sub bscCodigoSubSubRubro2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bscCodigoSubSubRubro2.KeyPress, bscNombreSubSubRubro2.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub EditarSubSubRubro(dr As DataGridViewRow)
      bscCodigoRubro2.Text = dr.Cells("IdRubroTwo").Value.ToString()
      bscCodigoRubro2.PresionarBoton()
      bscCodigoSubRubro2.Text = dr.Cells("IdSubRubroTwo").Value.ToString()
      bscCodigoSubRubro2.PresionarBoton()
      bscCodigoSubSubRubro2.Text = dr.Cells("IdSubSubRubro").Value.ToString()
      bscCodigoSubSubRubro2.PresionarBoton()
      txtDescuentoSubSubRubro.Text = dr.Cells("DescuentoRecargoPorc3").Value.ToString()
      EliminarLinea(dgvComisionesSubSubRubros)
   End Sub

   Private Sub btnEliminarSubSubRubro_Click(sender As Object, e As EventArgs) Handles btnEliminarSubSubRubro.Click
      TryCatched(
         Sub()
            If dgvComisionesSubSubRubros.SelectedRows.Count > 0 Then
               If MessageBox.Show("Esta seguro de eliminar el item selecionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                  EliminarLinea(dgvComisionesSubSubRubros)
               End If
            End If
         End Sub)
   End Sub

   Private Sub chbEsCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbEsCobrador.CheckedChanged
      cmbEntidadCobranza.Enabled = chbEsCobrador.Checked
   End Sub

#End Region
End Class