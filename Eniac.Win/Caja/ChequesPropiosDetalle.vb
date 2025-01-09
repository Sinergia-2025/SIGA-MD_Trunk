Option Explicit On
Option Strict On

Imports Eniac.Reglas
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ChequesPropiosDetalle

   Private _publicos As Publicos

#Region "Constructores"

   Public Sub New(ByVal entidad As Entidades.Cheque)
      InitializeComponent()

      entidad.EsPropio = True
      Me._entidad = entidad
      Me._publicos = New Publicos()
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._entidad.IdSucursal = actual.Sucursal.Id
         Me._entidad.Usuario = actual.Nombre
         Me._entidad.Password = actual.Pwd

         Dim oCuentas As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Me.cmbCuentas.DisplayMember = "NombreCuenta"
         Me.cmbCuentas.ValueMember = "IdCuentaBancaria"
         Me.cmbCuentas.DataSource = oCuentas.GetAllActivos()

         'Dim oTipoDoc As Eniac.Reglas.TiposDocumento = New Eniac.Reglas.TiposDocumento()
         'Me.cmbTipoDoc.DisplayMember = "TipoDocumento"
         'Me.cmbTipoDoc.ValueMember = "TipoDocumento"
         'Me.cmbTipoDoc.DataSource = oTipoDoc.GetTodos()
         'Me.cmbTipoDoc.SelectedIndex = -1

         Dim oLoca As Localidades = New Localidades()
         Me.cmbLocalidad.DisplayMember = "NombreLocalidad"
         Me.cmbLocalidad.ValueMember = "IdLocalidad"
         Me.cmbLocalidad.DataSource = oLoca.GetAll()
         Me.cmbLocalidad.SelectedIndex = -1

         Dim oBancos As Reglas.Bancos = New Reglas.Bancos()
         Me.cmbBanco.DisplayMember = "NombreBanco"
         Me.cmbBanco.ValueMember = "IdBanco"
         Me.cmbBanco.DataSource = oBancos.GetAll()
         Me.cmbBanco.SelectedIndex = -1

         Me._liSources.Add("Banco", DirectCast(Me._entidad, Entidades.Cheque).Banco)
         Me._liSources.Add("Localidad", DirectCast(Me._entidad, Entidades.Cheque).Localidad)
         Me._liSources.Add("Cliente", DirectCast(Me._entidad, Entidades.Cheque).Cliente)
         Me._liSources.Add("Proveedor", DirectCast(Me._entidad, Entidades.Cheque).Proveedor)
         Me._liSources.Add("CuentaBancaria", DirectCast(Me._entidad, Entidades.Cheque).CuentaBancaria)

         '# Tipo de Cheque y Nro de Operación
         '# Carga Combo Tipos Cheques
         Me._publicos.CargaComboTiposCheques(Me.cmbTipoCheque)

         Me.BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Win.StateForm.Insertar Then
            Me.dtpFechaEmision.Value = Date.Today
            Me.dtpFechaCobro.Value = Date.Today
            Me.cmbCuentas.SelectedIndex = -1
            If Me.cmbCuentas.Items.Count > 0 Then
               Me.cmbCuentas.SelectedIndex = 0
            End If
         Else
            Me.cmbTipoCheque.Enabled = True
            Me.txtNroOperacion.Enabled = False

            Me.dtpFechaCobro.Enabled = True
            Me.dtpFechaEmision.Enabled = False
            Me.txtImporte.Enabled = False

            If DirectCast(Me._entidad, Entidades.Cheque).IdCajaEgreso > 0 Then
               Me.txtNombreCajaEgreso.Text = New Reglas.CajasNombres().GetUna(actual.Sucursal.IdSucursal, DirectCast(Me._entidad, Entidades.Cheque).IdCajaEgreso).NombreCaja
            End If

         End If

         'Si el cheque tiene movimiento de Ingreso Caja, mejor que no cambie nada.
         'If Integer.Parse(Me.txtNroPlanillaEgreso.Text) > 0 Then
         '   Me.grbDetalle.Enabled = False
         'End If


      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Cheques
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Dim vacio As String = ""

      If Integer.Parse(Me.txtNumeroCheque.Text) <= 0 Then
         Return "El Número de Cheque es inválido."
      End If

      If Integer.Parse(Me.txtBancoSucursal.Text) <= 0 Then
         Return "La Sucursal del Banco es inválida."
      End If

      If Decimal.Parse(Me.txtImporte.Text) <= 0 Then
         Return "El Importe del Cheque es inválido."
      End If

      '# Tipo de Cheque
      If Me.cmbTipoCheque.SelectedIndex = -1 Then
         Me.cmbTipoCheque.Focus()
         Return "ATENCIÓN: No seleccionó un Tipo de Cheque"
      End If

      If DirectCast(Me.cmbTipoCheque.SelectedItem, Entidades.TiposCheques).SolicitaNroOperacion AndAlso
         String.IsNullOrEmpty(Me.txtNroOperacion.Text) Then
         Me.txtNroOperacion.Focus()
         Return "ATENCIÓN: Debe ingresar un Número de Operación para el Tipo de Cheque seleccionado."
      End If

      'If Not Me.bscCodigoCliente.Selecciono And Not Me.bscProveedor.Selecciono Then
      '   Return "No indico el Proveedor a quien se le entregó el cheque"
      'End If
      If Me.cmbTipoCheque.SelectedIndex = -1 Then
         Me.cmbTipoCheque.Focus()
         Return "ATENCIÓN: No seleccionó un Tipo de Cheque"
      End If

      If Me.cmbTipoCheque.SelectedIndex <> -1 Then
         If DirectCast(Me.cmbTipoCheque.SelectedItem, Entidades.TiposCheques).SolicitaNroOperacion AndAlso
            String.IsNullOrEmpty(Me.txtNroOperacion.Text) Then
            Me.txtNroOperacion.Focus()
            Return "ATENCIÓN: Debe ingresar un Número de Operación para el Tipo de Cheque seleccionado."
         End If
      End If

      Return vacio

   End Function

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
      'DirectCast(Me._entidad, Entidades.ChequePropio).Proveedor = New Entidades.Proveedor()
      'DirectCast(Me._entidad, Entidades.Cheque).CuentaBancaria = New Entidades.CuentaBancaria()
      Me.txtNumeroCheque.Text = "0"
      Me.txtImporte.Text = "0.00"
      Me.dtpFechaCobro.Value = DateTime.Now
      Me.dtpFechaEmision.Value = DateTime.Now
      'Me.cmbTipoDoc.SelectedIndex = -1
      'Me.bscCodigoCliente.Text = String.Empty
      'Me.bscCodigoCliente.Selecciono = False
      'Me.bscProveedor.Text = String.Empty
      'Me.bscProveedor.Selecciono = False
   End Sub

