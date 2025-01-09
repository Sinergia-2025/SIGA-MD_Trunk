Public Class ucNDConfCtaCteCliente
   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Cta. Cte. CLIENTES
      chbCtaCtePermitirModificarComprobanteAsociado.Checked = Reglas.Publicos.CtaCte.CtaCtePermitirModificarComprobanteAsociado

      '-- REQ-43822.- ------------------------------------------------------------------------------------------------------------
      chbCobranzaElectronicaHabilitaRoela.Checked = Reglas.Publicos.CtaCte.CobranzaElectronicaHabilitaRoela
      chbCobranzaElectronicaHabilitaSirPlus.Checked = Reglas.Publicos.CtaCte.CobranzaElectronicaHabilitaSirPlus
      chbCobranzaElectronicaHabilitaDebitoAutomatico.Checked = Reglas.Publicos.CtaCte.CobranzaElectronicaHabilitaDebitoAutomatico
      '---------------------------------------------------------------------------------------------------------------------------
   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Cta. Cte. CLIENTES
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTEPERMITIRMODIFICARCOMPROBANTEASOCIADO, chbCtaCtePermitirModificarComprobanteAsociado, Nothing, chbCtaCtePermitirModificarComprobanteAsociado.Text)

      '-- REQ-43822.- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTECOBRANZAELECTRONICAHABILITAROELA, chbCobranzaElectronicaHabilitaRoela, Nothing, chbCobranzaElectronicaHabilitaRoela.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTECOBRANZAELECTRONICAHABILITASIRPLUS, chbCobranzaElectronicaHabilitaSirPlus, Nothing, chbCobranzaElectronicaHabilitaSirPlus.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTECOBRANZAELECTRONICAHABILITADEBITOAUTOMATICO, chbCobranzaElectronicaHabilitaDebitoAutomatico, Nothing, chbCobranzaElectronicaHabilitaDebitoAutomatico.Text)
      '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
   End Sub

End Class