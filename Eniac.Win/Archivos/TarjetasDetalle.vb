Option Strict Off
Public Class TarjetasDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Tarjeta)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.CierraAutomaticamente = True

      Dim dt As DataTable = New DataTable()
      dt.Columns.Add("Id")
      dt.Columns.Add("Nombre")

      Dim dr As DataRow
      dr = dt.NewRow()
      dr(0) = "D"
      dr(1) = "Debito"
      dt.Rows.Add(dr)

      dr = dt.NewRow()
      dr(0) = "C"
      dr(1) = "Credito"
      dt.Rows.Add(dr)

      Me.cmbTipo.DataSource = dt
      Me.cmbTipo.ValueMember = "Id"
      Me.cmbTipo.DisplayMember = "Nombre"

      Me.cmbDias.Items.Insert(0, "Lunes")
      Me.cmbDias.Items.Insert(1, "Martes")
      Me.cmbDias.Items.Insert(2, "Miercoles")
      Me.cmbDias.Items.Insert(3, "Jueves")
      Me.cmbDias.Items.Insert(4, "Viernes")
      Me.cmbDias.SelectedIndex = -1

      Me._publicos.CargaComboCuentasBancarias(Me.cmbCuentasBancarias)

      Me._liSources.Add("CuentaBancaria", DirectCast(Me._entidad, Entidades.Tarjeta).CuentaBancaria)

      Me.BindearControles(Me._entidad, Me._liSources)

      DirectCast(Me._entidad, Entidades.Tarjeta).Usuario = Eniac.Entidades.Usuario.Actual.Nombre

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
         Me.rbtPagoPosVenta.Checked = True
         Me.rbtPagoPosCorte.Checked = False
         Me.rbtDiaMes.Checked = False
         Me.chbHabilitada.Checked = True
         Me.txtTarCantDiasAcred.Text = ""
         Me.txtDiaMes.Text = ""

         chbProveedor.Checked = False
         bscCodigoProveedor.Text = String.Empty
         bscProveedor.Text = String.Empty
      Else
         If DirectCast(Me._entidad, Entidades.Tarjeta).TipoTarjeta = Entidades.Tarjeta.TiposTarjetas.Debito Then
            Me.cmbTipo.SelectedValue = "D"
         ElseIf DirectCast(Me._entidad, Entidades.Tarjeta).TipoTarjeta = Entidades.Tarjeta.TiposTarjetas.Credito Then
            Me.cmbTipo.SelectedValue = "C"
         End If

         If DirectCast(Me._entidad, Entidades.Tarjeta).Acreditacion = True Then
            Me.chbAcreditacion.Checked = True
            Me.rbtPagoPosVenta.Checked = DirectCast(Me._entidad, Entidades.Tarjeta).PagoPosVenta
            Me.rbtPagoPosCorte.Checked = DirectCast(Me._entidad, Entidades.Tarjeta).PagoPosCorte
            Me.txtTarCantDiasAcred.Text = DirectCast(Me._entidad, Entidades.Tarjeta).CantDiasAcredit
            Me.cmbDias.SelectedIndex = DirectCast(Me._entidad, Entidades.Tarjeta).DiaCorte
            Me.rbtDiaMes.Checked = DirectCast(Me._entidad, Entidades.Tarjeta).PagoDiaMes
            Me.txtDiaMes.Text = DirectCast(Me._entidad, Entidades.Tarjeta).DiaMes
         End If

         If Publicos.TieneModuloContabilidad Then
            UcCuentas1.Cuenta = DirectCast(Me._entidad, Entidades.Tarjeta).CuentaContable
         Else
            grpContabilidad.Visible = False
         End If

         If DirectCast(_entidad, Entidades.Tarjeta).IdProveedor > 0 Then
            chbProveedor.Checked = True
            bscCodigoProveedor.Text = DirectCast(_entidad, Entidades.Tarjeta).CodigoProveedor.ToString()
            bscCodigoProveedor.Tag = DirectCast(_entidad, Entidades.Tarjeta).IdProveedor.ToString()
            bscCodigoProveedor.PresionarBoton()
         End If

      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Tarjetas()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If Me.chbAcreditacion.Checked And Me.cmbCuentasBancarias.SelectedIndex = -1 Then
         Return "ATENCION: Activo la Acreditacion. Debe Seleccionar la Cuenta Bancaria."
         Me.cmbCuentasBancarias.Focus()
      End If

      If Me.chbAcreditacion.Checked And Me.txtTarCantDiasAcred.Text = 0 Then
         Return "ATENCION: Activo la Acreditacion. Debe Seleccionar Cantidad de Días."
         Me.txtTarCantDiasAcred.Focus()
      End If

      If Me.chbAcreditacion.Checked And Not Me.rbtPagoPosVenta.Checked And Not Me.rbtPagoPosCorte.Checked And Not Me.rbtDiaMes.Checked Then
         Return "ATENCION: Activo la Acreditacion. Debe Seleccionar una forma de Pago."
         Me.rbtPagoPosVenta.Focus()
      End If

      If Me.chbAcreditacion.Checked And Me.rbtPagoPosCorte.Checked And Me.cmbDias.SelectedIndex = -1 Then
         Return "ATENCION: Activo Pago Movimientos hasta ultimo:.Debe seleccionar un día"
         Me.cmbDias.Focus()
      End If

      If Me.chbAcreditacion.Checked And Me.rbtDiaMes.Checked And Me.txtDiaMes.Text = 0 Then
         Return "ATENCION: Activo la Acreditacion por dia del Mes. Debe Ingresar cantidad de días."
         Me.txtDiaMes.Focus()
      End If

      If Me.chbAcreditacion.Checked And Me.rbtDiaMes.Checked And Me.txtTarCantDiasAcred.Text = 0 Then
         Return "ATENCION: Activo la Acreditacion por dia del Mes. Debe Ingresar cantidad de días."
         Me.txtDiaMes.Focus()
      End If

      If Publicos.TieneModuloContabilidad Then
         If UcCuentas1.Cuenta Is Nothing OrElse UcCuentas1.Cuenta.IdCuenta = 0 Then
            UcCuentas1.Focus()
            Return "Debe indicar una cuenta contable para la categoría."
         End If
      End If

      If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
         Return "ATENCION: Activo la selección de Proveedor. Debe Ingresar un Proveedor."
         Me.txtDiaMes.Focus()
      End If


      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()

      MyBase.ValidarDetalle()

      If Me.cmbTipo.SelectedValue.ToString() = "D" Then
         DirectCast(Me._entidad, Entidades.Tarjeta).TipoTarjeta = Entidades.Tarjeta.TiposTarjetas.Debito
      ElseIf Me.cmbTipo.SelectedValue.ToString() = "C" Then
         DirectCast(Me._entidad, Entidades.Tarjeta).TipoTarjeta = Entidades.Tarjeta.TiposTarjetas.Credito
      End If
      If Not String.IsNullOrEmpty(Me.cmbCuentasBancarias.SelectedValue) Then
         DirectCast(Me._entidad, Entidades.Tarjeta).CuentaBancaria = New Reglas.CuentasBancarias().GetUna(Me.cmbCuentasBancarias.SelectedValue)
      End If
      If Me.chbAcreditacion.Checked Then
         DirectCast(Me._entidad, Entidades.Tarjeta).Acreditacion = Me.chbAcreditacion.Checked
         DirectCast(Me._entidad, Entidades.Tarjeta).CantDiasAcredit = Integer.Parse(Me.txtTarCantDiasAcred.Text.ToString())
         If Me.rbtPagoPosVenta.Checked Then
            DirectCast(Me._entidad, Entidades.Tarjeta).PagoPosVenta = Me.rbtPagoPosVenta.Checked
            DirectCast(Me._entidad, Entidades.Tarjeta).PagoPosCorte = Me.rbtPagoPosCorte.Checked
            DirectCast(Me._entidad, Entidades.Tarjeta).PagoDiaMes = Me.rbtDiaMes.Checked
            DirectCast(Me._entidad, Entidades.Tarjeta).DiaMes = -1
            DirectCast(Me._entidad, Entidades.Tarjeta).DiaCorte = -1
         Else
            If Me.rbtDiaMes.Checked Then
               DirectCast(Me._entidad, Entidades.Tarjeta).PagoPosVenta = Me.rbtPagoPosVenta.Checked
               DirectCast(Me._entidad, Entidades.Tarjeta).PagoPosCorte = Me.rbtPagoPosCorte.Checked
               DirectCast(Me._entidad, Entidades.Tarjeta).PagoDiaMes = Me.rbtDiaMes.Checked
               DirectCast(Me._entidad, Entidades.Tarjeta).DiaMes = Integer.Parse(Me.txtDiaMes.Text.ToString())
               DirectCast(Me._entidad, Entidades.Tarjeta).DiaCorte = -1
            Else
               DirectCast(Me._entidad, Entidades.Tarjeta).PagoPosVenta = Me.rbtPagoPosVenta.Checked
               DirectCast(Me._entidad, Entidades.Tarjeta).PagoPosCorte = Me.rbtPagoPosCorte.Checked
               DirectCast(Me._entidad, Entidades.Tarjeta).PagoDiaMes = Me.rbtDiaMes.Checked
               DirectCast(Me._entidad, Entidades.Tarjeta).DiaCorte = cmbDias.SelectedIndex
               DirectCast(Me._entidad, Entidades.Tarjeta).DiaMes = -1
            End If

         End If

      Else
         DirectCast(Me._entidad, Entidades.Tarjeta).Acreditacion = False
         DirectCast(Me._entidad, Entidades.Tarjeta).PagoPosCorte = False
         DirectCast(Me._entidad, Entidades.Tarjeta).PagoPosVenta = False
         DirectCast(Me._entidad, Entidades.Tarjeta).CantDiasAcredit = -1
         DirectCast(Me._entidad, Entidades.Tarjeta).DiaCorte = -1
         DirectCast(Me._entidad, Entidades.Tarjeta).PagoDiaMes = False
         DirectCast(Me._entidad, Entidades.Tarjeta).DiaMes = -1
      End If

      If Publicos.TieneModuloContabilidad Then
         DirectCast(_entidad, Entidades.Tarjeta).CuentaContable = UcCuentas1.Cuenta
      Else
         DirectCast(_entidad, Entidades.Tarjeta).CuentaContable = Nothing
      End If

      If chbProveedor.Checked And bscCodigoProveedor.Selecciono Or bscProveedor.Selecciono Then
         DirectCast(_entidad, Entidades.Tarjeta).IdProveedor = Integer.Parse(bscCodigoProveedor.Tag.ToString())
      Else
         DirectCast(_entidad, Entidades.Tarjeta).IdProveedor = 0
      End If


      MyBase.Aceptar()
   End Sub