#End Region

#Region "Eventos"

   Private Sub cmbCuentas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCuentas.SelectedIndexChanged
      Try
         Me.CargarDatosCuenta()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCuenta()
      If Me.cmbCuentas.SelectedIndex <> -1 Then
         Dim cta As System.Data.DataRowView = DirectCast(Me.cmbCuentas.SelectedItem, System.Data.DataRowView)
         Me.cmbBanco.SelectedValue = cta("IdBanco").ToString()
         Me.txtBancoSucursal.Text = cta("IdBancoSucursal").ToString()
         Me.cmbLocalidad.SelectedValue = cta("IdLocalidad").ToString()
      Else
         Me.cmbBanco.SelectedIndex = -1
         Me.cmbLocalidad.SelectedIndex = -1
         Me.txtBancoSucursal.Text = ""
      End If
   End Sub

   Private Sub cmbTipoCheque_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoCheque.SelectedIndexChanged
      If Me.cmbTipoCheque.SelectedIndex <> -1 Then
         If Not DirectCast(Me.cmbTipoCheque.SelectedItem, Entidades.TiposCheques).SolicitaNroOperacion Then
            Me.txtNroOperacion.Enabled = False
            Me.txtNroOperacion.Clear()
         Else
            Me.txtNroOperacion.Enabled = True
         End If
      End If
   End Sub

#End Region
End Class
