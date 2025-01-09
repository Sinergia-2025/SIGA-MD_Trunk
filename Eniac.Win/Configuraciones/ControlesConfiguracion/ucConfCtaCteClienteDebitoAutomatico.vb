Public Class ucConfCtaCteClienteDebitoAutomatico

   Private _publicos As Publicos

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboCajas(cmbCajas, actual.Sucursal.IdSucursal,
                                 MiraUsuario:=False, MiraPC:=Not Reglas.Publicos.CtaCteProv.PagoIgnorarPCdeCaja,
                                 CajasModificables:=False)
      e.Publicos.CargaComboTiposComprobantesRecibo(cmbTipoRecibo, miraPC:=True, tipo1:="CTACTECLIE", esReciboClienteVinculado:=Nothing)
      e.Publicos.CargaComboEmpleados(cmbCobradores, Entidades.Publicos.TiposEmpleados.COBRADOR)
      e.Publicos.CargaComboDesdeEnum(cmbFormatoPMC, GetType(Entidades.CuentaCorriente.FormatoPMC))

      '-- REQ-43823.- -----------------------------------------------------------------------------
      e.Publicos.CargaComboIntereses(cmbInteresesVencRoela)
      e.Publicos.CargaComboTiposComprobantes(cmbTiposComprobantesSIRPLUS, MiraPC:=False, "VENTAS", UsaFacturacion:=True, Clase:="FICHAS")
      '--
      grbRoela.Enabled = Reglas.Publicos.CtaCte.CobranzaElectronicaHabilitaRoela
      grbSirPlus.Enabled = Reglas.Publicos.CtaCte.CobranzaElectronicaHabilitaSirPlus
      '--
      grbBancoMacro.Enabled = Reglas.Publicos.CtaCte.CobranzaElectronicaHabilitaDebitoAutomatico
      grbSantander.Enabled = Reglas.Publicos.CtaCte.CobranzaElectronicaHabilitaDebitoAutomatico
      grbCuenta.Enabled = Reglas.Publicos.CtaCte.CobranzaElectronicaHabilitaDebitoAutomatico
      grbPagoMisCuentas.Enabled = Reglas.Publicos.CtaCte.CobranzaElectronicaHabilitaDebitoAutomatico
      '--------------------------------------------------------------------------------------------
      _publicos = e.Publicos

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      cmbCtaCteCliMacroAlineacion.Text = Reglas.Publicos.CtaCte.MacroFormatoAlineacionAdherente
      txtCaracterRellenado.Text = Reglas.Publicos.CtaCte.MacroCaracterRelleanoAdherente

      txtDebitoAutomaticoSantanderCodigoServicio.Text = Reglas.Publicos.CtaCte.DebitoAutomaticoSantanderCodigoServicio

      If Reglas.Publicos.CtaCte.DebitoAutomaticoCuentaBancariaTransfBanc > 0 Then
         bscCodigoCuentaBancariaTransfBanc.Text = Reglas.Publicos.CtaCte.DebitoAutomaticoCuentaBancariaTransfBanc.ToString()
         bscCodigoCuentaBancariaTransfBanc.Visible = True
         bscCodigoCuentaBancariaTransfBanc.PresionarBoton()
         bscCodigoCuentaBancariaTransfBanc.Visible = False
      End If

      If IsNumeric(Reglas.Publicos.CtaCte.DebitoAutomaticoCajaCtaBancariaTransfBanc) Then
         cmbCajas.SelectedValue = Reglas.Publicos.CtaCte.DebitoAutomaticoCajaCtaBancariaTransfBanc
      End If
      cmbTipoRecibo.SelectedValue = Reglas.Publicos.CtaCte.DebitoAutomaticoTipoReciboCtaBancariaTransf
      cmbCobradores.SelectedValue = Reglas.Publicos.CtaCte.DebitoAutomaticoCobradorCtaBancariaTransf

      txtNumeroEmpresaBanelco.Text = Reglas.Publicos.CtaCte.NumeroEmpresaBanelco.ToString()
      cmbFormatoPMC.SelectedValue = Reglas.Publicos.CtaCte.PMCFormato

      '-- REQ-43823.- -----------------------------------------------------------------------------
      txtRoelaIdentificadorConcepto.Text = Reglas.Publicos.TurismoRoelaIdentificadorConcepto.ToString()
      txtRoelaIdentificadorCuenta.Text = Reglas.Publicos.TurismoRoelaIdentificadorCuenta.ToString()

      If cmbInteresesVencRoela.Items.Count > 0 Then
         cmbInteresesVencRoela.SelectedValue = Reglas.Publicos.TurismoRoelaInteresesVencimiento
      End If

      txtRazonSocial.Text = Reglas.Publicos.TurismoSIRPLUSRazonSocial.ToString()
      txtIdentCuenta.Text = Reglas.Publicos.TurismoSIRPLUSIdentifCuenta.ToString()
      txtPassword.Text = Reglas.Publicos.TurismoSIRPLUSPassword.ToString()
      txtNroEmpresa.Text = Reglas.Publicos.TurismoSIRPLUSNroCuentaEmpresa.ToString()
      txtCBU.Text = Reglas.Publicos.TurismoSIRPLUSCBU.ToString()
      txtTitularCBU.Text = Reglas.Publicos.TurismoSIRPLUSCBUEmpresa.ToString()
      cmbTiposComprobantesSIRPLUS.SelectedValue = Reglas.Publicos.TurismoSIRPLUSTiposComprobantes
      '--------------------------------------------------------------------------------------------
   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.MACROADHERENTEALINEACION, cmbCtaCteCliMacroAlineacion, Nothing, lblAlineacionIDAdherente.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MACROADHERENTERELLENADO, txtCaracterRellenado, Nothing, lblCaracterRellenado.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.DEBITOAUTOMATICOSANTANDERCODIGOSERVICIO, txtDebitoAutomaticoSantanderCodigoServicio, Nothing, lblDebitoAutomaticoSantanderCodigoServicio.Text)

      If IsNumeric(bscCodigoCuentaBancariaTransfBanc.Text) Then
         ActualizarParametroTexto(Entidades.Parametro.Parametros.DEBITOAUTOMATICOCUENTABANCARIATRANSBANC, bscCodigoCuentaBancariaTransfBanc.Text, Nothing, lblCuentaBancaria.Text)
      End If

      If cmbCajas.SelectedValue IsNot Nothing Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.DEBITOAUTOMATICOCAJACUENTABANCARIATRANSBANC, cmbCajas, Nothing, lblCaja.Text)
      End If
      If cmbTipoRecibo.SelectedValue IsNot Nothing Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.DEBITOAUTOMATICOTIPORECIBOCTABANCARIATRANF, cmbTipoRecibo, Nothing, lblTipoRecibo.Text)
      End If
      If cmbCobradores.SelectedValue IsNot Nothing Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.DEBITOAUTOMATICOCOBRADORCTABANCARIATRANF, cmbCobradores, Nothing, lblCobradores.Text)
      End If

      ActualizarParametro(Entidades.Parametro.Parametros.NROEMPRESABANELCO, txtNumeroEmpresaBanelco, Nothing, lblNumeroEmpresaBanelco.Text)
      ActualizarParametro(Of Entidades.CuentaCorriente.FormatoPMC)(Entidades.Parametro.Parametros.PMCFORMATO, cmbFormatoPMC, Nothing, lblFormato.Text)

      '-- REQ-43823.- -----------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.TURISMOROELAIDCONCEPTO, txtRoelaIdentificadorConcepto, Nothing, lblIdentificadorConcepto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TURISMOROELAIDCUENTA, txtRoelaIdentificadorCuenta, Nothing, lblIdentificadorCuenta.Text)
      If cmbInteresesVencRoela.SelectedIndex <> -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.TURISMOROELAINTERESVTO, cmbInteresesVencRoela, Nothing, cmbInteresesVencRoela.LabelAsoc.Text)
      End If

      ActualizarParametro(Entidades.Parametro.Parametros.TURISMOSIRPLUSCBU, txtCBU, Nothing, lblCBU.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TURISMOSIRPLUSCBUEMPRESA, txtTitularCBU, Nothing, lblTitularCBU.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TURISMOSIRPLUSCUENTAEMPRESA, txtNroEmpresa, Nothing, lblNroCta.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TURISMOSIRPLUSIDCUENTA, txtIdentCuenta, Nothing, lblIdentificadorCuenta.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TURISMOSIRPLUSNOMBREEMPRESA, txtRazonSocial, Nothing, lblRazonSocial.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TURISMOSIRPLUSPASS, txtPassword, Nothing, lblPassword.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.TURISMOSIRPLUSTIPOSCOMPROBANTES, cmbTiposComprobantesSIRPLUS, Nothing, lblTiposComprobantesSIRPLUS.Text)
      '--------------------------------------------------------------------------------------------
   End Sub


   Private Sub bscCuentaBancariaTransfBanc_BuscadorClick() Handles bscCuentaBancariaTransfBanc.BuscadorClick
      FindForm().TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias(bscCuentaBancariaTransfBanc)
            bscCuentaBancariaTransfBanc.Datos = New Reglas.CuentasBancarias().GetFiltradoPorNombre(bscCuentaBancariaTransfBanc.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoCuentaBancariaTransfBanc_BuscadorClick() Handles bscCodigoCuentaBancariaTransfBanc.BuscadorClick
      FindForm().TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias(bscCodigoCuentaBancariaTransfBanc)
            Dim id = bscCodigoCuentaBancariaTransfBanc.Text.ValorNumericoPorDefecto(0I)
            bscCodigoCuentaBancariaTransfBanc.Datos = New Reglas.CuentasBancarias().GetFiltradoPorCodigo(id)
         End Sub)
   End Sub

   Private Sub bscCuentaBancariaTransfBanc_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancariaTransfBanc.BuscadorSeleccion, bscCodigoCuentaBancariaTransfBanc.BuscadorSeleccion
      FindForm().TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               bscCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
               bscCodigoCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
               cmbCajas.Focus()
            End If
         End Sub)
   End Sub

   Private Sub txtCBU_Leave(sender As Object, e As EventArgs) Handles txtCBU.Leave
      Try
         If txtCBU.Text.ToString.Length <> 22 And txtCBU.Text <> String.Empty Then
            MessageBox.Show("No es un CBU válido")
            txtCBU.Focus()
         End If
      Catch ex As Exception

      End Try
   End Sub

End Class