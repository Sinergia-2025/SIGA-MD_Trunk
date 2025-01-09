Public Class ucConfCRMEnvioCorreo
   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboDesdeEnum(cmbConfiguracionMailCRM, GetType(Entidades.Cliente.ConfiguracionMail), , True)

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'CRM
      txtCRMAsuntoEnvioMasivoNovedadesEmail.Text = Reglas.Publicos.CRMAsuntoEnvioMasivoNovedadesEmail
      txtCRMEnvioMailNovedadesCopiaOculta.Text = Reglas.Publicos.CRMEnvioMailCopiaOculta
      cmbConfiguracionMailCRM.SelectedValue = Reglas.Publicos.ConfiguraciónMailCRM

      txtCRMAsuntoGenerarVersion.Text = Reglas.Publicos.CRMAsuntoGenerarVersion
      txtCRMGenerarVersionPara.Text = Reglas.Publicos.CRMGenerarVersionPara
      txtCRMGenerarVersionCopiaOculta.Text = Reglas.Publicos.CRMGenerarVersionCopiaOculta

   End Sub


   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'CRM
      ActualizarParametro(Entidades.Parametro.Parametros.CRMASUNTOENVIOMASIVONOVEDADESEMAIL, txtCRMAsuntoEnvioMasivoNovedadesEmail, Nothing, lblCRMAsuntoEnvioMasivoNovedadesEmail.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CRMENVIOMAILCOPIAOCULTA, txtCRMEnvioMailNovedadesCopiaOculta, Nothing, lblCRMEnvioMailCopiaOculta.Text)
      ActualizarParametro(Of Entidades.Cliente.ConfiguracionMail)(Entidades.Parametro.Parametros.CONFIGURACIONMAILCRM, cmbConfiguracionMailCRM, Nothing, cmbConfiguracionMailCRM.SelectedText)

      ActualizarParametro(Entidades.Parametro.Parametros.CRMASUNTOGENERARVERSION, txtCRMAsuntoGenerarVersion, Nothing, lblCRMAsuntoGenerarVersion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CRMGENERARVERSIONPARA, txtCRMGenerarVersionPara, Nothing, lblCRMGenerarVersionPara.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CRMGENERARVERSIONCOPIAOCULTA, txtCRMGenerarVersionCopiaOculta, Nothing, lblCRMGenerarVersionCopiaOculta.Text)


   End Sub
End Class