Public Class LibroBancosDetalles

   Private _publicos As Publicos
   Private _NumeroCheque As Integer = 0
   Private _IdBancoCheque As Integer = 0
   Private _IdLocalidadCheque As Integer = 0
   Private _utilizaCentroCostos As Boolean = False
   Private _permiteCambiarCentroCostosBanco As Boolean = False

#Region "Propiedades"

   Private _Operacion As Reglas.CuentasBancos.TipoOperacion
   Private _TipoDeMovimiento As Reglas.CuentasBancos.TipoMovimiento
   Private _idSucursal As Integer
   Private _NumeroMovimiento As Integer
   Private _idCuentaBancaria As Integer
   Private _idPlanCuenta As Integer?
   Private _idAsiento As Integer?
   Private _idTipoComprobante As String
   Private _numeroDeposito As Long?

   Public Property Operacion() As Reglas.CuentasBancos.TipoOperacion
      Get
         Return _Operacion
      End Get
      Set(value As Reglas.CuentasBancos.TipoOperacion)
         _Operacion = value
      End Set
   End Property
   Public Property TipoDeMovimiento() As Reglas.CuentasBancos.TipoMovimiento
      Get
         Return _TipoDeMovimiento
      End Get
      Set(value As Reglas.CuentasBancos.TipoMovimiento)
         _TipoDeMovimiento = value
      End Set
   End Property

   Public Property IdSucursal() As Integer
      Get
         Return _idSucursal
      End Get
      Set(value As Integer)
         _idSucursal = value
      End Set
   End Property

   Public Property NumeroMovimiento() As Integer
      Get
         Return _NumeroMovimiento
      End Get
      Set(value As Integer)
         _NumeroMovimiento = value
      End Set
   End Property
   Public Property IdCuentaBancaria() As Integer
      Get
         Return _idCuentaBancaria
      End Get
      Set(value As Integer)
         _idCuentaBancaria = value
      End Set
   End Property
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            If Reglas.Publicos.TieneModuloContabilidad Then
               If Reglas.ContabilidadPublicos.UtilizaCentroCostos Then
                  _utilizaCentroCostos = True
                  _publicos.CargaComboCentroCostos(cmbCentroCosto)
                  cmbCentroCosto.Visible = True
                  cmbCentroCosto.LabelAsoc.Visible = True
                  cmbCentroCosto.Enabled = Reglas.ContabilidadPublicos.PermiteCambiarCentroCostosCaja
                  _permiteCambiarCentroCostosBanco = Reglas.ContabilidadPublicos.PermiteCambiarCentroCostosBanco
               End If
            End If

            _publicos.CargaComboAFIPConceptoCM05(cmbAFIPConceptoCM05, tipo:=Nothing)

            If Me.Operacion = Reglas.CuentasBancos.TipoOperacion.Modificacion Then
               CargarMovimiento()
               Text = "Editar movimiento de banco"
            ElseIf Me.Operacion = Reglas.CuentasBancos.TipoOperacion.Nuevo Then
               Text = "Nuevo movimiento de banco"
               chkModificable.Checked = True
               chbGeneraContabilidad.Checked = True
               lblCuotas.Visible = True
               chkCuotas.Visible = True
            End If

            If Not Reglas.Publicos.AFIPUtilizaCM05 Then
               chbAFIPConceptoCM05.Checked = False
               chbAFIPConceptoCM05.Enabled = False
            End If

         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
         Sub()
            If ValidateForm() Then
               Dim oLibroBancos = New Reglas.LibroBancos()
               If Me.Operacion = Reglas.CuentasBancos.TipoOperacion.Nuevo Then
                  If Not chkCuotas.Checked Then
                     oLibroBancos.InsertarMovimiento(RecolectarDatos())

                  Else
                     Dim cuotas = txtCantidad.ValorNumericoPorDefecto(0I)
                     Dim separacion = txtSeparacion.ValorNumericoPorDefecto(0I)
                     Dim observacion = txtObservaciones.Text

                     For Cont = 1 To cuotas
                        txtObservaciones.Text = String.Format("Cuota {0}/{1}. {2}", Cont, cuotas, observacion)

                        oLibroBancos.InsertarMovimiento(RecolectarDatos())

                        If separacion > 0 Then
                           dtpFechaAplicado.Value = dtpFechaAplicado.Value.AddDays(separacion)
                        Else
                           dtpFechaAplicado.Value = dtpFechaAplicado.Value.AddMonths(1)
                        End If
                     Next
                  End If

                  MessageBox.Show("El movimiento de banco se ha ingresado correctamente.", "Movimiento de banco", MessageBoxButtons.OK, MessageBoxIcon.Information)

               ElseIf Me.Operacion = Reglas.CuentasBancos.TipoOperacion.Modificacion Then
                  oLibroBancos.ActualizarMovimiento(RecolectarDatos())

                  MessageBox.Show("El movimiento de banco se ha actualizado correctamente.", "Movimiento de banco", MessageBoxButtons.OK, MessageBoxIcon.Information)

               End If
               Close()

            End If
         End Sub)
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub bscCodigoCuenta_BuscadorClick() Handles bscCodigoCuenta.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeBancos2(bscCodigoCuenta)
            bscCodigoCuenta.Datos = New Reglas.CuentasBancos().GetTodosPorCodigo(bscCodigoCuenta.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscNombreCuenta_BuscadorClick() Handles bscNombreCuenta.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeBancos2(bscNombreCuenta)
            bscNombreCuenta.Datos = New Reglas.CuentasBancos().GetTodosPorNombre(bscNombreCuenta.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscCodigoCuenta_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCuenta.BuscadorSeleccion, bscNombreCuenta.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosCuenta(e.FilaDevuelta)
            End If
         End Sub)
   End Sub

   Private Sub txtcheque_TextChanged(sender As Object, e As EventArgs)
      TryCatched(
         Sub()
            If txtNumeroCheque.Text = String.Empty Then
               _NumeroCheque = 0
               _IdBancoCheque = 0
               _IdLocalidadCheque = 0
               txtImporte.ReadOnly = False
            End If
         End Sub)
   End Sub

   Private Sub txtImporte_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtImporte.KeyUp
      TryCatched(
         Sub()
            If e.KeyCode = Keys.Subtract Then
               txtImporte.Text = txtImporte.Text.Replace("-", String.Empty)
            End If
         End Sub)
   End Sub

   Private Sub btCancelar_Leave(sender As Object, e As EventArgs) Handles btnCancelar.Leave
      TryCatched(Sub() bscCodigoCuenta.Focus())
   End Sub

   Private Sub dtpFechaMovimiento_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaMovimiento.ValueChanged
      TryCatched(
         Sub()
            If Not lblFechaAplicado.Visible Then
               dtpFechaAplicado.Value = dtpFechaMovimiento.Value
            End If
         End Sub)
   End Sub

   Private Sub chkCuotas_CheckedChanged(sender As Object, e As EventArgs) Handles chkCuotas.CheckedChanged
      TryCatched(
         Sub()
            'Privilegio si marco Posdatados
            If Not chkPosdatado.Checked Then
               lblFechaAplicado.Visible = chkCuotas.Checked
               dtpFechaAplicado.Visible = chkCuotas.Checked
            End If

            lblCantidad.Visible = chkCuotas.Checked
            txtCantidad.Visible = chkCuotas.Checked
            lblSeparacion.Visible = chkCuotas.Checked
            txtSeparacion.Visible = chkCuotas.Checked
         End Sub)
   End Sub

   Private Sub chkPosdatado_CheckedChanged(sender As Object, e As EventArgs) Handles chkPosdatado.CheckedChanged
      TryCatched(
         Sub()
            'Privilegio si marco Cuotas
            If Not chkCuotas.Checked Then
               lblFechaAplicado.Visible = chkPosdatado.Checked
               dtpFechaAplicado.Visible = chkPosdatado.Checked
            End If

            If chkPosdatado.Checked And dtpFechaAplicado.Visible Then
               dtpFechaAplicado.Focus()
            End If
         End Sub)
   End Sub
   Private Sub chbAFIPConceptoCM05_CheckedChanged(sender As Object, e As EventArgs) Handles chbAFIPConceptoCM05.CheckedChanged
      TryCatched(
         Sub()
            If Not chbAFIPConceptoCM05.Checked Then
               cmbAFIPConceptoCM05.SelectedIndex = -1
            End If

            cmbAFIPConceptoCM05.Enabled = chbAFIPConceptoCM05.Checked

            If chbAFIPConceptoCM05.Checked Then
               cmbAFIPConceptoCM05.Select()
            End If
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Function ValidateForm() As Boolean

      If bscCodigoCuenta.Text = String.Empty Then

         MessageBox.Show("Por favor seleccione una cuenta", "Cuenta Bancaria", MessageBoxButtons.OK, MessageBoxIcon.Stop)
         bscCodigoCuenta.Focus()
         bscCodigoCuenta.Select()

         Return False

      ElseIf Not Me.optIngreso.Checked And Not Me.optEgreso.Checked Then

         MessageBox.Show("Por favor indique el tipo de movimiento", "Tipo de Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Stop)
         Return False

      ElseIf Replace(Me.txtImporte.Text, "0.00", String.Empty) = String.Empty Then

         MessageBox.Show("Por favor ingrese un importe", "Cuenta Bancaria", MessageBoxButtons.OK, MessageBoxIcon.Stop)
         Me.txtImporte.Focus()
         Me.txtImporte.Select()

         Return False

         'Por ahora dejo cargar movimientos para atras.
         'ElseIf Me.dtpFechaAplicado.Value.ToString("yyyyMMdd") <= Me.dtpFechaMovimiento.Value.ToString("yyyyMMdd") And Me.dtpFechaAplicado.Visible Then

         '   MessageBox.Show("Por favor ingrese una Fecha de Aplicado válida", "Fecha Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
         '   Me.dtpFechaAplicado.Focus()

         '   Return False

      ElseIf Me.chkCuotas.Checked And Integer.Parse(Me.txtCantidad.Text) <= 0 Then

         MessageBox.Show("Por favor ingrese una Cantidad válida", "Cuotas", MessageBoxButtons.OK, MessageBoxIcon.Stop)
         Return False

      ElseIf Me.chkCuotas.Checked And Integer.Parse(Me.txtSeparacion.Text) < 0 Then

         MessageBox.Show("Por favor ingrese una Separación válida", "Cuotas", MessageBoxButtons.OK, MessageBoxIcon.Stop)
         Return False

      ElseIf Me.chkCuotas.Checked And txtNumeroCheque.Text.Trim.Length > 0 Then

         MessageBox.Show("No puede ingresar en cuotas asignando un cheque", "Cuotas", MessageBoxButtons.OK, MessageBoxIcon.Stop)
         Return False

      ElseIf chbAFIPConceptoCM05.Checked And cmbAFIPConceptoCM05.SelectedIndex = -1 Then
         cmbAFIPConceptoCM05.Select()
         ShowMessage("ATENCION: Activo el Concepto de CM05 pero no seleccionó uno. Debe elegir una.")
         Return False

      End If

      Return True

   End Function

   Private Function RecolectarDatos() As Entidades.LibroBanco

      Dim entLibroBanco As Entidades.LibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)

      entLibroBanco.IdCuentaBancaria = Me.IdCuentaBancaria
      entLibroBanco.IdCuentaBanco = Integer.Parse(Me.bscCodigoCuenta.Text)

      If Me.Operacion = Reglas.CuentasBancos.TipoOperacion.Modificacion Then
         entLibroBanco.NumeroMovimiento = Me.NumeroMovimiento
      End If

      If Me.optIngreso.Checked Then
         entLibroBanco.IdTipoMovimiento = "I"
      Else
         entLibroBanco.IdTipoMovimiento = "E"
      End If

      entLibroBanco.Importe = Decimal.Parse(Me.txtImporte.Text)
      entLibroBanco.FechaMovimiento = Me.dtpFechaMovimiento.Value

      If Me.txtNumeroCheque.Text <> String.Empty Then
         If Integer.Parse(Me.txtNumeroCheque.Text) > 0 Then
            entLibroBanco.IdCheque = New Reglas.Cheques().GetIdByNumeroDeCheque(actual.Sucursal.Id, _NumeroCheque, _IdBancoCheque, Integer.Parse(Me.txtBancoSucursal.Text), _IdLocalidadCheque)
         End If
      End If


      entLibroBanco.FechaAplicado = Me.dtpFechaAplicado.Value
      entLibroBanco.Observacion = Me.txtObservaciones.Text

      entLibroBanco.Conciliado = Me.chkConciliado.Checked

      entLibroBanco.EsModificable = chkModificable.Checked
      entLibroBanco.GeneraContabilidad = chbGeneraContabilidad.Checked
      entLibroBanco.IdPlanCuenta = _idPlanCuenta
      entLibroBanco.IdAsiento = _idAsiento

      If _utilizaCentroCostos Then
         entLibroBanco.CentroCosto = DirectCast(cmbCentroCosto.SelectedItem, Entidades.ContabilidadCentroCosto)
      End If

      '# Tipo de Comprobante
      entLibroBanco.IdTipoComprobante = _idTipoComprobante
      entLibroBanco.NumeroDeposito = If(_numeroDeposito.HasValue, _numeroDeposito.Value, Nothing)

      entLibroBanco.IdConceptoCM05 = cmbAFIPConceptoCM05.ValorSeleccionado(Of Integer?)(chbAFIPConceptoCM05, Nothing)

      Return entLibroBanco

   End Function

   Private Sub CargarMovimiento()

      Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos()
      Dim eLibroBanco As Entidades.LibroBanco = oLibroBancos.GetUno(Me.IdSucursal, Me.IdCuentaBancaria, Me.NumeroMovimiento)

      Me.bscCodigoCuenta.Text = eLibroBanco.IdCuentaBanco.ToString()
      Me.bscCodigoCuenta.PresionarBoton()

      If eLibroBanco.IdTipoMovimiento = "I" Then
         Me.optIngreso.Checked = True
      Else
         Me.optEgreso.Checked = True
      End If

      Me.txtImporte.Text = Math.Abs(eLibroBanco.Importe).ToString()

      Me.dtpFechaMovimiento.Value = eLibroBanco.FechaMovimiento

      If eLibroBanco.IdConceptoCM05.HasValue Then
         chbAFIPConceptoCM05.Checked = True
         cmbAFIPConceptoCM05.SelectedValue = eLibroBanco.IdConceptoCM05.Value
      Else
         chbAFIPConceptoCM05.Checked = False
      End If

      '# Cheque
      Dim eCheque As Entidades.Cheque = Nothing
      If eLibroBanco.IdCheque.HasValue Then eCheque = New Reglas.Cheques().GetUno(eLibroBanco.IdCheque.Value)

      If eCheque IsNot Nothing Then
         Me.txtNumeroCheque.Text = eCheque.NumeroCheque.ToString()
         Me._NumeroCheque = eCheque.NumeroCheque
      End If

      If Me._NumeroCheque > 0 Then

         Dim oLoca = New Reglas.Localidades()
         Me._IdLocalidadCheque = eCheque.Localidad.IdLocalidad
         Me.txtNombreLocalidad.Text = oLoca.GetUna(Me._IdLocalidadCheque).NombreLocalidad

         Dim oBancos As Reglas.Bancos = New Reglas.Bancos()
         Me._IdBancoCheque = eCheque.IdBanco
         Me.txtNombreBanco.Text = oBancos.GetUno(Me._IdBancoCheque).NombreBanco

         Me.txtBancoSucursal.Text = eCheque.IdBancoSucursal.ToString()

         'Si tiene Cheque, no puede cambiar ciertos Datos.
         Me.bscCodigoCuenta.Enabled = False
         Me.bscNombreCuenta.Enabled = False
         Me.optIngreso.Enabled = False
         Me.optEgreso.Enabled = False
         Me.dtpFechaMovimiento.Enabled = False
         Me.txtImporte.ReadOnly = True

      End If

      Me.dtpFechaAplicado.Value = eLibroBanco.FechaAplicado

      If Me.dtpFechaAplicado.Value.ToString("yyyyMMdd") > Me.dtpFechaMovimiento.Value.ToString("yyyyMMdd") Then
         Me.chkPosdatado.Checked = True
      End If

      Me.txtObservaciones.Text = eLibroBanco.Observacion

      If _utilizaCentroCostos Then
         If Not IsNothing(eLibroBanco.IdCentroCosto) Then
            Me.cmbCentroCosto.SelectedValue = eLibroBanco.IdCentroCosto
         End If
         Me.cmbCentroCosto.Enabled = Me._permiteCambiarCentroCostosBanco
      End If

      Me.chkConciliado.Checked = eLibroBanco.Conciliado

      'GAR: 07/01/2016 - Hay que Analizar la funcionalidad de PideCheque, nadio lo setea y las cuentas pueden utilizarse con cheques.
      'Dim oCuentaBanco As Reglas.CuentasBancos = New Reglas.CuentasBancos()
      'Dim eCuentaBanco As Entidades.CuentaBanco = oCuentaBanco.GetCuentaBancos(Integer.Parse(Me.bscCodigoCuenta.Text))

      'Me.txtNumeroCheque.Enabled = eCuentaBanco.PideCheque
      'Me.bscCheques.Enabled = eCuentaBanco.PideCheque

      'If Not Me.txtNumeroCheque.Enabled Then
      '   Me.txtNumeroCheque.Text = ""
      'End If
      '------------------------------------

      Me.lblFechaAplicado.Visible = (Me.dtpFechaMovimiento.Value <> Me.dtpFechaAplicado.Value)
      Me.dtpFechaAplicado.Visible = (Me.dtpFechaMovimiento.Value <> Me.dtpFechaAplicado.Value)

      If Not eLibroBanco.EsModificable Then
         'bscCodigoCuenta.Enabled = False
         'bscNombreCuenta.Enabled = False
         optIngreso.Enabled = False
         optEgreso.Enabled = False
         txtImporte.Enabled = False
         If eLibroBanco.IdAsiento > 0 Then
            dtpFechaMovimiento.Enabled = False
            chkPosdatado.Enabled = False
         End If
         bscCheques.Enabled = False
         txtObservaciones.Enabled = False
         cmbAFIPConceptoCM05.Enabled = False
         chbAFIPConceptoCM05.Enabled = False
         chkCuotas.Enabled = False
         txtCantidad.Enabled = False
         txtSeparacion.Enabled = False
      End If

      chkModificable.Checked = eLibroBanco.EsModificable
      chbGeneraContabilidad.Checked = eLibroBanco.GeneraContabilidad

      _idPlanCuenta = eLibroBanco.IdPlanCuenta
      _idAsiento = eLibroBanco.IdAsiento

      '# Tipo de Comprobante y Nro de Depósito
      _idTipoComprobante = If(Not String.IsNullOrEmpty(eLibroBanco.IdTipoComprobante), eLibroBanco.IdTipoComprobante, Nothing)
      _numeroDeposito = If(eLibroBanco.NumeroDeposito.HasValue, eLibroBanco.NumeroDeposito.Value, Nothing)

   End Sub

   Private Sub CargarDatosCuenta(dr As DataGridViewRow)

      If dr.Cells("IdTipoCuenta").Value.ToString().StartsWith("I") Then ' = "Ingreso" Then
         Me.optIngreso.Checked = True
      Else
         Me.optEgreso.Checked = True
      End If

      Me.bscCodigoCuenta.Text = dr.Cells("idCuentaBanco").Value.ToString()
      Me.bscNombreCuenta.Text = dr.Cells("NombreCuentaBanco").Value.ToString()

      If _utilizaCentroCostos Then
         cmbCentroCosto.SelectedValue = dr.Cells(Entidades.CuentaBanco.Columnas.IdCentroCosto.ToString()).Value
         cmbCentroCosto.Enabled = _permiteCambiarCentroCostosBanco
      End If

      Me.txtNumeroCheque.Enabled = (dr.Cells("Pidecheque").Value.ToString().ToUpper = "SI")
      Me.bscCheques.Enabled = (dr.Cells("Pidecheque").Value.ToString().ToUpper = "SI")

      If Not Me.txtNumeroCheque.Enabled Then
         Me.txtNumeroCheque.Text = ""
      End If

      Me.lblFechaAplicado.Visible = (dr.Cells("EsPosdatado").Value.ToString().ToUpper = "SI")
      Me.dtpFechaAplicado.Visible = (dr.Cells("EsPosdatado").Value.ToString().ToUpper = "SI")

      If _utilizaCentroCostos And Me.cmbCentroCosto.Enabled Then
         Me.cmbCentroCosto.Focus()
      Else
         Me.txtImporte.Focus()
      End If

      Dim idConceptoCM05 As Integer? = Nothing
      Dim idConceptoCM05Dr As String = dr.Cells(Entidades.CuentaBanco.Columnas.IdConceptoCM05.ToString()).Value.ToString()
      If IsNumeric(idConceptoCM05Dr) Then
         idConceptoCM05 = Integer.Parse(idConceptoCM05Dr)
      End If
      If idConceptoCM05.HasValue Then
         chbAFIPConceptoCM05.Checked = True
         cmbAFIPConceptoCM05.SelectedValue = idConceptoCM05.Value
      Else
         chbAFIPConceptoCM05.Checked = False
      End If

      'Me.CargarProximoNumero()

   End Sub

#End Region

End Class