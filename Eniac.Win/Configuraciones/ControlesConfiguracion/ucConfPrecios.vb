Public Class ucConfPrecios

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboListaDePrecios2(cmbListaDePreciosPredeterminada)
      e.Publicos.CargaComboMonedas(cmbMonedaParaConsultarPrecios)

      Dim dt = DirectCast(cmbMonedaParaConsultarPrecios.DataSource, DataTable)
      dt.Rows.InsertAt(DirectCast(cmbMonedaParaConsultarPrecios.DataSource, DataTable).NewRow, 0)
      dt.Rows(0)("IdMoneda") = -1
      dt.Rows(0)("NombreMoneda") = "del producto"
      cmbMonedaParaConsultarPrecios.SelectedIndex = 0

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Precios
      chbConsultarPreciosConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA
      '-.PE-31632.-
      chbMuestraFechaActualiza.Checked = Reglas.Publicos.MuestraFechaDeActualizacion
      txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("N2")
      chbUtilizaPrecioDeCompra.Checked = Reglas.Publicos.UtilizaPrecioDeCompra
      chbConsultarPreciosConEmbalaje.Checked = Reglas.Publicos.ConsultarPreciosConEmbalaje
      chbConsultarPreciosProdNoAfectanStock.Checked = Reglas.Publicos.ConsultarPreciosOcultarProdNoAfectanStock

      Select Case Reglas.Publicos.ActualizaPreciosCalculo
         Case rbtPorcActual.Tag.ToString()
            rbtPorcActual.Checked = True
         Case rbtSobreVenta.Tag.ToString()
            rbtSobreVenta.Checked = True
         Case rbtSobreCosto.Tag.ToString()
            rbtSobreCosto.Checked = True
         Case rbtDesdeFormula.Tag.ToString()
            rbtDesdeFormula.Checked = True
      End Select

      chbActualizarPreciosMostrarCodigoProductoProveedor.Checked = Reglas.Publicos.ActualizarPreciosMostrarCodigoProductoProveedor
      chbMarcarTodos.Checked = Reglas.Publicos.ActualizarPreciosMostrarTodos
      cmbListaDePreciosPredeterminada.SelectedValue = Reglas.Publicos.ListaPreciosPredeterminada

      If Reglas.Publicos.PreciosPriorizaCodigoYDescripcion Then
         radCodigoYDescripcion.Checked = True
      Else
         radCodigoODescripcion.Checked = True
      End If

      Dim ModificarPrecioPorDebajoPL = Reglas.Publicos.Facturacion.ModificarPrecioPorDebajoPrecioLista
      Select Case ModificarPrecioPorDebajoPL
         Case rbtPrecioPorDebajoPermitir.Tag.ToString()        '  "PERMITIR"
            rbtPrecioPorDebajoPermitir.Checked = True
         Case rbtPrecioPorDebajoNoPermitir.Tag.ToString()      '  "NOPERMITIR"
            rbtPrecioPorDebajoNoPermitir.Checked = True
         Case Else                                             '  "AVISARYPERMITIR"
            rbtPrecioPorDebajoAvisaryPermitir.Checked = True
      End Select
      txtPorcentajePrecioPorDebajoPL.Text = Reglas.Publicos.Facturacion.PorcentajePermitidoPorDebajoPrecioLista.ToString("N2")


      'Columna 2
      chbPreciosUnificarEntreSucursales.Checked = Reglas.Publicos.PreciosUnificar
      txtCantidadDecimalesEnVenta.Text = Reglas.Publicos.PreciosDecimalesEnVenta.ToString()

      'FTP
      txtFTPServidor.Text = Reglas.Publicos.FTPServidor
      txtFTPUsuario.Text = Reglas.Publicos.FTPUsuario
      txtFTPPassword.Text = Reglas.Publicos.FTPPassword
      chbFTPConexionPasiva.Checked = Reglas.Publicos.FTPConexionPasiva
      txtFTPNombreArchivo.Text = Reglas.Publicos.FTPNombreArchivo
      cmbFTPFormato.Text = Reglas.Publicos.FTPFormato
      txtFTPCarpetaRemota.Text = Reglas.Publicos.FTPCarpetaRemota
      chbFTPUtilizaCarpetaSecundaria.Checked = Reglas.Publicos.FTPCarpetaSecundaria


      chbActualizaPrecioCostoPorTipoDeCambio.Checked = Reglas.Publicos.ActualizaPrecioCostoPorTipoCambio
      cmbMonedaParaConsultarPrecios.SelectedValue = Reglas.Publicos.MonedaParaConsultarPrecios

      Dim ModificarPrecioPorArribaPL = Reglas.Publicos.Facturacion.ModificarPrecioPorArribaPrecioLista
      Select Case ModificarPrecioPorArribaPL
         Case rbtPrecioPorArribaPermitir.Tag.ToString()        ' "PERMITIR"
            rbtPrecioPorArribaPermitir.Checked = True
         Case rbtPrecioPorArribaNoPermitir.Tag.ToString()      ' "NOPERMITIR"
            rbtPrecioPorArribaNoPermitir.Checked = True
         Case Else                                             ' "AVISARYPERMITIR"
            rbtPrecioPorArribaAvisaryPermitir.Checked = True
      End Select
      txtPorcentajePrecioPorArribaPL.Text = Reglas.Publicos.Facturacion.PorcentajePermitidoPorArribaPrecioLista.ToString("N2")


   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Precios
      ActualizarParametro(Entidades.Parametro.Parametros.CONSULTARPRECIOSCONIVA, chbConsultarPreciosConIVA, Nothing, chbConsultarPreciosConIVA.Text)
      '-.PE-31632.-
      ActualizarParametro(Entidades.Parametro.Parametros.MUESTRAFECHAACTUALIZA, chbMuestraFechaActualiza, Nothing, chbMuestraFechaActualiza.Text)
      Dim rMonedas = New Reglas.Monedas()
      rMonedas.ActualizarCotizacion(Entidades.Moneda.Dolar, txtCotizacionDolar.ValorNumericoPorDefecto(1D))
      ActualizarParametro(Entidades.Parametro.Parametros.UTILIZAPRECIODECOMPRA, chbUtilizaPrecioDeCompra, Nothing, chbUtilizaPrecioDeCompra.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CONSULTARPRECIOSCONEMBALAJE, chbConsultarPreciosConEmbalaje, Nothing, chbConsultarPreciosConEmbalaje.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CONSULTPRECOCULTARPRODNOAFECTSTOCK, chbConsultarPreciosProdNoAfectanStock, Nothing, chbConsultarPreciosProdNoAfectanStock.Text)

      Dim valor = If(rbtPorcActual.Checked, rbtPorcActual.Tag.ToString(),
                  If(rbtSobreVenta.Checked, rbtSobreVenta.Tag.ToString(),
                  If(rbtSobreCosto.Checked, rbtSobreCosto.Tag.ToString(),
                  If(rbtDesdeFormula.Checked, rbtDesdeFormula.Tag.ToString(),
                  rbtSobreVenta.Tag.ToString()))))
      ActualizarParametroTexto(Entidades.Parametro.Parametros.ACTUALIZARPRECIOSCALCULO, valor, Nothing, grbActualizarPreciosCalculo.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.ACTUALIZARPRECIOSMOSTRARCODIGOPRODUCTOPROVEEDOR, chbActualizarPreciosMostrarCodigoProductoProveedor, Nothing, chbActualizarPreciosMostrarCodigoProductoProveedor.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ACTUALIZARPRECIOSMARCARTODOS, chbMarcarTodos, Nothing, chbMarcarTodos.Text)
      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.LISTAPRECIOSPREDETERMINADA, cmbListaDePreciosPredeterminada, Nothing, lblListaDePreciosPredeterminada.Text)
      ActualizarParametroTexto(Entidades.Parametro.Parametros.PRECIOSPRIORIZACODIGOYDESCRIPCION, radCodigoYDescripcion.Checked.ToString(), Nothing, grpPreciosPriorizaCodigoYDescripcion.Text)

      valor = If(rbtPrecioPorDebajoPermitir.Checked, rbtPrecioPorDebajoPermitir.Tag.ToString(),
              If(rbtPrecioPorDebajoNoPermitir.Checked, rbtPrecioPorDebajoNoPermitir.Tag.ToString(),
              If(rbtPrecioPorDebajoAvisaryPermitir.Checked, rbtPrecioPorDebajoAvisaryPermitir.Tag.ToString(),
              rbtPrecioPorDebajoPermitir.Tag.ToString())))
      ActualizarParametroTexto(Entidades.Parametro.Parametros.MODIFICARPRECIOPORDEBAJOPL, valor, Nothing, grbModificarPrecioPorDebajoPrecioLista.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PORCENTAJEPORDEBAJOPL, txtPorcentajePrecioPorDebajoPL, Nothing, lblPorcentajePrecioPorDebajoPL.Text)


      'Columna 2
      ActualizarParametro(Entidades.Parametro.Parametros.PRECIOSUNIFICAR, chbPreciosUnificarEntreSucursales, Nothing, chbPreciosUnificarEntreSucursales.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PreciosDecimalesEnVenta, txtCantidadDecimalesEnVenta, Nothing, lblCantidadDecimalesEnVenta.Text)

      'FTP
      ActualizarParametro(Entidades.Parametro.Parametros.FTPSERVIDOR, txtFTPServidor, Nothing, lblFTPServidor.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FTPUSUARIO, txtFTPUsuario, Nothing, lblFTPUsuario.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FTPPASSWORD, txtFTPPassword, Nothing, lblFTPPassword.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FTPCONEXIONPASIVA, chbFTPConexionPasiva, Nothing, chbFTPConexionPasiva.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FTPNOMBREARCHIVO, txtFTPNombreArchivo, Nothing, lblFTPNombreArchivo.Text)
      ActualizarParametroTexto(Entidades.Parametro.Parametros.FTPFORMATO, cmbFTPFormato.Text, Nothing, lblFTPFormato.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FTPCARPETAREMOTA, txtFTPCarpetaRemota, Nothing, lblCarpetaRemota.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FTPCARPETASECUNDARIA, chbFTPUtilizaCarpetaSecundaria, Nothing, chbFTPUtilizaCarpetaSecundaria.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.ACTUALIZAPRECIOCOSTOPORTIPOCAMBIO, chbActualizaPrecioCostoPorTipoDeCambio, Nothing, chbActualizaPrecioCostoPorTipoDeCambio.Text)
      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.MONEDAPARACONSULTARPRECIOS, cmbMonedaParaConsultarPrecios, Nothing, lblMonedaParaConsultarPrecios.Text)

      valor = If(rbtPrecioPorArribaPermitir.Checked, rbtPrecioPorArribaPermitir.Tag.ToString(),
              If(rbtPrecioPorArribaNoPermitir.Checked, rbtPrecioPorArribaNoPermitir.Tag.ToString(),
              If(rbtPrecioPorArribaAvisaryPermitir.Checked, rbtPrecioPorArribaAvisaryPermitir.Tag.ToString(),
              rbtPrecioPorArribaPermitir.Tag.ToString())))

      ActualizarParametro(Entidades.Parametro.Parametros.MODIFICARPRECIOPORARRIBAPL, txtPorcentajePrecioPorArribaPL, Nothing, lblPorcentajePrecioPorArribaPL.Text)


   End Sub

   Protected Overrides Sub OnValidando(e As ValidacionEventArgs)
      MyBase.OnValidando(e)

      If txtCotizacionDolar.ValorNumericoPorDefecto(0D) < 1 Then
         e.AgregarError("La cotización del dolar no puede ser inferior a uno (1)")
         txtCotizacionDolar.Focus()
      End If

   End Sub

End Class