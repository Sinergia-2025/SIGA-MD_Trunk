Public Class ucConfStock

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboDesdeEnum(cmbClaveLoteDespachoImportacion, GetType(Reglas.Publicos.ClaveLoteDespachoImportacionEnum), , True)
      '-- REQ-34667.- Carga el combo de Atributos.- ---------------------------------------------------------
      e.Publicos.CargaComboTiposAtributos(cmbTipoAtributo01)
      e.Publicos.CargaComboTiposAtributos(cmbTipoAtributo02)
      e.Publicos.CargaComboTiposAtributos(cmbTipoAtributo03)
      e.Publicos.CargaComboTiposAtributos(cmbTipoAtributo04)
      '------------------------------------------------------------------------------------------------------
   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Stock
      Dim FacturarSinStock = Reglas.Publicos.Facturacion.FacturarSinStock
      Select Case FacturarSinStock
         Case "PERMITIR"
            rbtFacturarSinStockPermitir.Checked = True
         Case "NOPERMITIR"
            rbtFacturarSinStockNoPermitir.Checked = True
         Case Else   'AVISARYPERMITIR
            rbtFacturarSinStockAvisarYPermitir.Checked = True
      End Select
      chbFacturarSinStockControlaNoAfectaStock.Checked = Reglas.Publicos.Facturacion.FacturarSinStockControlaNoAfectaStock

      chbContraMovimientoEnvioRecepcionSucursalDestino.Checked = Reglas.Publicos.ContraMovimientoEnvioRecepcionSucursal
      chbVisualizaNrosSerie.Checked = Reglas.Publicos.VisualizaNrosSerie
      chbVizualizaLote.Checked = Reglas.Publicos.VisualizaLote
      chbUtilizaPrecioCostoPorLote.Checked = Reglas.Publicos.UtilizaPrecioCostoPorLote
      chbLoteSolicitaFechaVencimiento.Checked = Publicos.LoteSolicitaFechaVencimiento
      chbLoteSolicitaDespachoImportacion.Checked = Reglas.Publicos.LoteSolicitaDespachoImportacion
      cmbClaveLoteDespachoImportacion.SelectedValue = Reglas.Publicos.ClaveLoteDespachoImportacion

      Dim infDeStockPredeterminadoEn = Reglas.Publicos.InformeDeStockMostrarPrecioPredeterminado
      Select Case infDeStockPredeterminadoEn
         Case "Ninguno"
            rdbListadoStockPorNinguno.Checked = True
         Case "PrecioDeCosto"
            rdbListadoStockPorPrecioDeCosto.Checked = True
         Case "PrecioDeVenta"
            rdbListadoStockPorPrecioDeVenta.Checked = True
      End Select

      '-- REQ-34667.- Carga el combo de Atributos.- ---------------------------------------------------------
      If Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01 > 0 Then
         chbTipoAtributo01.Checked = True
         cmbTipoAtributo01.SelectedValue = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
      End If
      If Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02 > 0 Then
         chbTipoAtributo02.Checked = True
         cmbTipoAtributo02.SelectedValue = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
      End If
      If Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03 > 0 Then
         chbTipoAtributo03.Checked = True
         cmbTipoAtributo03.SelectedValue = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
      End If
      If Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04 > 0 Then
         chbTipoAtributo04.Checked = True
         cmbTipoAtributo04.SelectedValue = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04
      End If
      '------------------------------------------------------------------------------------------------------


      'Columna 2
      chbVisualizaStockReservado.Checked = Reglas.Publicos.VisualizaStockReservado
      chbVisualizaStockDefectuoso.Checked = Reglas.Publicos.VisualizaStockDefectuoso
      chbVisualizaStockFuturo.Checked = Reglas.Publicos.VisualizaStockFuturo
      chbVisualizaStockFuturoReservado.Checked = Reglas.Publicos.VisualizaStockFuturoReservado


   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Stock
      ActualizarParametroTexto(Entidades.Parametro.Parametros.FACTURARSINSTOCK,
                               If(rbtFacturarSinStockPermitir.Checked, "PERMITIR", If(rbtFacturarSinStockNoPermitir.Checked, "NOPERMITIR", "AVISARYPERMITIR")),
                               Nothing, grbFacturarSinStock.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURARSINSTOCKCONTROLANOAFECTASTOCK, chbFacturarSinStockControlaNoAfectaStock, Nothing, chbFacturarSinStockControlaNoAfectaStock.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.CONTRAMOVIMIENTOENVIORECEPCIONSUCURSAL, chbContraMovimientoEnvioRecepcionSucursalDestino, Nothing, chbContraMovimientoEnvioRecepcionSucursalDestino.Text)
      ActualizarParametroTexto(Entidades.Parametro.Parametros.VISUALIZANROSERIE, If(chbVisualizaNrosSerie.Checked, "SI", "NO"), Nothing, chbVisualizaNrosSerie.Text)
      ActualizarParametroTexto(Entidades.Parametro.Parametros.VISUALIZALOTE, If(chbVizualizaLote.Checked, "SI", "NO"), Nothing, chbVizualizaLote.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.UTILIZAPRECIOCOSTOPORLOTE, chbUtilizaPrecioCostoPorLote, Nothing, chbUtilizaPrecioCostoPorLote.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.LOTESOLICITAFECHAVENCIMIENTO, chbLoteSolicitaFechaVencimiento, Nothing, chbLoteSolicitaFechaVencimiento.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.LOTESOLICITADESPACHOIMPORTACION, chbLoteSolicitaDespachoImportacion, Nothing, chbLoteSolicitaDespachoImportacion.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.CLAVELOTEDESPACHOIMPORTACION, cmbClaveLoteDespachoImportacion, Nothing, "Clave" + chbLoteSolicitaDespachoImportacion.Text)

      ActualizarParametroTexto(Entidades.Parametro.Parametros.INFDESTOCKMOSTRARPRECIOPREDETERMINADO,
                               If(rdbListadoStockPorNinguno.Checked, "Ninguno", If(rdbListadoStockPorPrecioDeVenta.Checked, "PrecioDeVenta", "PrecioDeCosto")),
                               Nothing, grbMostrarPrecioListadoStock.Text)

      'Columna 2
      ActualizarParametro(Entidades.Parametro.Parametros.VISUALIZASTOCKRESERVADO, chbVisualizaStockReservado, Nothing, chbVisualizaStockReservado.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.VISUALIZASTOCKDEFECTUOSO, chbVisualizaStockDefectuoso, Nothing, chbVisualizaStockDefectuoso.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.VISUALIZASTOCKFUTURO, chbVisualizaStockFuturo, Nothing, chbVisualizaStockFuturo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.VISUALIZASTOCKFUTURORESERVADO, chbVisualizaStockFuturoReservado, Nothing, chbVisualizaStockFuturoReservado.Text)

      '-- REQ-34667.- -----------------------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Of Short)(Entidades.Parametro.Parametros.TIPOATRIBUTOPRODUCTO01, cmbTipoAtributo01, Nothing, chbTipoAtributo01.Text)
      ActualizarParametro(Of Short)(Entidades.Parametro.Parametros.TIPOATRIBUTOPRODUCTO02, cmbTipoAtributo02, Nothing, chbTipoAtributo02.Text)
      ActualizarParametro(Of Short)(Entidades.Parametro.Parametros.TIPOATRIBUTOPRODUCTO03, cmbTipoAtributo03, Nothing, chbTipoAtributo03.Text)
      ActualizarParametro(Of Short)(Entidades.Parametro.Parametros.TIPOATRIBUTOPRODUCTO04, cmbTipoAtributo04, Nothing, chbTipoAtributo04.Text)
      '--------------------------------------------------------------------------------------------------------------------------------------------
   End Sub

   '-- REQ-34667.- --------------------------------------------------------------------------------------------------------------
   Private Sub chbListaPrecio01_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoAtributo01.CheckedChanged
      Select Case chbTipoAtributo01.Checked
         Case True
            cmbTipoAtributo01.Enabled = True
         Case False
            cmbTipoAtributo01.Enabled = False
            cmbTipoAtributo01.SelectedIndex = -1
      End Select
   End Sub
   Private Sub chbTipoAtributo02_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoAtributo02.CheckedChanged
      Select Case chbTipoAtributo02.Checked
         Case True
            cmbTipoAtributo02.Enabled = True
         Case False
            cmbTipoAtributo02.Enabled = False
            cmbTipoAtributo02.SelectedIndex = -1
      End Select

   End Sub
   Private Sub chbTipoAtributo03_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoAtributo03.CheckedChanged
      Select Case chbTipoAtributo03.Checked
         Case True
            cmbTipoAtributo03.Enabled = True
         Case False
            cmbTipoAtributo03.Enabled = False
            cmbTipoAtributo03.SelectedIndex = -1
      End Select

   End Sub
   Private Sub chbTipoAtributo04_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoAtributo04.CheckedChanged
      Select Case chbTipoAtributo04.Checked
         Case True
            cmbTipoAtributo04.Enabled = True
         Case False
            cmbTipoAtributo04.Enabled = False
            cmbTipoAtributo04.SelectedIndex = -1
      End Select

   End Sub
   '-----------------------------------------------------------------------------------------------------------------------------

End Class