Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class AlquilerDetalle

#Region "Campos"

   Private _publicos As Publicos
   Public tipodoc As String = String.Empty
   Public dtGrilla As DataTable  'dim
   Public IdProductoSel As String
   Public NombreProductoSel As String = String.Empty
   Public AnioProductoSel As Integer = 0
   Public ChasisProductoSel As String = String.Empty

   Public _fechaPadre As Date
   Public _ProductoPadre As String
   Public _tarifa As Decimal
   Private _decimalesAMostrar As Integer = 2

#End Region

   Public Property tarifa() As Decimal
      Get
         Return _tarifa
      End Get
      Set(ByVal value As Decimal)
         _tarifa = value
      End Set
   End Property

   Public Property ProductoPadre() As String
      Get
         Return _ProductoPadre
      End Get
      Set(ByVal value As String)
         _ProductoPadre = value
      End Set
   End Property

   Public Property fechaPadre() As Date
      Get
         Return _fechaPadre
      End Get
      Set(ByVal value As Date)
         _fechaPadre = value
      End Set
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Alquiler)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then

         Me.CargarProximoNumero()

         Me.dtpFechaContrato.Value = Date.Now
         Me.dtpDesde.Value = Date.Now
         Me.dtpHasta.Value = Me.dtpDesde.Value.AddMonths(1)
         Me.dtpFinReal.Value = Me.dtpDesde.Value.AddMonths(1)
         Me.chkRenovable.Checked = True

         DirectCast(Me._entidad, Entidades.Alquiler).IdEstado = 10 'ALTA
         DirectCast(Me._entidad, Entidades.Alquiler).IdUsuario = actual.Nombre

         Me.bscCodigoCliente.Focus()

      Else

         Me.bscCodigoCliente.PresionarBoton()
            Me.bscCodigoProducto2.PresionarBoton()
            Me.AgregarFila()

        End If

        Dim oAlqEstados As Reglas.AlquileresEstadosContratos = New Reglas.AlquileresEstadosContratos
        Me.txtEstado.Text = oAlqEstados.GetUno(DirectCast(Me._entidad, Entidades.Alquiler).IdEstado).NombreEstado

        'Solo se permite modificar en ALTA.
        If Me.txtEstado.Text <> "ALTA" Then
            Me.grbDetalle.Enabled = False
            Me.grbLocatario.Enabled = False
        End If

      Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
      'Seguridad de la Edición de Clientes (enlace a través de la etiqueta "Más info...")
      Me.llbCliente.Visible = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "Clientes-PuedeUsarMasInfo")
    End Sub

    Protected Overrides Function GetReglas() As Eniac.Reglas.Base
        Return New Reglas.Alquileres
    End Function

    Protected Overrides Sub Aceptar()

        If Me.ValidaGrabar() Then

            DirectCast(Me._entidad, Entidades.Alquiler).IdSucursal = actual.Sucursal.IdSucursal
            DirectCast(Me._entidad, Entidades.Alquiler).IdProducto = IdProductoSel

            DirectCast(Me._entidad, Entidades.Alquiler).horaE = Me.dtpHoraE.Text
            DirectCast(Me._entidad, Entidades.Alquiler).horaR = Me.dtpHoraR.Text

            MyBase.Aceptar()

            If Not Me.HayError Then
                'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
                '   Me.ImprimirContrato()
                'End If
                Me.Close()
            End If

        End If

    End Sub

#End Region