#End Region

#Region "Eventos"

   Private Sub rbtPagoPosCorte_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtPagoPosCorte.CheckedChanged
      Me.cmbDias.Enabled = Me.rbtPagoPosCorte.Checked
      If Me.cmbDias.Enabled Then
         Me.cmbDias.Focus()
      End If
   End Sub

   Private Sub rbtDiaMes_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtDiaMes.CheckedChanged
      Me.txtDiaMes.Enabled = Me.rbtDiaMes.Checked
      If Me.txtDiaMes.Enabled Then
         Me.txtDiaMes.Focus()
      End If
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim ota As Reglas.Tarjetas = New Reglas.Tarjetas()
      Me.txtIdTarjeta.Text = ota.GetProximoId().ToString()
   End Sub

   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      bscCodigoProveedor.Enabled = chbProveedor.Checked
      bscProveedor.Enabled = chbProveedor.Checked
      bscCodigoProveedor.Text = String.Empty
      bscCodigoProveedor.Tag = String.Empty
      bscProveedor.Text = String.Empty
      DirectCast(Me._entidad, Entidades.Tarjeta).IdProveedor = 0
      If chbProveedor.Checked Then
         bscCodigoProveedor.Select()
      End If
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores

         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores

         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      Try
         If e.FilaDevuelta IsNot Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString
   End Sub
#End Region

End Class