Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports System.Text
Imports Eniac.Win
Imports Eniac.Reglas
Imports Eniac.Entidades
Imports System.Windows.Forms
Public Class TransferenciasEntreCuentas

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = True
   Private _blnCajasModificables As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Eniac.Win.Publicos()
         Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.LimpiarBuscadores()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub bscCuentaBancariaOrigen_BuscadorClick() Handles bscCuentaBancariaOrigen.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancariaOrigen)
         Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Me.bscCuentaBancariaOrigen.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancariaOrigen.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaOrigen_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaOrigen.BuscadorSeleccion

      Try

         If Not e.FilaDevuelta Is Nothing And Not Me.bscCuentaBancariaOrigen.FilaDevuelta Is Nothing Then

            Me.bscCuentaBancariaOrigen.Text = Me.bscCuentaBancariaOrigen.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscCuentaBancariaOrigen.Tag = New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaOrigen.FilaDevuelta.Cells("idCuentaBancaria").Value.ToString()))

            Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos
            Dim Saldo As Decimal

            Saldo = oLibroBancos.GetSaldo(actual.Sucursal.Id, Integer.Parse(Me.bscCuentaBancariaOrigen.FilaDevuelta.Cells("idCuentaBancaria").Value.ToString()), DateTime.Now, "GENERAL")
            Me.txtSaldoGeneralOrigen.Text = Saldo.ToString("##,##0.00")

            Saldo = oLibroBancos.GetSaldo(actual.Sucursal.Id, Integer.Parse(Me.bscCuentaBancariaOrigen.FilaDevuelta.Cells("idCuentaBancaria").Value.ToString()), DateTime.Now, "CONCILIADO")
            Me.txtSaldoConciliadoOrigen.Text = Saldo.ToString("##,##0.00")

            Me.bscCuentaBancariaOrigen.Enabled = False

            If ValidarCuentas() Then
               Me.bscCuentaBancariaDestino.Focus()
            End If
         End If
         HabilitaGrabar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaDestino_BuscadorClick() Handles bscCuentaBancariaDestino.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancariaDestino)
         Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Me.bscCuentaBancariaDestino.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancariaDestino.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaDestino_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaDestino.BuscadorSeleccion
      Try

         If Not e.FilaDevuelta Is Nothing And Not Me.bscCuentaBancariaDestino.FilaDevuelta Is Nothing Then

            Me.bscCuentaBancariaDestino.Text = Me.bscCuentaBancariaDestino.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscCuentaBancariaDestino.Tag = New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaDestino.FilaDevuelta.Cells("idCuentaBancaria").Value.ToString()))

            Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos
            Dim Saldo As Decimal

            Saldo = oLibroBancos.GetSaldo(actual.Sucursal.Id, Integer.Parse(Me.bscCuentaBancariaDestino.FilaDevuelta.Cells("idCuentaBancaria").Value.ToString()), DateTime.Now, "GENERAL")
            Me.txtSaldoGeneralDestino.Text = Saldo.ToString("##,##0.00")

            Saldo = oLibroBancos.GetSaldo(actual.Sucursal.Id, Integer.Parse(Me.bscCuentaBancariaDestino.FilaDevuelta.Cells("idCuentaBancaria").Value.ToString()), DateTime.Now, "CONCILIADO")
            Me.txtSaldoConciliadoDestino.Text = Saldo.ToString("##,##0.00")

            Me.bscCuentaBancariaDestino.Enabled = False

            If Me.ValidarCuentas() Then
               Me.txtImporte.Focus()
            End If
         End If

         Me.HabilitaGrabar()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try
         If Me.ValidarOperacion() Then
            Dim cuentaOrigen As Entidades.CuentaBancaria = DirectCast(bscCuentaBancariaOrigen.Tag, Entidades.CuentaBancaria)
            Dim cuentaDestino As Entidades.CuentaBancaria = DirectCast(bscCuentaBancariaDestino.Tag, Entidades.CuentaBancaria)

            Dim rLibrosBancos As Reglas.LibroBancos = New Reglas.LibroBancos()

            'Enviar a reglas
            'extracción
            Dim oReglasDepositos As Reglas.Depositos = New Reglas.Depositos()

            Dim oExtraccion As New Entidades.Deposito()

            With oExtraccion
               .CuentaBancaria = cuentaOrigen
               .CuentaBancariaDestino = cuentaDestino

               .Fecha = Me.dtpFecha.Value
               .FechaAplicado = Me.dtpFechaAplicacion.Value

               .Observacion = Me.txtObservacion.Text

               'cargo el efectivo para tenerlo discriminado
               .ImportePesos = Decimal.Parse(Me.txtImporte.Text)
               .ImporteTotal = .ImportePesos

               'cargo datos generales del comprobante
               .IdSucursal = actual.Sucursal.Id
               .IdCaja = Int32.Parse(Me.cmbCajas.SelectedValue.ToString())
               .Usuario = actual.Nombre
               .IdEstado = "NORMAL"
               .TipoComprobante = New Reglas.TiposComprobantes().GetUno("TRANSFERENCIA")
               .Observacion = txtObservacion.Text
            End With

            oReglasDepositos.Insertar(oExtraccion)

            MessageBox.Show("La transferencia se ha completado con exito.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

         Me.tsbRefrescar_Click(Me.tsbRefrescar, Nothing)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub txtImportePesos_Leave(sender As Object, e As EventArgs) Handles txtImporte.Leave
      Try
         HabilitaGrabar()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtImportePesos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporte.KeyDown, dtpFecha.KeyDown, dtpFechaAplicacion.KeyDown, cmbCajas.KeyDown
      Try
         PresionarTab(e)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Metodos"

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = Keys.F5 Then
            Me.tsbRefrescar_Click(Me.tsbRefrescar, Nothing)
            Return True
         End If
         If keyData = Keys.F4 Then
            tsbGrabar_Click(tsbGrabar, Nothing)
            Return True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

   Private Sub LimpiarBuscadores()

      Me.bscCuentaBancariaOrigen.Datos = Nothing
      Me.bscCuentaBancariaOrigen.Text = ""
      Me.bscCuentaBancariaOrigen.Tag = Nothing
      Me.txtSaldoGeneralOrigen.Text = "0.00"
      Me.txtSaldoConciliadoOrigen.Text = "0.00"

      Me.bscCuentaBancariaDestino.Datos = Nothing
      Me.bscCuentaBancariaDestino.Text = ""
      Me.bscCuentaBancariaDestino.Tag = Nothing
      Me.txtSaldoGeneralDestino.Text = "0.00"
      Me.txtSaldoConciliadoDestino.Text = "0.00"

      Me.txtImporte.Text = "0.00"
      Me.txtObservacion.Text = ""
      Me.bscCuentaBancariaDestino.Enabled = True
      Me.bscCuentaBancariaOrigen.Enabled = True

      Me.HabilitaGrabar()

      Me.dtpFecha.Value = Now
      Me.dtpFechaAplicacion.Value = Now
      Me.cmbCajas.SelectedIndex = 0
      Me.dtpFecha.Focus()

   End Sub
   Private Function ValidarOperacion() As Boolean

      If Me.bscCuentaBancariaOrigen.Tag Is Nothing Then
         MessageBox.Show("Por favor seleccione la Cuenta Origen.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
         Me.bscCuentaBancariaOrigen.Focus()
         Return False
      End If

      If Me.bscCuentaBancariaDestino.Tag Is Nothing Then
         MessageBox.Show("Por favor seleccione la Cuenta Destino.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
         Me.bscCuentaBancariaDestino.Focus()
         Return False
      End If

      If txtImporte.ValorNumericoPorDefecto(0D) > txtSaldoConciliadoOrigen.ValorNumericoPorDefecto(0D) Then
         If ShowPregunta("ATENCION: El Importe supera el Saldo Conciliado. ¿Esta Seguro de Continuar ?.") = DialogResult.No Then
            Return False
         End If
      End If

      Return True

   End Function

   Private Function ValidarCuentas() As Boolean

      If Me.bscCuentaBancariaOrigen.Tag IsNot Nothing And Me.bscCuentaBancariaDestino.Tag IsNot Nothing Then
         Dim cuentaOrigen As Entidades.CuentaBancaria = DirectCast(bscCuentaBancariaOrigen.Tag, Entidades.CuentaBancaria)
         Dim cuentaDestino As Entidades.CuentaBancaria = DirectCast(bscCuentaBancariaDestino.Tag, Entidades.CuentaBancaria)
         If cuentaOrigen.IdCuentaBancaria = cuentaDestino.IdCuentaBancaria Then
            ShowMessage("La Cuenta Origen coincide con la Cuenta Destino.")
            Me.bscCuentaBancariaDestino.Enabled = True
            Me.bscCuentaBancariaDestino.Text = ""
            Me.bscCuentaBancariaDestino.Tag = Nothing
            Me.bscCuentaBancariaDestino.Focus()
            Return False
         End If

         'validar que ambas cuentas sean de la misma moneda
         If cuentaOrigen.Moneda.IdMoneda <> cuentaDestino.Moneda.IdMoneda Then
            ShowMessage("Las Cuentas Origen y Destino deben tener la misma moneda.")
            Me.bscCuentaBancariaDestino.Enabled = True
            Me.bscCuentaBancariaDestino.Text = ""
            Me.bscCuentaBancariaDestino.Tag = Nothing
            Me.bscCuentaBancariaDestino.Focus()
            Return False
         End If
      End If

      Return True
   End Function

   Private Sub HabilitaGrabar()
      If bscCuentaBancariaOrigen.Tag IsNot Nothing AndAlso
         bscCuentaBancariaDestino.Tag IsNot Nothing AndAlso
         IsNumeric(txtImporte.Text) AndAlso Decimal.Parse(txtImporte.Text) > 0 Then
         tsbGrabar.Enabled = True
      Else
         tsbGrabar.Enabled = False
      End If
   End Sub

#End Region

End Class