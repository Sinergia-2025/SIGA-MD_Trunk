Option Strict On
Option Explicit On
Public Class ProductosCalidadDetalle
   Private _publicos As Publicos
   Private _idCliente As Long = 0
   Private _reglasProductos As Reglas.Productos
   Private _estaCargando As Boolean = True
   Private _oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.Producto)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()
         _publicos.CargaComboUsuarios(cmbUsuarioCertificado)
         _publicos.CargaComboUsuarios(cmbUsuarioCertEntregado)
         _publicos.CargaComboUsuarios(cmbUsuarioEntregado)
         _publicos.CargaComboUsuarios(cmbUsuarioLiberado)
         _publicos.CargaComboUsuarios(cmbUsuarioLiberadoPDI)
         _publicos.CargaComboTiposServiciosProductoCalidad(cmbTipoServicio)

         Me.TBCFechas.SelectedTab = Me.tbpObservaciones
         Me.TBCFechas.SelectedTab = Me.TbpFechas

         Me.BindearControles(Me._entidad, Me._liSources)

         If StateForm = Win.StateForm.Insertar Then
            Me.txtUbicacion.Text = Reglas.Publicos.ProductoUbicacionPorDefecto()
            txtNroCarroceria.Focus()
            Me.bscNroChasis.Enabled = True
            Me.bscModelo.Enabled = True
         Else

            Dim TipoServicio As Entidades.ProductoTipoServicio = New Reglas.ProductosTiposServicios().GetUno(Integer.Parse(Me.cmbTipoServicio.SelectedValue.ToString()))
            If Not String.IsNullOrEmpty(TipoServicio.Prefijo) Then
               Me.DatosCabecera(False)
            End If

            'Seguridad de la Fecha de Entrega Programada

            Me.chbFechaEntProgramada.Enabled = _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_FechaEntProg")
            Me.dtpEntProgramada.Enabled = _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_FechaEntProg")
            Me.chbFechaEntReProgramada.Enabled = _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_FechaEntReProg")
            Me.dtpEntReProgramada.Enabled = _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_FechaEntReProg")

            '    If DirectCast(Me._entidad, Entidades.Producto).CalidadStatusEntregado Then
            Me.chbFechaEntregado.Enabled = _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_FechaEntregado")
            'Me.dtpEntregado.Enabled = _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_FechaEntregado")
            'Me.cmbUsuarioEntregado.Enabled = _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_FechaEntregado")
            '   End If

            Me.cmbTipoServicio.Enabled = False
            Me.txtNroCarroceria.Enabled = False

            Dim Cliente As DataTable = New Reglas.ProductosClientes().GetClientexProducto(DirectCast(Me._entidad, Entidades.Producto).IdProducto)
            Dim Cli As Entidades.Cliente

            If Cliente.Rows.Count > 0 Then
               _idCliente = Long.Parse(Cliente.Rows(0).Item("IdCliente").ToString())
               Cli = New Reglas.Clientes().GetUno(_idCliente)
               Me.bscCodigoCliente.Text = Cli.CodigoCliente.ToString()
               Me.bscCodigoCliente.PresionarBoton()
            End If

            If DirectCast(Me._entidad, Entidades.Producto).CalidadNumeroChasis <> Nothing Then
               Me.bscNroChasis.Text = DirectCast(Me._entidad, Entidades.Producto).CalidadNumeroChasis
               Me.bscNroChasis.PresionarBoton()
            End If

            Me.bscNroChasis.Enabled = _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_ModificaChasis")
            Me.btnActualizarNroMotor.Enabled = _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_ModificaChasis")

            If DirectCast(Me._entidad, Entidades.Producto).IdProductoModelo > 0 Then
               Me.bscModelo.Text = New Reglas.ProductosModelos().GetUno(Integer.Parse(DirectCast(Me._entidad, Entidades.Producto).IdProductoModelo.ToString())).NombreProductoModelo
               Me.bscModelo.Tag = DirectCast(Me._entidad, Entidades.Producto).IdProductoModelo
            End If
            Me.bscModelo.Enabled = _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_ModificaModelo")

            If DirectCast(Me._entidad, Entidades.Producto).CalidadFecCertificado <> Nothing Then
               Me.chbFechaCertificado.Checked = True
               Me.dtpCertificado.Value = DirectCast(Me._entidad, Entidades.Producto).CalidadFecCertificado
               Me.cmbUsuarioCertificado.SelectedValue = DirectCast(Me._entidad, Entidades.Producto).CalidadUsrCertificado
            End If

            If DirectCast(Me._entidad, Entidades.Producto).CalidadFecCertEntregado <> Nothing Then
               Me.chbFechaCertEntregado.Checked = True
               Me.dtpCertEntregado.Value = DirectCast(Me._entidad, Entidades.Producto).CalidadFecCertEntregado
               Me.cmbUsuarioCertEntregado.SelectedValue = DirectCast(Me._entidad, Entidades.Producto).CalidadUsrCertEntregado
            End If

            If DirectCast(Me._entidad, Entidades.Producto).CalidadFechaIngreso <> Nothing Then
               Me.chbFechaIngreso.Checked = True
               'Controlo las listas si bloquean Fecha de Ingreso 
               Dim dtListasControl As DataTable = New DataTable
               Dim Roles As DataTable = New DataTable
               Roles = New Reglas.UsuariosRoles().GetRolesdeUsuarios(actual.Nombre)
               dtListasControl = New Reglas.ListasControlProductos().GetListasControlxProductoRoles(DirectCast(Me._entidad, Entidades.Producto).IdProducto, Roles)
               Dim Lista As Entidades.ListaControl = New Entidades.ListaControl
               For Each dr1 As DataRow In dtListasControl.Rows
                  Lista = New Reglas.ListasControl().GetUno(Integer.Parse(dr1("IdListaControl").ToString()))
                  If Lista.BloqueaFechaIngreso AndAlso IsDate(dr1("FecIngreso").ToString()) Then
                     Me.chbFechaIngreso.Enabled = False
                     Me.dtpIngreso.Enabled = False
                     Exit For
                  End If
               Next
            End If

            If DirectCast(Me._entidad, Entidades.Producto).CalidadFechaEgreso <> Nothing Then
               Me.chbFechaEgreso.Checked = True
            End If

            If DirectCast(Me._entidad, Entidades.Producto).CalidadFechaPreEnt <> Nothing Then
               Me.chbFechaPreEntrega.Checked = True
            End If

            If DirectCast(Me._entidad, Entidades.Producto).CalidadFechaEntProg <> Nothing Then
               Me.chbFechaEntProgramada.Checked = True
            Else
               Me.dtpEntProgramada.Enabled = False
            End If

            If DirectCast(Me._entidad, Entidades.Producto).CalidadStatusEntregado <> Nothing Then
               Me.chbFechaEntregado.Checked = True
               Me.chbFechaCertEntregado.Enabled = False
               Me.dtpCertEntregado.Enabled = False
               Me.txtNroCertEntregado.Enabled = False
               Me.cmbUsuarioCertEntregado.Enabled = False
            End If

            If DirectCast(Me._entidad, Entidades.Producto).CalidadStatusLiberado <> Nothing Then
               Me.chbFechaLiberado.Checked = True
            End If

            If DirectCast(Me._entidad, Entidades.Producto).CalidadStatusLiberadoPDI <> Nothing Then
               Me.chbFechaLiberadoPDI.Checked = True
            End If

            If DirectCast(Me._entidad, Entidades.Producto).CalidadFechaEntReProg <> Nothing Then
               Me.chbFechaEntReProgramada.Checked = True
            Else
               Me.dtpEntReProgramada.Enabled = False
            End If

            Dim DesviosProductos As DataTable = New Reglas.ProductosExcepciones().GetExcepcionesxProducto(Me.txtIdProducto.Text)
            Me.ugDesviosProductos.DataSource = DesviosProductos

         End If

         _estaCargando = False
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      If StateForm = Win.StateForm.Insertar Then
         txtNroCarroceria.Focus()
      Else
         txtNombreGrupoItem.Focus()
      End If
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base

      Return New Reglas.Productos()

   End Function

   Protected Overrides Sub Aceptar()

      If StateForm = Win.StateForm.Insertar Then
         DirectCast(Me._entidad, Entidades.Producto).IdMarca = New Reglas.Marcas().GetPrimeraMarca()
         DirectCast(Me._entidad, Entidades.Producto).IdRubro = New Reglas.Rubros().GetPrimerRubro()
         DirectCast(Me._entidad, Entidades.Producto).Moneda = New Reglas.Monedas().GetUna(1)
         DirectCast(Me._entidad, Entidades.Producto).Alicuota = 21
         DirectCast(Me._entidad, Entidades.Producto).IdSucursal = actual.Sucursal.Id
         DirectCast(Me._entidad, Entidades.Producto).Tamano = 1
         DirectCast(Me._entidad, Entidades.Producto).UnidadDeMedida = New Reglas.UnidadesDeMedidas().GetUno("UN")
         DirectCast(Me._entidad, Entidades.Producto).MesesGarantia = 0
         DirectCast(Me._entidad, Entidades.Producto).AfectaStock = True
         DirectCast(Me._entidad, Entidades.Producto).IdTipoImpuesto = "IVA"
         DirectCast(Me._entidad, Entidades.Producto).EsServicio = False
         DirectCast(Me._entidad, Entidades.Producto).PublicarEnWeb = False
         DirectCast(Me._entidad, Entidades.Producto).EsDeVentas = True
         DirectCast(Me._entidad, Entidades.Producto).EsDeCompras = True
         DirectCast(Me._entidad, Entidades.Producto).EsCompuesto = False
         DirectCast(Me._entidad, Entidades.Producto).DescontarStockComponentes = False
         DirectCast(Me._entidad, Entidades.Producto).CodigoDeBarrasConPrecio = False
         DirectCast(Me._entidad, Entidades.Producto).PermiteModificarDescripcion = False
         DirectCast(Me._entidad, Entidades.Producto).PagaIngresosBrutos = True
         DirectCast(Me._entidad, Entidades.Producto).Embalaje = 1
         DirectCast(Me._entidad, Entidades.Producto).Kilos = 0
         DirectCast(Me._entidad, Entidades.Producto).PublicarListaDePreciosClientes = True
         DirectCast(Me._entidad, Entidades.Producto).FacturacionCantidadNegativa = False
         DirectCast(Me._entidad, Entidades.Producto).SolicitaEnvase = False
         DirectCast(Me._entidad, Entidades.Producto).AlertaDeCaja = False
         DirectCast(Me._entidad, Entidades.Producto).EsRetornable = False
         DirectCast(Me._entidad, Entidades.Producto).Observacion = ""
         DirectCast(Me._entidad, Entidades.Producto).IdModelo = 0
         DirectCast(Me._entidad, Entidades.Producto).EsOferta = "NO"
         DirectCast(Me._entidad, Entidades.Producto).IncluirExpensas = False
         DirectCast(Me._entidad, Entidades.Producto).nombreCorto = ""
         DirectCast(Me._entidad, Entidades.Producto).Activo = True
         DirectCast(Me._entidad, Entidades.Producto).PrecioPorEmbalaje = False
         DirectCast(Me._entidad, Entidades.Producto).UnidHasta1 = 0
         DirectCast(Me._entidad, Entidades.Producto).UnidHasta2 = 0
         DirectCast(Me._entidad, Entidades.Producto).UnidHasta3 = 0
         DirectCast(Me._entidad, Entidades.Producto).UnidHasta4 = 0
         DirectCast(Me._entidad, Entidades.Producto).UnidHasta5 = 0
         DirectCast(Me._entidad, Entidades.Producto).UHPorc1 = 0
         DirectCast(Me._entidad, Entidades.Producto).UHPorc2 = 0
         DirectCast(Me._entidad, Entidades.Producto).UHPorc3 = 0
         DirectCast(Me._entidad, Entidades.Producto).UHPorc4 = 0
         DirectCast(Me._entidad, Entidades.Producto).UHPorc5 = 0
         DirectCast(Me._entidad, Entidades.Producto).ObservacionCompras = ""
         DirectCast(Me._entidad, Entidades.Producto).SolicitaPrecioVentaPorTamano = False
         DirectCast(Me._entidad, Entidades.Producto).Orden = 1


      End If



      Me.HayError = False

      Try
         If Validar() Then       '
            If Me.bscCodigoCliente.Tag IsNot Nothing Then
               _idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
            End If

            DirectCast(Me._entidad, Entidades.Producto).CalidadNumeroChasis = Me.bscNroChasis.Text

            DirectCast(Me._entidad, Entidades.Producto).IdProductoModelo = Integer.Parse(Me.bscModelo.Tag.ToString())

            If chbFechaCertificado.Checked Then
               DirectCast(Me._entidad, Entidades.Producto).CalidadFecCertificado = Me.dtpCertificado.Value
               DirectCast(Me._entidad, Entidades.Producto).CalidadUsrCertificado = Me.cmbUsuarioCertificado.SelectedValue.ToString()
            End If

            If chbFechaCertEntregado.Checked Then
               DirectCast(Me._entidad, Entidades.Producto).CalidadFecCertEntregado = Me.dtpCertEntregado.Value
               DirectCast(Me._entidad, Entidades.Producto).CalidadUsrCertEntregado = Me.cmbUsuarioCertEntregado.SelectedValue.ToString()
            End If

            If Me.chbFechaIngreso.Checked Then
               DirectCast(Me._entidad, Entidades.Producto).CalidadFechaIngreso = Me.dtpIngreso.Value
            End If

            If Me.chbFechaEgreso.Checked Then
               DirectCast(Me._entidad, Entidades.Producto).CalidadFechaEgreso = Me.dtpEgreso.Value
            End If

            If Me.chbFechaPreEntrega.Checked Then
               DirectCast(Me._entidad, Entidades.Producto).CalidadFechaPreEnt = Me.dtpPreentrega.Value
            End If

            If Me.chbFechaEntProgramada.Checked Then
               If Not Me.chbFechaEntReProgramada.Checked Then
                  DirectCast(Me._entidad, Entidades.Producto).CalidadFechaEntReProg = Me.dtpEntProgramada.Value
               End If
               DirectCast(Me._entidad, Entidades.Producto).CalidadFechaEntProg = Me.dtpEntProgramada.Value
            End If

            If Me.chbFechaEntregado.Checked Then
               DirectCast(Me._entidad, Entidades.Producto).CalidadStatusEntregado = True
               DirectCast(Me._entidad, Entidades.Producto).CalidadFechaEntregado = Me.dtpEntregado.Value
               DirectCast(Me._entidad, Entidades.Producto).CalidadUserEntregado = Me.cmbUsuarioEntregado.SelectedValue.ToString()
            Else
               DirectCast(Me._entidad, Entidades.Producto).CalidadStatusEntregado = False
               DirectCast(Me._entidad, Entidades.Producto).CalidadFechaEntregado = Nothing
               DirectCast(Me._entidad, Entidades.Producto).CalidadUserEntregado = Nothing
            End If

            If Me.chbFechaLiberado.Checked Then
               DirectCast(Me._entidad, Entidades.Producto).CalidadStatusLiberado = True
               DirectCast(Me._entidad, Entidades.Producto).CalidadFechaLiberado = Me.dtpLiberado.Value
               DirectCast(Me._entidad, Entidades.Producto).CalidadUserLiberado = Me.cmbUsuarioLiberado.SelectedValue.ToString()
            Else
               DirectCast(Me._entidad, Entidades.Producto).CalidadStatusLiberado = False
               DirectCast(Me._entidad, Entidades.Producto).CalidadFechaLiberado = Nothing
               DirectCast(Me._entidad, Entidades.Producto).CalidadUserLiberado = Nothing
            End If

            If Me.chbFechaLiberadoPDI.Checked Then
               DirectCast(Me._entidad, Entidades.Producto).CalidadStatusLiberadoPDI = True
               DirectCast(Me._entidad, Entidades.Producto).CalidadFechaLiberadoPDI = Me.dtpLiberadoPDI.Value
               DirectCast(Me._entidad, Entidades.Producto).CalidadUserLiberadoPDI = Me.cmbUsuarioLiberadoPDI.SelectedValue.ToString()
            Else
               DirectCast(Me._entidad, Entidades.Producto).CalidadStatusLiberadoPDI = False
               DirectCast(Me._entidad, Entidades.Producto).CalidadFechaLiberadoPDI = Nothing
               DirectCast(Me._entidad, Entidades.Producto).CalidadUserLiberadoPDI = Nothing
            End If

            If Me.chbFechaEntReProgramada.Checked Then
               DirectCast(Me._entidad, Entidades.Producto).CalidadFechaEntReProg = Me.dtpEntReProgramada.Value
            End If

            Dim oWS As Reglas.Productos = New Reglas.Productos()
            Me._entidad.Usuario = Eniac.Entidades.Usuario.Actual.Nombre
            'Inserto un registro
            If Me.StateForm = StateForm.Insertar Then
               oWS.InsertarCalidad(DirectCast(Me._entidad, Entidades.Producto), _idCliente, IdFuncion)
               MessageBox.Show("Se ingreso el registro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               If Not _estoyAplicando Then

                  If Not Me.HayError And Not Me.CierraAutomaticamente Then
                     Me.LimpiarControles()
                  End If
               End If
            Else
               'Modifico un registro
               oWS.ActualizarCalidad(DirectCast(Me._entidad, Entidades.Producto), _idCliente)
               MessageBox.Show("Se actualizo el registro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               If Not _estoyAplicando Then
                  Me.DialogResult = Windows.Forms.DialogResult.OK
                  Me.Close()
               End If
            End If
         Else
            Me.HayError = True
         End If
         If Not _estoyAplicando Then
            If Me.CierraAutomaticamente Then
               Me.DialogResult = Windows.Forms.DialogResult.OK
               Me.Close()
            End If
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
         'Catch ex As Exception
         '   ShowError(ex)
         '   Me.HayError = True
      End Try
      If Not Me._estoyAplicando AndAlso Not Me.HayError Then Me.Close()

   End Sub

   Protected Overrides Function ValidarDetalle() As String

      'Validaciones Exclusivas cuando es nuevo.
      Me._reglasProductos = New Reglas.Productos()
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         'Para evitar el Trhow y el mensaje de error al correo de soporte.

         Dim ExisteProducto As Boolean
         'If Me._reglasProductos Is Nothing Then
         Me._reglasProductos = New Reglas.Productos()
         'End If

         ExisteProducto = Me._reglasProductos.Existe(Me.txtIdProducto.Text.Trim())

         If ExisteProducto Then
            Return "El Código de Producto Ya Existe."
         End If
      End If

      If chbFechaCertificado.Checked And cmbUsuarioCertificado.SelectedIndex = -1 Then
         Return "Debe seleccionar Usuario Certificado."
      End If

      If chbFechaCertEntregado.Checked And cmbUsuarioCertEntregado.SelectedIndex = -1 Then
         Return "Debe seleccionar Usuario Certificado Entregado."
      End If

      If chbFechaLiberado.Checked And cmbUsuarioLiberado.SelectedIndex = -1 Then
         Return "Debe seleccionar Usuario Liberado."
      End If

      If chbFechaLiberadoPDI.Checked And cmbUsuarioLiberadoPDI.SelectedIndex = -1 Then
         Return "Debe seleccionar Usuario Liberado PDI."
      End If

      If chbFechaEntregado.Checked And cmbUsuarioEntregado.SelectedIndex = -1 Then
         Return "Debe seleccionar Usuario Entregado."

      End If

      If cmbTipoServicio.SelectedIndex = -1 Then
         Return "Debe seleccionar el Tipo de Servicio."
      End If

      Dim TipoServicio As Entidades.ProductoTipoServicio = New Reglas.ProductosTiposServicios().GetUno(Integer.Parse(Me.cmbTipoServicio.SelectedValue.ToString()))
      If Not Me.bscNroChasis.Selecciono And String.IsNullOrEmpty(TipoServicio.Prefijo) And StateForm = StateForm.Insertar Then
         Return "Debe seleccionar el Número de Chasis."
      End If

      If Me.bscModelo.Text = "" Then
         Return "Debe seleccionar el Modelo."
      End If

      'If StateForm = StateForm.Actualizar Then
      '   If Not Me.bscNroChasis.Selecciono And String.IsNullOrEmpty(TipoServicio.Prefijo) Then
      '      Return "Debe seleccionar el Número de Chasis."
      '   End If
      'End If

      Return MyBase.ValidarDetalle()
   End Function

#End Region

#Region "Eventos"

#Region "Eventos Buscadores"

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
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

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
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

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub bscNroChasis_BuscadorClick() Handles bscNroChasis.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos()

         Me.PreparaGrillaNroChasisMotor(Me.bscNroChasis)

         Me.bscNroChasis.Datos = oProductos.GetVistaProductosBejerman(Publicos.CalidadBaseExternaClientes, Me.bscNroChasis.Text)

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscNroChasis_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNroChasis.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarNroChasisMotor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub BscModelo_BuscadorClick() Handles bscModelo.BuscadorClick
      Try
         Me.PreparaGrillaModelo(Me.bscModelo)
         Dim oProductosModelos As Reglas.ProductosModelos = New Reglas.ProductosModelos
         Me.bscModelo.Datos = oProductosModelos.GetPorNombre(Me.bscModelo.Text)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub BscModelo_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscModelo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosModelo(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

   Private Sub chbFechaCertificado_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaCertificado.CheckedChanged
      Try

         Me.dtpCertificado.Enabled = Me.chbFechaCertificado.Checked
         Me.cmbUsuarioCertificado.Enabled = Me.chbFechaCertificado.Checked
         If Not Me.chbFechaCertificado.Checked Then
            Me.txtNroCertificado.Text = "0"
            Me.dtpCertificado.Value = Date.Today
            Me.cmbUsuarioCertificado.SelectedIndex = -1
            DirectCast(Me._entidad, Entidades.Producto).CalidadFecCertificado = Nothing
            DirectCast(Me._entidad, Entidades.Producto).CalidadUsrCertificado = Nothing

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaIngreso_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaIngreso.CheckedChanged
      Try

         Me.dtpIngreso.Enabled = Me.chbFechaIngreso.Checked
         If Not Me.chbFechaIngreso.Checked Then
            Me.dtpIngreso.Value = Date.Today
            DirectCast(Me._entidad, Entidades.Producto).CalidadFechaIngreso = Nothing
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaEgreso_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEgreso.CheckedChanged
      Try
         Me.dtpEgreso.Enabled = Me.chbFechaEgreso.Checked
         If Not Me.chbFechaEgreso.Checked Then
            Me.dtpEgreso.Value = Date.Today
            DirectCast(Me._entidad, Entidades.Producto).CalidadFechaEgreso = Nothing
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaPreEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaPreEntrega.CheckedChanged
      Try
         Me.dtpPreentrega.Enabled = Me.chbFechaPreEntrega.Checked
         If Not Me.chbFechaPreEntrega.Checked Then
            Me.dtpPreentrega.Value = Date.Today
            DirectCast(Me._entidad, Entidades.Producto).CalidadFechaPreEnt = Nothing
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaEntProgramada_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntProgramada.CheckedChanged
      Try
         Me.dtpEntProgramada.Enabled = Me.chbFechaEntProgramada.Checked
         If Not Me.chbFechaEntProgramada.Checked Then
            Me.dtpEntProgramada.Value = Date.Today
            DirectCast(Me._entidad, Entidades.Producto).CalidadFechaEntProg = Nothing
         End If
         If StateForm = Win.StateForm.Actualizar Then
            'Seguridad de la Fecha de Entrega Programada
            Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
            Me.chbFechaEntProgramada.Enabled = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_FechaEntProg")
            Me.dtpEntProgramada.Enabled = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_FechaEntProg")
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaLiberado_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaLiberado.CheckedChanged
      Try
         Me.dtpLiberado.Enabled = Me.chbFechaLiberado.Checked
         Me.cmbUsuarioLiberado.Enabled = Me.chbFechaLiberado.Checked
         If Not Me.chbFechaLiberado.Checked Then
            DirectCast(Me._entidad, Entidades.Producto).CalidadStatusLiberado = False
            DirectCast(Me._entidad, Entidades.Producto).CalidadFechaLiberado = Nothing
            DirectCast(Me._entidad, Entidades.Producto).CalidadUserLiberado = Nothing
            Me.cmbUsuarioLiberado.SelectedIndex = -1
            Me.dtpLiberado.Value = Date.Today
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaEntregado_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntregado.CheckedChanged
      Try
         If Not Me.chbFechaEntregado.Checked Then
            If MessageBox.Show("Desea eliminar Fecha de Entregado? Se eliminará también Certificado de Entrega.", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then

               DirectCast(Me._entidad, Entidades.Producto).CalidadStatusEntregado = False
               DirectCast(Me._entidad, Entidades.Producto).CalidadFechaEntregado = Nothing
               DirectCast(Me._entidad, Entidades.Producto).CalidadUserEntregado = Nothing
               Me.dtpEntregado.Value = Date.Today
               Me.cmbUsuarioEntregado.SelectedIndex = -1

               Me.TBCFechas.SelectedTab = Me.tbpCertificados
               Me.chbFechaCertEntregado.Checked = False

            Else
               Me.chbFechaEntregado.Checked = True
            End If
         End If

         Me.dtpEntregado.Enabled = Me.chbFechaEntregado.Checked
         Me.cmbUsuarioEntregado.Enabled = Me.chbFechaEntregado.Checked

         If StateForm = Win.StateForm.Actualizar And chbFechaEntregado.Checked Then
            'Seguridad de la Fecha de Entregado 
            Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
            Me.chbFechaEntregado.Enabled = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_FechaEntregado")
            Me.dtpEntregado.Enabled = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_FechaEntregado")
            Me.cmbUsuarioEntregado.Enabled = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_FechaEntregado")

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtNroCertificado_Leave(sender As Object, e As EventArgs) Handles txtNroCertificado.Leave
      Try
         If txtNroCertificado.Text = "" Then
            txtNroCertificado.Text = "0"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbTipoServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoServicio.SelectedIndexChanged
      Try
         If Not _estaCargando And StateForm = Win.StateForm.Insertar And Me.cmbTipoServicio.SelectedIndex <> -1 Then
            Me.FormaIdProducto()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtNroCarroceria_Leave(sender As Object, e As EventArgs) Handles txtNroCarroceria.Leave
      Try
         If Not _estaCargando And StateForm = Win.StateForm.Insertar Then
            If Me.cmbTipoServicio.SelectedIndex <> -1 Then
               Me.FormaIdProducto()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaEntReProgramada_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntReProgramada.CheckedChanged
      Try
         Me.dtpEntReProgramada.Enabled = Me.chbFechaEntReProgramada.Checked
         If Not Me.chbFechaEntReProgramada.Checked Then
            Me.dtpEntReProgramada.Value = Date.Today
            DirectCast(Me._entidad, Entidades.Producto).CalidadFechaEntReProg = Nothing
         End If
         If StateForm = Win.StateForm.Actualizar Then
            'Seguridad de la Fecha de Entrega Programada
            Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
            Me.chbFechaEntReProgramada.Enabled = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_FechaEntReProg")
            Me.dtpEntReProgramada.Enabled = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_FechaEntReProg")
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dtpEntProgramada_ValueChanged(sender As Object, e As EventArgs) Handles dtpEntProgramada.ValueChanged
      'If StateForm = Win.StateForm.Insertar Then
      '   If chbFechaEntProgramada.Checked Then
      '      Me.chbFechaEntReProgramada.Checked = True
      '      dtpEntReProgramada.Value = dtpEntProgramada.Value
      '   End If
      'End If
   End Sub

   Private Sub btnActualizarNroMotor_Click(sender As Object, e As EventArgs) Handles btnActualizarNroMotor.Click
      Try

         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         Dim Chasis As DataTable = oProductos.GetNumeroChasisBejerman(Me.bscNroChasis.Text.ToString(), Publicos.CalidadBaseExternaClientes)
         If Chasis.Rows.Count < 1 Then
            MessageBox.Show("No existe número de Chasis.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            Me.bscNroChasis.Enabled = False
            Me.txtNroMotor.Text = Chasis.Rows(0).Item("stp_Obs").ToString()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"
   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = Long.Parse(dr.Cells("IdCliente").Value.ToString())
      Me.txtClienteFantasia.Text = dr.Cells("NombreDeFantasia").Value.ToString()

   End Sub

   Private Sub CargarDatosModelo(ByVal dr As DataGridViewRow)
      Me.bscModelo.Text = dr.Cells("NombreProductoModelo").Value.ToString()
      Me.bscModelo.Tag = Long.Parse(dr.Cells("IdProductoModelo").Value.ToString())
   End Sub

   Private Sub PreparaGrillaNroChasisMotor(buscador As Eniac.Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() _
                          With {.Titulo = "Nro de Carroceria - Nro de Motor",
                                .AnchoAyuda = 800}

         Dim col As Eniac.Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 1
         col.Nombre = "stpart_CodGen"
         col.Titulo = "Codigo"
         col.Ancho = 100
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 2
         col.Nombre = "art_DescGen"
         col.Titulo = "Descripcion"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 180
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 3
         col.Nombre = "stp_Partida"
         col.Titulo = "Nro de Chasis"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 150
         .ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 4
         col.Nombre = "stp_FechVtoIng"
         col.Titulo = "Fecha"
         col.Alineacion = DataGridViewContentAlignment.MiddleCenter
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 5
         col.Nombre = "stp_Obs"
         col.Titulo = "Nro de Motor"
         col.Alineacion = DataGridViewContentAlignment.MiddleCenter
         col.Ancho = 100
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 6
         col.Nombre = "stpdep_Cod"
         col.Titulo = "Deposito"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 70
         .ColumnasVisibles.Add(col)

      End With
   End Sub

   Private Sub PreparaGrillaModelo(buscador As Eniac.Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() _
                          With {.Titulo = "Modelos de Productos",
                                .AnchoAyuda = 500}

         Dim col As Eniac.Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 1
         col.Nombre = "CodigoProductoModelo"
         col.Titulo = "Codigo"
         col.Ancho = 100
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 2
         col.Nombre = "NombreProductoModelo"
         col.Titulo = "Descripcion"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 250
         .ColumnasVisibles.Add(col)
         '-- 

      End With
   End Sub


   Private Sub CargarNroChasisMotor(ByVal dr As DataGridViewRow)
      Me.txtNroMotor.Text = dr.Cells("stp_Obs").Value.ToString()
      Me.bscNroChasis.Text = dr.Cells("stp_Partida").Value.ToString()
      Dim oProductos As Reglas.Productos = New Reglas.Productos()
      If oProductos.ExisteNumeroChasis(dr.Cells("stp_Partida").Value.ToString()) Then
         MessageBox.Show("El numero de Chasis ya fue ingresado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNroMotor.Text = ""
         Me.bscNroChasis.Text = ""
      End If
      'If StateForm = StateForm.Insertar Then
      '   Me.bscNroChasis.Enabled = False
      'End If
   End Sub

   Private Sub FormaIdProducto()
      Dim TipoServicio As Entidades.ProductoTipoServicio = New Reglas.ProductosTiposServicios().GetUno(Integer.Parse(Me.cmbTipoServicio.SelectedValue.ToString()))
      Dim Numerador As DataTable = New DataTable()
      Dim Numero As Long = 0
      Dim oNumeradores As Reglas.Numeradores = New Reglas.Numeradores()
      If Not String.IsNullOrEmpty(Me.txtNroCarroceria.Text) Then
         If Integer.Parse(Me.txtNroCarroceria.Text.ToString()) <> 0 Then
            Numerador = oNumeradores._getUno(String.Format("{0}-{1}", TipoServicio.Prefijo, Me.txtNroCarroceria.Text))
            If Numerador.Rows.Count > 0 Then
               Numero = Long.Parse(Numerador.Rows(0).Item("Numero").ToString()) + 1
            Else
               Numero = 1
            End If
         End If
      End If

      If Not String.IsNullOrEmpty(TipoServicio.Prefijo) Then

         If TipoServicio.IdProductoTipoServicio = 2 Then
            Me.txtIdProducto.Text = String.Format("{0}-0{1}-{2}", TipoServicio.Prefijo, Numero.ToString(), Me.txtNroCarroceria.Text)

            'Traigo los datos de la carroceria original si existe 
            Dim producto As DataTable = New Reglas.Productos().Get1Calidad(Me.txtNroCarroceria.Text)
            If producto.Rows.Count > 0 Then
               Me.txtNombreGrupoItem.Text = producto.Rows(0).Item(Entidades.Producto.Columnas.NombreProducto.ToString()).ToString()
               Me.bscModelo.Text = producto.Rows(0).Item(Entidades.Producto.Columnas.NombreProductoModelo.ToString()).ToString()
               Me.bscModelo.Tag = producto.Rows(0).Item(Entidades.Producto.Columnas.IdProductoModelo.ToString()).ToString()
               Me.bscNroChasis.Text = producto.Rows(0).Item(Entidades.Producto.Columnas.CalidadNumeroChasis.ToString()).ToString()
               Me.txtNroMotor.Text = producto.Rows(0).Item(Entidades.Producto.Columnas.CalidadNroDeMotor.ToString()).ToString()
               Dim Cliente As DataTable = New Reglas.ProductosClientes().GetClientexProducto(producto.Rows(0).Item(Entidades.Producto.Columnas.IdProducto.ToString()).ToString().Trim())
               Dim Cli As Entidades.Cliente
               If Cliente.Rows.Count > 0 Then
                  _idCliente = Long.Parse(Cliente.Rows(0).Item("IdCliente").ToString())
                  Cli = New Reglas.Clientes().GetUno(_idCliente)
                  Me.bscCodigoCliente.Text = Cli.CodigoCliente.ToString()
                  Me.bscCodigoCliente.PresionarBoton()
               End If
               Me.txtNroCertificado.Text = producto.Rows(0).Item(Entidades.Producto.Columnas.CalidadNroCertificado.ToString()).ToString()
               If producto.Rows(0).Item(Entidades.Producto.Columnas.CalidadFecCertificado.ToString()).ToString() <> Nothing Then
                  Me.chbFechaCertificado.Checked = True
                  Me.dtpCertificado.Value = Date.Parse(producto.Rows(0).Item(Entidades.Producto.Columnas.CalidadFecCertificado.ToString()).ToString())
                  Me.cmbUsuarioCertificado.SelectedValue = producto.Rows(0).Item(Entidades.Producto.Columnas.CalidadUsrCertificado.ToString()).ToString()
               End If
               Me.txtNroCertEntregado.Text = producto.Rows(0).Item(Entidades.Producto.Columnas.CalidadNroCertEntregado.ToString()).ToString()
               If producto.Rows(0).Item(Entidades.Producto.Columnas.CalidadFecCertEntregado.ToString()).ToString() <> Nothing Then
                  Me.chbFechaCertEntregado.Checked = True
                  Me.dtpCertEntregado.Value = Date.Parse(producto.Rows(0).Item(Entidades.Producto.Columnas.CalidadFecCertEntregado.ToString()).ToString())
                  Me.cmbUsuarioCertEntregado.SelectedValue = producto.Rows(0).Item(Entidades.Producto.Columnas.CalidadUsrCertEntregado.ToString()).ToString()
               End If
               Me.DatosCabecera(False)
            Else
               If Not _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdCalidadABM_AltaRepSinProd") Then
                  MessageBox.Show("El número de carrocería no existe. Requiere autorización.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.txtNroCarroceria.Focus()
                  'Me.LimpiaCampos()
               End If

            End If

         ElseIf TipoServicio.IdProductoTipoServicio = 3 Then
            Numerador = oNumeradores._getUno(String.Format("{0}", TipoServicio.Prefijo))
            If Numerador.Rows.Count > 0 Then
               Numero = Long.Parse(Numerador.Rows(0).Item("Numero").ToString()) + 1
            Else
               Numero = 1
            End If
            Me.txtIdProducto.Text = String.Format("{0}-{1}", TipoServicio.Prefijo, Numero.ToString())

         End If
      Else
         Me.txtIdProducto.Text = Me.txtNroCarroceria.Text
         Me.LimpiaCampos()
         Me.DatosCabecera(True)
      End If

   End Sub
   Private Sub DatosCabecera(Habilita As Boolean)
      Me.txtNombreGrupoItem.Enabled = Habilita
      Me.bscModelo.Enabled = Habilita
      Me.bscNroChasis.Enabled = Habilita
      Me.bscCodigoCliente.Enabled = Habilita
      Me.bscCliente.Enabled = Habilita
      Me.txtClienteFantasia.Enabled = Habilita
      Me.txtNroCertificado.Enabled = Habilita
      Me.chbFechaCertificado.Enabled = Habilita
      Me.txtNroCertEntregado.Enabled = Habilita
      Me.chbFechaCertEntregado.Enabled = Habilita
      If Not Me.chbFechaCertificado.Enabled Then
         Me.dtpCertificado.Enabled = Habilita
         Me.cmbUsuarioCertificado.Enabled = Habilita
      End If
      If Not Me.chbFechaCertEntregado.Enabled Then
         Me.dtpCertEntregado.Enabled = Habilita
         Me.cmbUsuarioCertEntregado.Enabled = Habilita
      End If
   End Sub

   Private Sub LimpiaCampos()
      Me.txtNombreGrupoItem.Text = String.Empty
      Me.bscModelo.Text = String.Empty
      Me.bscNroChasis.Text = String.Empty
      Me.txtNroMotor.Text = String.Empty
      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCliente.Text = String.Empty
      Me.txtClienteFantasia.Text = String.Empty
      Me.txtNroCertificado.Text = String.Empty
      Me.chbFechaCertificado.Checked = False
      'Me.dtpCertificado.Value = Date.Now
      Me.cmbUsuarioCertificado.SelectedIndex = -1
   End Sub

   Private Sub txtNombreGrupoItem_TextChanged(sender As Object, e As EventArgs) Handles txtNombreGrupoItem.TextChanged
      Try
         If cmbTipoServicio.SelectedIndex = -1 And StateForm = StateForm.Insertar Then
            MessageBox.Show("Debe seleccionar el tipo de Servicio.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.cmbTipoServicio.Focus()
            Exit Sub
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub



   Private Sub chbFechaLiberadoPDI_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaLiberadoPDI.CheckedChanged
      Try
         Me.dtpLiberadoPDI.Enabled = Me.chbFechaLiberadoPDI.Checked
         Me.cmbUsuarioLiberadoPDI.Enabled = Me.chbFechaLiberadoPDI.Checked
         If Not Me.chbFechaLiberadoPDI.Checked Then
            DirectCast(Me._entidad, Entidades.Producto).CalidadStatusLiberadoPDI = False
            DirectCast(Me._entidad, Entidades.Producto).CalidadFechaLiberadoPDI = Nothing
            DirectCast(Me._entidad, Entidades.Producto).CalidadUserLiberadoPDI = Nothing
            Me.cmbUsuarioLiberadoPDI.SelectedIndex = -1
            Me.dtpLiberadoPDI.Value = Date.Today
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaCertEntregado_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaCertEntregado.CheckedChanged
      Try
         Me.dtpCertEntregado.Enabled = Me.chbFechaCertEntregado.Checked
         Me.cmbUsuarioCertEntregado.Enabled = Me.chbFechaCertEntregado.Checked
         If Not Me.chbFechaCertEntregado.Checked Then
            Me.txtNroCertEntregado.Text = "0"
            Me.dtpCertEntregado.Value = Date.Today
            Me.cmbUsuarioCertEntregado.SelectedIndex = -1
            Me.txtObsCertE.Text = ""
            Me.txtNroRemito.Text = "0"
            DirectCast(Me._entidad, Entidades.Producto).CalidadFecCertEntregado = Nothing
            DirectCast(Me._entidad, Entidades.Producto).CalidadUsrCertEntregado = Nothing
            DirectCast(Me._entidad, Entidades.Producto).CalidadNroCertEObs = Nothing

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region


End Class