#Region "Eventos"

    Private Sub txtImporteAlquiler_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporteAlquiler.LostFocus
        ActualizarMontoTotal()
    End Sub

    Private Sub txtImporteTraslado_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporteTraslado.LostFocus
        ActualizarMontoTotal()
    End Sub

    Private Sub dtpHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpHasta.ValueChanged
        Me.dtpFinReal.Value = Me.dtpHasta.Value
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
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Try
            '   Me.Nuevo()
            'Catch ex1 As Exception
            '   MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End Try
        End Try
    End Sub

    Private Sub llbCliente_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbCliente.LinkClicked

      Try
         If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then

            Dim clie As Eniac.Entidades.Cliente = New Eniac.Entidades.Cliente
            Dim blnIncluirFoto As Boolean = True

            clie = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), blnIncluirFoto)
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

    Private Sub btnLimpiarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarProducto.Click
        Me.LimpiarCamposProductos()
        Me.bscCodigoProducto2.Focus()
    End Sub

    Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos()
            Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
            Dim blnSoloAlquilables As Boolean = True
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", , , blnSoloAlquilables)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
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
            Dim blnSoloAlquilables As Boolean = True
            Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", , blnSoloAlquilables)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscmodelo_BuscadorClick() Handles bscmodelo.BuscadorClick

        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me.bscmodelo.Datos = oProductos.GetProductosXModelo(Me.bscmodelo.Text.Trim())

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub bscmodelo_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscmodelo.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Me.Nuevo()
        End Try
    End Sub

    Private Sub bscNumeroSerie_BuscadorClick() Handles bscNumeroSerie.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me.bscNumeroSerie.Datos = oProductos.GetProductosXNumeroSerie(Me.bscNumeroSerie.Text.Trim())

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub bscNumeroSerie_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNumeroSerie.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Me.Nuevo()
        End Try
    End Sub

    Private Sub bscCaractSII_BuscadorClick() Handles bscCaractSII.BuscadorClick

        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me.bscCaractSII.Datos = oProductos.GetProductosXCaractSII(Me.bscCaractSII.Text.Trim())

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub bscCaractSII_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCaractSII.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Me.Nuevo()
        End Try
    End Sub

    Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click
        If Me.ValidarProducto() Then
            Me.AgregarFila()
            Me.btnInsertar.Enabled = False
            Me.LimpiarCamposProductos()
            Me.txtMonto.Focus()
        End If
    End Sub

    Private Sub MenuQuitarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQuitarProducto.Click
        Me.btnEliminar.PerformClick()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.dgvProductos.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un Producto a Quitar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            DirectCast(Me.dgvProductos.DataSource, DataTable).Rows.RemoveAt(Me.dgvProductos.SelectedCells.Item(1).RowIndex)
            Me.dgvProductos.DataSource = dtGrilla
            Me.btnInsertar.Enabled = True
            Me.LimpiarCamposProductos()
            Me.bscCodigoProducto2.Focus()
        End If
    End Sub

    Private Sub grdProducto_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvProductos.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            menucontextual.Show(Me.dgvProductos, e.X, e.Y)
        End If
    End Sub

    Private Sub cmdTarifas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTarifas.Click

        If Me.dgvProductos.Rows.Count = 0 Then
            MessageBox.Show("Seleccione un Producto para visualizar las tarifas", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Exit Sub
        End If

        Dim cantdias As Integer = CInt(Me.dtpHasta.Value.Subtract(Me.dtpDesde.Value).TotalDays)
        Dim frmTarifaSug As New TarifaSugerida

        frmTarifaSug._IdProductoPadre = Me.dgvProductos.Rows(0).Cells("IdProducto").Value.ToString()
        frmTarifaSug._cantDiasPadre = cantdias
        frmTarifaSug._padre = Me
        frmTarifaSug.ShowDialog()

        If Me._tarifa <> 0 Then
            Me.txtImporteAlquiler.Text = Me._tarifa.ToString("##,##0.00")
            Me.txtImporteTraslado.Focus()
        Else
            Me.txtImporteAlquiler.Text = "0.00"
        End If

    End Sub

    Private Sub cmdDisponibles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisponibles.Click

        Dim frmProdDisponibles As New infProductosDisponibles
        frmProdDisponibles._padre = Me
        frmProdDisponibles.ShowDialog()

        If Me._ProductoPadre = "" Or Me._fechaPadre = #12:00:00 AM# Then
            Exit Sub
        End If
        Me.dtpDesde.Value = Me._fechaPadre
        Me.dtpHasta.Value = Me._fechaPadre.AddMonths(1)
        ' Me.dtpReal.Value = Me._fechaPadre.AddMonths(1)

        'Dim oProductos As Reglas.Productos = New Reglas.Productos
        'Dim dtaux As DataTable
        'dtaux = oProductos.Get1(Me._ProductoPadre)
        'Me.bscSerie.Text = dtaux.Rows(0)("NumeroSerie").ToString
        'Me.bscSerie.PresionarBoton()

        Me.bscCodigoProducto2.Text = Me._ProductoPadre
        Me.bscCodigoProducto2.PresionarBoton()

        Me.AgregarFila()

    End Sub

#End Region

#Region "Metodos"

    Private Sub ActualizarMontoTotal()
        Dim monto As Decimal = 0
        If txtImporteAlquiler.Text = String.Empty Then
            txtImporteAlquiler.Text = "0." + New String("0"c, Me._decimalesAMostrar)
        End If

        If txtImporteTraslado.Text = String.Empty Then
            txtImporteTraslado.Text = "0." + New String("0"c, Me._decimalesAMostrar)
        End If

        monto = Decimal.Parse(txtImporteAlquiler.Text) + Decimal.Parse(txtImporteTraslado.Text)

        txtMonto.Text = monto.ToString("###,##0.00")
    End Sub

    Private Sub CargarProximoNumero()
        Dim oAlquileres As Reglas.Alquileres = New Reglas.Alquileres()
        Me.txtNumeroContrato.Text = (oAlquileres.GetIDMaximo() + 1).ToString("####0")
    End Sub

    Private Function ValidarProducto() As Boolean

        If String.IsNullOrEmpty(IdProductoSel) Then
            MessageBox.Show("Debe Selecionar un Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Return False
        End If

        Return True

    End Function

    Private Sub AgregarFila()

        Dim fila As DataRow
        dtGrilla = crearTablaGrilla()
        fila = dtGrilla.NewRow
        fila("IdProducto") = IdProductoSel
        fila("NombreProducto") = NombreProductoSel
        fila("EquipoMarca") = ChasisProductoSel
        fila("EquipoModelo") = Me.bscmodelo.Text
        fila("NumeroSerie") = Me.bscNumeroSerie.Text
        fila("caractSII") = Me.bscCaractSII.Text
        fila("Anio") = AnioProductoSel

        dtGrilla.Rows.Add(fila)
        Me.dgvProductos.DataSource = dtGrilla

    End Sub

    Private Function crearTablaGrilla() As DataTable

        Dim datosGrillas As New DataTable

        datosGrillas.Columns.Add("IdProducto", System.Type.GetType("System.String"))
        datosGrillas.Columns.Add("NombreProducto", System.Type.GetType("System.String"))
        datosGrillas.Columns.Add("EquipoMarca", System.Type.GetType("System.String"))
        datosGrillas.Columns.Add("EquipoModelo", System.Type.GetType("System.String"))
        datosGrillas.Columns.Add("NumeroSerie", System.Type.GetType("System.String"))
        datosGrillas.Columns.Add("caractSII", System.Type.GetType("System.String"))
        datosGrillas.Columns.Add("Anio", System.Type.GetType("System.Int32"))

        Return datosGrillas

    End Function

    Private Function ValidaGrabar() As Boolean

        If Me.dtpHasta.Value.CompareTo(Me.dtpFinReal.Value) = 1 Then
            MessageBox.Show("La fecha REAL de finalización debe ser mayor o igual a la fecha hasta del Contrato", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpFinReal.Focus()
            Return False
        End If

        If Me.dgvProductos.SelectedRows.Count = 0 Then
            MessageBox.Show("Debe agregar un Producto al Contrato", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Return False
        End If

        If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Dim oAlquiler As Reglas.Alquileres = New Reglas.Alquileres
            If oAlquiler.validarFechaReal(actual.Sucursal.IdSucursal, Me.dgvProductos.Rows(0).Cells("IdProducto").Value.ToString(), Me.dtpFinReal.Value) Then
                MessageBox.Show("El Producto se encuentra Alquilado en la fecha Seleccionada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtpDesde.Focus()
                Return False
            End If
        End If

        If Decimal.Parse(Me.txtMonto.Text & "0") <= 0 Then
            MessageBox.Show("Debe ingresar un Monto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMonto.Focus()
            Return False
        End If

        'If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
        '   MessageBox.Show("Debe ingresar Locatario para el Contrato", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '   Me.bscCodigoCliente.Focus()
        '   Return False
        'End If

        'If Long.Parse(Me.txtLocatarioNroDocumento.Text & "0") <= 0 Then
        '   MessageBox.Show("Debe ingresar el Documento del Locatario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '   Me.txtLocatarioNroDocumento.Focus()
        '   Return False
        'End If

        'If Me.txtLugarER.Text = String.Empty Then
        '   MessageBox.Show("Debe agregar un lugar de entrega/retiro del Contrato", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '   Me.txtLugarER.Focus()
        '   Return False
        'End If

        'If Me.dtpHoraE.Text = "00:00" Then
        '   MessageBox.Show("Debe agregar una hora de entrega para el Contrato", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '   Me.dtpHoraE.Focus()
        '   Return False
        'End If

        'If Me.dtpHoraR.Text = "00:00" Then
        '   MessageBox.Show("Debe agregar una hora de retiro para el Contrato", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '   Me.dtpHoraR.Focus()
        '   Return False
        'End If

        'If Me.txtPersonalCapacitado.Text = String.Empty Then
        '   MessageBox.Show("Debe agregar el Personal Capacitado requerido para el Contrato", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '   Me.txtPersonalCapacitado.Focus()
        '   Return False
        'End If

        Return True

    End Function

    Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

        Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
        Me.bscCliente.Enabled = False
        Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
        Me.bscCodigoCliente.Enabled = False
        Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

        Me.bscCodigoProducto2.Focus()

    End Sub

    Private Sub CargarProducto(ByVal dr As DataGridViewRow)

        Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
        Me.bscCodigoProducto2.Enabled = False
        IdProductoSel = Me.bscCodigoProducto2.Text

        Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString.Trim()
        Me.bscProducto2.Enabled = False
        NombreProductoSel = Me.bscProducto2.Text

        Me.bscmodelo.Text = dr.Cells("EquipoModelo").Value.ToString()
        Me.bscmodelo.Enabled = False

        Me.bscNumeroSerie.Text = dr.Cells("NumeroSerie").Value.ToString()
        Me.bscNumeroSerie.Enabled = False

        Me.bscCaractSII.Text = dr.Cells("CaractSII").Value.ToString()
        Me.bscCaractSII.Enabled = False

        ChasisProductoSel = dr.Cells("EquipoMarca").Value.ToString()

        AnioProductoSel = Integer.Parse(dr.Cells("Anio").Value.ToString())

        'VER
        'Me.txtCantidad.Focus()
        'Me.txtCantidad.SelectAll()

        Me.btnInsertar.Focus()

    End Sub

    Private Sub LimpiarCamposProductos()

        Me.bscCodigoProducto2.Enabled = True
        Me.bscCodigoProducto2.Text = ""

        Me.bscProducto2.Enabled = True
        Me.bscProducto2.Text = ""

        Me.bscmodelo.Enabled = True
        Me.bscmodelo.Text = ""

        Me.bscNumeroSerie.Enabled = True
        Me.bscNumeroSerie.Text = ""

        Me.bscCaractSII.Enabled = True
        Me.bscCaractSII.Text = ""

        'Limpiar se llama al Insertar y al Eliminar el producto.
        If Me.dgvProductos.RowCount = 0 Then
            IdProductoSel = String.Empty
            NombreProductoSel = String.Empty
            AnioProductoSel = 0
            ChasisProductoSel = String.Empty
        End If

    End Sub

#End Region

End Class