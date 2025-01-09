Public Class ucNDConfVentas

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Ventas
      txtIdentifFacturaFiscal.Text = Reglas.Publicos.IdTicketFacturaFiscal
      txtIdentifTicketFiscal.Text = Reglas.Publicos.IdTicketFiscal

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Ventas
      ActualizarParametro(Entidades.Parametro.Parametros.IDTICKETFACTURAFISCAL, txtIdentifFacturaFiscal, Nothing, lblIdentifFacturaFiscal.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.IDTICKETFISCAL, txtIdentifTicketFiscal, Nothing, lblIdentifTicketFiscal.Text)

   End Sub

End Class