Public Class ucConfCtaCteClienteGeneral2
   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Cta. Cte. CLIENTES / General 2
      chbSaldoLimiteDeCreditoContemplaPedidos.Checked = Reglas.Publicos.CtaCte.SaldoLimiteDeCreditoContemplaPedidos
      chbSaldoLimiteDeCreditoContemplaAnticipos.Checked = Reglas.Publicos.CtaCte.SaldoLimiteDeCreditoContemplaAnticipos
      txtSaldoLimiteDeCreditoDiasSumarFechaCobro.SetValor(Reglas.Publicos.CtaCte.SaldoLimiteDeCreditoDiasSumarFechaCobro)
      '-- REQ-42858.- ----------------------------------------------------------------------------------------------------
      txtPremioPorCobranza.SetValor(Reglas.Publicos.CtaCte.CantidadDeDiasPremioCobro)
      '-------------------------------------------------------------------------------------------------------------------
   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Cta. Cte. CLIENTES / General 2
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTESALDOLIMITEDECREDITOCONTEMPLAPEDIDOS, chbSaldoLimiteDeCreditoContemplaPedidos, Nothing, chbSaldoLimiteDeCreditoContemplaPedidos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTESALDOLIMITEDECREDITOCONTEMPLAANTICIPOS, chbSaldoLimiteDeCreditoContemplaAnticipos, Nothing, chbSaldoLimiteDeCreditoContemplaAnticipos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTESALDOLIMITEDECREDITODIASSUMARFECHACOBRO, txtSaldoLimiteDeCreditoDiasSumarFechaCobro, Nothing, lblSaldoLimiteDeCreditoDiasSumarFechaCobro.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTECANTIDADDIASPREMIOCOBRO, txtPremioPorCobranza, Nothing, lblPremioPorCobranza.Text)

   End Sub
End Class
