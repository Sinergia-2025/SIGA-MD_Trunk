Public Class ucNDConfFacturaElectronica

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Facturacion Electronica
      'chbUtilizaBonosFiscales.Checked = Reglas.Publicos.UtilizaBonosFiscalesElectronicos

      txtClaveTicketAccesoFE.Text = Reglas.Publicos.FacturaElectronica.ClaveTicketAccesoFE
      txtURLWSAA.Text = Reglas.Publicos.FacturaElectronica.URLWSAA
      txtURLWSFEX.Text = Reglas.Publicos.FacturaElectronica.URLWSFEX    '-- REQ-31198.- --
      txtURLWSFE.Text = Reglas.Publicos.FacturaElectronica.URLWSFE
      txtURLWSBFE.Text = Reglas.Publicos.FacturaElectronica.URLWSBFE
      txtAFIPURLCodigoQR.Text = Reglas.Publicos.AFIPURLCodigoQR
      txtURLWSPN4.Text = Reglas.Publicos.FacturaElectronica.URLWSPN4    '-- REQ-35914.- --
   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Facturacion Electronica
      'ActualizarParametro(Entidades.Parametro.Parametros.UTILIZABONOSFISCALESELECTRONICOS, chbUtilizaBonosFiscales, Nothing, chbUtilizaBonosFiscales.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.CLAVETICKETACCESOFE, txtClaveTicketAccesoFE, Nothing, lblClaveTicketAcceso.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.URLWSAA, txtURLWSAA, Nothing, lblURLWSAA.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.URLWSFEX, txtURLWSFEX, Nothing, lblURLWSFEX.Text)    '-- REQ-31198.- --
      ActualizarParametro(Entidades.Parametro.Parametros.URLWSFE, txtURLWSFE, Nothing, lblURLWSFE.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.URLWSBFE, txtURLWSBFE, Nothing, lblURLWSBFE.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.AFIPURLCODIGOQR, txtAFIPURLCodigoQR, Nothing, "URL Código QR")

      ActualizarParametro(Entidades.Parametro.Parametros.URLWSPN4, txtURLWSPN4, Nothing, lblURLWSPN4.Text)    '-- REQ-35914.- --


   End Sub

End Class
