Public Class ucConfFichas

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      chbFichasActualizaPreciosDeVenta.Checked = Reglas.Publicos.FichasActualizaPreciosDeVenta
      chbFichasPermiteCambiarFormaDePago.Checked = Reglas.Publicos.FichasPermiteCambiarFormaDePago
      chbFichasPreguntaReemplazarComprobante.Checked = Reglas.Publicos.FichasPreguntaReemplazarComprobante
      chbFichasImprimeCobrosFormatoRecibo.Checked = Reglas.Publicos.FichasImprimeCobrosFormatoRecibo
      Select Case Reglas.Publicos.FichasSinReferenciaDeCuota
         Case Entidades.Publicos.PermitirNoPermitir.PERMITIR
            rbtFichasSinReferenciaCuota_Permitir.Checked = True
         Case Entidades.Publicos.PermitirNoPermitir.NOPERMITIR
            rbtFichasSinReferenciaCuota_NoPermitir.Checked = True
         Case Entidades.Publicos.PermitirNoPermitir.AVISARYPERMITIR
            rbtFichasSinReferenciaCuota_AvisarPermitir.Checked = True
         Case Else

      End Select

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Fichas
      ActualizarParametro(Entidades.Parametro.Parametros.FICHASACTUALIZAPRECIOSDEVENTA, chbFichasActualizaPreciosDeVenta, Nothing, chbFichasActualizaPreciosDeVenta.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FICHASPERMITECAMBIARFORMADEPAGO, chbFichasPermiteCambiarFormaDePago, Nothing, chbFichasPermiteCambiarFormaDePago.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FICHASPREGUNTAREEMPLAZARCOMPROBANTE, chbFichasPreguntaReemplazarComprobante, Nothing, chbFichasPreguntaReemplazarComprobante.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FICHASIMPRIMECOBROSFORMATORECIBO, chbFichasImprimeCobrosFormatoRecibo, Nothing, chbFichasImprimeCobrosFormatoRecibo.Text)
      Dim fichasSinReferenciaDeCuota = If(rbtFichasSinReferenciaCuota_AvisarPermitir.Checked, Entidades.Publicos.PermitirNoPermitir.AVISARYPERMITIR,
                                           If(rbtFichasSinReferenciaCuota_NoPermitir.Checked, Entidades.Publicos.PermitirNoPermitir.NOPERMITIR,
                                           Entidades.Publicos.PermitirNoPermitir.PERMITIR)).ToString()
      ActualizarParametroTexto(Entidades.Parametro.Parametros.FICHASSINREFERENCIADECUOTA, fichasSinReferenciaDeCuota, Nothing, grpFichasSinReferenciaCuota.Text)


   End Sub

End Class