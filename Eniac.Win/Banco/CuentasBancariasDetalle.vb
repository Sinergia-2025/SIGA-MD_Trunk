Public Class CuentasBancariasDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.CuentaBancaria)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Campos"
   Private _publicos As Publicos
   Private _publicosCont As ContabilidadPublicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      _tituloNuevo = "Nueva"
      MyBase.OnLoad(e)
      _publicos = New Publicos()

      _publicos.CargaComboCuentasBancariasClase(cmbClaseCuenta)
      _publicos.CargaComboMonedas(cmbMonedas)
      _publicos.CargaComboLocalidades(cmbLocalidad)
      _publicos.CargaComboBancos(cmbBanco)

      _liSources.Add("CuentaBancariaClase", DirectCast(_entidad, Entidades.CuentaBancaria).CuentaBancariaClase)
      _liSources.Add("Moneda", DirectCast(_entidad, Entidades.CuentaBancaria).Moneda)
      _liSources.Add("Banco", DirectCast(_entidad, Entidades.CuentaBancaria).Banco)
      _liSources.Add("Localidad", DirectCast(_entidad, Entidades.CuentaBancaria).Localidad)

      'cmbEmpresas.Initializar(IdFuncion)
      Dim rEmpresas = New Reglas.Empresas()
      cmbEmpresas.DisplayMember = "NombreEmpresa"
      cmbEmpresas.ValueMember = "IdEmpresa"
      cmbEmpresas.DataSource = rEmpresas.GetAll()

      BindearControles(_entidad, _liSources)

      _publicosCont = New ContabilidadPublicos()
      _publicosCont.CargaComboPlanes(cmbPlan, False)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         chbActivo.Checked = True
         txtCodigo.SetValor(New Reglas.CuentasBancarias().GetProximoId())
      Else
         'Como es char, el texto queda lleno aun sin datos.
         If String.IsNullOrWhiteSpace(DirectCast(_entidad, Entidades.CuentaBancaria).Cbu) Then
            txtCbu.Text = ""
         End If
      End If

      If Reglas.Publicos.TieneModuloContabilidad Then
         If bscCodCuenta.Text <> "0" Then
            bscCodCuenta.PresionarBoton()
         End If
         gpoContabilidad.Visible = True
      Else
         Height = Height - gpoContabilidad.Height     'Para evitar el espacio vacia si no tiene contabilidad.
         gpoContabilidad.Visible = False
      End If

      'Si el combo de Empresas tiene un valor el checkbox correspondiente se activa
      If cmbEmpresas.SelectedIndex >= 0 Then
         chbTitularCtaBanc.Checked = True
         cmbEmpresas.Enabled = True
      End If
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CuentasBancarias()
   End Function
   Protected Overrides Function ValidarDetalle() As String
      If Integer.Parse(txtCodigo.Text) <= 0 Then
         txtCodigo.Focus()
         Return "Debe ingresar un Código de Cuenta positivo"
      End If

      If Integer.Parse(txtBancoSucursal.Text) < 0 Then
         txtBancoSucursal.Focus()
         Return "Debe ingresar una Sucursal de Banco positiva"
      End If

      'Como es numerico si se borra un numero
      If txtCbu.Text.Trim.Length = 1 And txtCbu.Text.Trim = "0" Then
         txtCbu.Text = ""
      End If

      If txtCbu.Text.Trim.Length > 0 And txtCbu.Text.Trim.Length <> 22 Then
         txtCbu.Focus()
         Return "Debe ingresar un C.B.U. de 22 Dígitos"
      End If

      If txtCbuAlias.Text.Trim.Length > 0 And txtCbuAlias.Text.Trim.Length < 6 Then
         txtCbuAlias.Focus()
         Return "Debe ingresar un Alias que posea entre 6 y 20 Dígitos"
      End If

      If chbParaInformarEnFEC.Checked Then
         If String.IsNullOrWhiteSpace(txtCbu.Text) And String.IsNullOrWhiteSpace(txtCbuAlias.Text) Then
            txtCbu.Focus()
            Return String.Format("Si la cuenta bancaria es {0} debe cargar un {1} y/o {2}.", chbParaInformarEnFEC.Text, lblCbu.Text, lblCbuAlias.Text)
         End If
      End If

      Return String.Empty
   End Function

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
      txtCodigo.Text = "0"
      cmbBanco.SelectedIndex = -1
      cmbClaseCuenta.SelectedIndex = -1
      cmbLocalidad.SelectedIndex = -1
      cmbMonedas.SelectedIndex = -1
      txtBancoSucursal.Text = "0"
      chbActivo.Checked = True
   End Sub



   Protected Overrides Sub Aceptar()
      DirectCast(_entidad, Entidades.CuentaBancaria).idCuentaContable = bscCodCuenta.Text.ValorNumericoPorDefecto(0I)
      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      txtCodigo.Focus()
   End Sub

#Region "Buscadores"

   Private Sub bscCodCuenta_BuscadorClick() Handles bscCodCuenta.BuscadorClick
      TryCatched(
      Sub()
         _publicosCont.PreparaGrillaCuentas(bscCodCuenta)
         Dim idcta = bscCodCuenta.Text.ValorNumericoPorDefecto(0L)
         bscCodCuenta.Datos = New Reglas.ContabilidadCuentas().GetCuentasImputablesXCodigo(idcta)
      End Sub)
   End Sub
   Private Sub bscDescCuenta_BuscadorClick() Handles bscDescCuenta.BuscadorClick
      TryCatched(
      Sub()
         _publicosCont.PreparaGrillaCuentas(bscDescCuenta)
         bscDescCuenta.Datos = New Reglas.ContabilidadCuentas().GetCuentasImputablesXNombre(bscDescCuenta.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodCuenta_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodCuenta.BuscadorSeleccion, bscDescCuenta.BuscadorSeleccion
      TryCatched(
      Sub()
         If Not e.FilaDevuelta Is Nothing Then
            bscDescCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Value.ToString()
            bscCodCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()
         End If
      End Sub)
   End Sub

#End Region

   Private Sub txtCbuAlias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCbuAlias.KeyPress
      TryCatched(
      Sub()
         If (Char.IsSeparator(e.KeyChar)) Then
            e.Handled = True
         End If
      End Sub)
   End Sub

   Private Sub chbTitularCtaBanc_CheckedChanged(sender As Object, e As EventArgs) Handles chbTitularCtaBanc.CheckedChanged
      TryCatched(
      Sub()
         If chbTitularCtaBanc.Checked Then
            cmbEmpresas.Enabled = True
            cmbEmpresas.SelectedValue = actual.Sucursal.Empresa.IdEmpresa
         Else
            cmbEmpresas.Enabled = False
            cmbEmpresas.SelectedIndex = -1
            DirectCast(Me._entidad, Entidades.CuentaBancaria).IdEmpresa = Nothing
         End If
      End Sub)
   End Sub

#End Region

End Class