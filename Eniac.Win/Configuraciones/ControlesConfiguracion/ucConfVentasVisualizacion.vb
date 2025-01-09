Public Class ucConfVentasVisualizacion
   Public _MensajeTooTip As String

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      '# Historia Clinica
      e.Publicos.CargaComboCategorias(cmbIdCategoriaPaciente)
      e.Publicos.CargaComboCategorias(cmbIdCategoriaDoctor)

      e.Publicos.CargaComboDesdeEnum(cmbFacturacionOrdenDeTitulo, GetType(Entidades.Publicos.FacturacionOrdenesDeTitulo), , True)
      e.Publicos.CargaComboDesdeEnum(cmbFacturacionOrdenDeColores1, GetType(Entidades.Publicos.FacturacionOrdenesDeColor))
      e.Publicos.CargaComboDesdeEnum(cmbFacturacionOrdenDeColores2, GetType(Entidades.Publicos.FacturacionOrdenesDeColor))
      e.Publicos.CargaComboDesdeEnum(cmbFacturacionOrdenDeColores3, GetType(Entidades.Publicos.FacturacionOrdenesDeColor))

      '-- REG-32379 - 32381.- ---------------------
      e.Publicos.CargaComboDesdeEnum(cmbFacturacionVisualizaPrecioCosto, GetType(Entidades.Publicos.VisualizaPrecioCosto), , True)
      e.Publicos.CargaComboDesdeEnum(cmbFactRapidaVisualizaPrecioCosto, GetType(Entidades.Publicos.VisualizaPrecioCosto), , True)

      _MensajeTooTip = String.Format("{1}{0}{2}{0}{3}",
                                     Environment.NewLine,
                                     "No Mostrar = Oculta la visualizacion del Precio de Costo.",
                                     "Mostar = Permite la visualizacion del Precio de Costo.",
                                     "Modificable = Permite modificar el costo, solo a productos que permitan modificar su descripción.")
      '-- REQ-44348.- ---------------------------------------------------------------------------------------------------------------
      e.Publicos.CargaComboDesdeEnum(cmbVisualizaPrecioVenta, GetType(Reglas.Publicos.FormatoVisualizaPrecioDolares), , True)
      '------------------------------------------------------------------------------------------------------------------------------

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      chbFacturacionVendedorEnTitulo.Checked = Reglas.Publicos.Facturacion.FacturacionVendedorEnTitulo
      chbFacturacionCajaEnTitulo.Checked = Reglas.Publicos.Facturacion.FacturacionCajaEnTitulo
      chbFacturacionSolicitaVendedorAlAbrir.Checked = Reglas.Publicos.Facturacion.FacturacionSolicitaVendedorAlAbrir
      chbFacturacionSolicitaCajaAlAbrir.Checked = Reglas.Publicos.Facturacion.FacturacionSolicitaCajaAlAbrir

      '-- REQ-32597.- Conserva el Orden de los Productos en la Grilla.- ---------------------------------------------
      chbFacturacionConservaOrdenProductos.Checked = Reglas.Publicos.Facturacion.FacturacionConservaOrdenProductos
      chbFacturacionRapidaConservaOrdenProductos.Checked = Reglas.Publicos.Facturacion.FacturacionRapidaConservaOrdenProductos
      '--------------------------------------------------------------------------------------------------------------

      '-- REQ-32379/32381.- Visualiza Precio de Costo Facturacio - Facturacion Rapida.- -----------------------------
      cmbFacturacionVisualizaPrecioCosto.SelectedValue = Reglas.Publicos.Facturacion.FacturacionVisualizaPrecioCosto
      cmbFactRapidaVisualizaPrecioCosto.SelectedValue = Reglas.Publicos.Facturacion.FacturacionRapidaVisualizaPrecioCosto
      '--------------------------------------------------------------------------------------------------------------

      cmbFacturacionOrdenDeTitulo.SelectedValue = Reglas.Publicos.Facturacion.FacturacionOrdenDeTitulo
      cmbFacturacionOrdenDeColores1.SelectedValue = Reglas.Publicos.Facturacion.FacturacionOrdenDeColor1
      cmbFacturacionOrdenDeColores2.SelectedValue = Reglas.Publicos.Facturacion.FacturacionOrdenDeColor2
      cmbFacturacionOrdenDeColores3.SelectedValue = Reglas.Publicos.Facturacion.FacturacionOrdenDeColor3

      chbFacturacionRapidaMuestraFotoProducto.Checked = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaMuestraFotoProducto
      chbFacturacionRapidaMuestraComprobante.Checked = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaMuestraComprobante
      chbFacturacionRapidaSolicitaVendedorPorDefecto.Checked = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaSolicitaVendedorPorDefecto
      chbFacturacionRapidaSolicitaTipoComprobantePorDefecto.Checked = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaSolicitaTipoComprobantePorDefecto

      '-- REQ-44348.- ---------------------------------------------------------------------------------------------------------------
      cmbVisualizaPrecioVenta.SelectedValue = Reglas.Publicos.VentasVisualizaPrecioEnDolares
      '------------------------------------------------------------------------------------------------------------------------------

      chbFacturacionMostrarDesc1.Checked = Reglas.Publicos.Facturacion.FacturacionMostrarDesc1
      chbFacturacionMostrarDesc2.Checked = Reglas.Publicos.Facturacion.FacturacionMostrarDesc2
      chbFacturacionMostrarPrecioUnitario.Checked = Reglas.Publicos.Facturacion.FacturacionMostrarPrecioUnitario
      chbFacturacionMostrarPrecioConIVA.Checked = Reglas.Publicos.Facturacion.FacturacionMostrarPrecioConIVA
      chbFacturacionMostrarStock.Checked = Reglas.Publicos.Facturacion.FacturacionMostrarStock
      chbFacturacionMostrarKilos.Checked = Reglas.Publicos.Facturacion.FacturacionMostrarKilos
      chbFacturacionVisualizaCantidadConvertida.Checked = Reglas.Publicos.FacturacionVisualizaCantidadConvertida
      chbFacturacionVisualizaOrden.Checked = Reglas.Publicos.Facturacion.FacturacionVisualizaOrden
      chbFacturacionMostrarProvHabitual.Checked = Reglas.Publicos.Facturacion.FacturacionMuestraProvHabitual
      chbFacturacionVisualizaConversion.Checked = Reglas.Publicos.FacturacionVisualizaConversion
      '--REQ-44219.- -----------------------------------------------------------------------------------------------------------------
      chbFacturacionVisualizaDeposito.Checked = Reglas.Publicos.FacturacionVisualizaDeposito
      chbFacturacionVisualizaUbicacion.Checked = Reglas.Publicos.FacturacionVisualizaUbicacion
      '-------------------------------------------------------------------------------------------------------------------------------
      chbFacturacionResaltaProductosEnOferta.Checked = Reglas.Publicos.FacturacionResaltaProductosEnOferta

      chbFactRapidaMostrarDesc1.Checked = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaMostrarDesc1
      chbFactRapidaMostrarDesc2.Checked = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaMostrarDesc2
      chbFactRapidaMostrarPrecioUnitario.Checked = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaMuestraPrUnitario
      chbFactRapidaMostrarListaPrecio.Checked = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaMuestraListaPrecio

      '# Historia Clinica
      chbFacturacionMuestraHistoriaClinica.Checked = Reglas.Publicos.FacturacionMuestraHistoriaClinica
      If Reglas.Publicos.IdCategoriaPaciente.ValorNumericoPorDefecto(0I) > 0 Then
         cmbIdCategoriaPaciente.SelectedValue = Reglas.Publicos.IdCategoriaPaciente.ValorNumericoPorDefecto(0I)
      End If
      If Reglas.Publicos.IdCategoriaDoctor.ValorNumericoPorDefecto(0I) > 0 Then
         cmbIdCategoriaDoctor.SelectedValue = Reglas.Publicos.IdCategoriaDoctor.ValorNumericoPorDefecto(0I)
      End If

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONVENDEDORENTITULO, chbFacturacionVendedorEnTitulo, Nothing, chbFacturacionVendedorEnTitulo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCAJAENTITULO, chbFacturacionCajaEnTitulo, Nothing, chbFacturacionCajaEnTitulo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONSOLICITAVENDEDORALABRIR, chbFacturacionSolicitaVendedorAlAbrir, Nothing, chbFacturacionSolicitaVendedorAlAbrir.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONSOLICITACAJAALABRIR, chbFacturacionSolicitaCajaAlAbrir, Nothing, chbFacturacionSolicitaCajaAlAbrir.Text)

      '-- REQ-32597.- Conserva el Orden de los Productos en la Grilla.- ----------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCONSERVAORDENPRODUCTO, chbFacturacionConservaOrdenProductos, Nothing, chbFacturacionConservaOrdenProductos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRAPIDACONSERVAORDENPRODUCTO, chbFacturacionRapidaConservaOrdenProductos, Nothing, chbFacturacionRapidaConservaOrdenProductos.Text)
      '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
      '-- REQ-32379/32381.- Visualiza Precio de Costo Facturacio - Facturacion Rapida.- ------------------------------------------------------------------------------------------------
      If cmbFacturacionVisualizaPrecioCosto.SelectedIndex > -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.FACTURACIONVISUALIZAPRECIOCOSTO, cmbFacturacionVisualizaPrecioCosto, Nothing, lblFacturacionVisualizaPrecioCosto.Text)
      End If
      If cmbFactRapidaVisualizaPrecioCosto.SelectedIndex > -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.FACTURACIONRAPIDAVISUALIZAPRECIOCOSTO, cmbFactRapidaVisualizaPrecioCosto, Nothing, lblFactRapidaVisualizaPrecioCosto.Text)
      End If
      '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.FACTURACIONORDENDETITULO, cmbFacturacionOrdenDeTitulo, Nothing, lblFacturacionOrdenDeTitulo.Text)
      Dim orden = String.Format("{0},{1},{2}",
                                cmbFacturacionOrdenDeColores1.ValorSeleccionado(Of Entidades.Publicos.FacturacionOrdenesDeColor).ToString(),
                                cmbFacturacionOrdenDeColores2.ValorSeleccionado(Of Entidades.Publicos.FacturacionOrdenesDeColor).ToString(),
                                cmbFacturacionOrdenDeColores3.ValorSeleccionado(Of Entidades.Publicos.FacturacionOrdenesDeColor).ToString())
      ActualizarParametroTexto(Entidades.Parametro.Parametros.FACTURACIONORDENDECOLOR, orden, Nothing, lblFacturacionOrdenDeColores.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRAPIDAMUESTRAFOTOPRODUCTO, chbFacturacionRapidaMuestraFotoProducto, Nothing, chbFacturacionRapidaMuestraFotoProducto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRAPIDAMUESTRACOMPROBANTE, chbFacturacionRapidaMuestraComprobante, Nothing, chbFacturacionRapidaMuestraComprobante.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRAPIDASOLICITAVENDEDORPORDEFECTO, chbFacturacionRapidaSolicitaVendedorPorDefecto, Nothing, chbFacturacionRapidaSolicitaVendedorPorDefecto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRAPIDASOLICITATIPOCOMPROBANTEPORDEFECTO, chbFacturacionRapidaSolicitaTipoComprobantePorDefecto, Nothing, chbFacturacionRapidaSolicitaTipoComprobantePorDefecto.Text)


      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMOSTRARDESC1, chbFacturacionMostrarDesc1, Nothing, grpFacturacionColumnaMostrar.Text + " " + chbFacturacionMostrarDesc1.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMOSTRARDESC2, chbFacturacionMostrarDesc2, Nothing, grpFacturacionColumnaMostrar.Text + " " + chbFacturacionMostrarDesc2.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMOSTRARPRECIOUNITARIO, chbFacturacionMostrarPrecioUnitario, Nothing, grpFacturacionColumnaMostrar.Text + " " + chbFacturacionMostrarPrecioUnitario.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMOSTRARPRECIOCONIVA, chbFacturacionMostrarPrecioConIVA, Nothing, grpFacturacionColumnaMostrar.Text + " " + chbFacturacionMostrarPrecioConIVA.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMUESTRAPROVHABITUAL, chbFacturacionMostrarProvHabitual, Nothing, Entidades.Parametro.Parametros.FACTURACIONMUESTRAPROVHABITUAL.ToString())

      '-- REQ-44348.- ---------------------------------------------------------------------------------------------------------------
      If cmbVisualizaPrecioVenta.SelectedIndex > -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.FACTURACIONMOSTRARPRECIOSENDOLARES, cmbVisualizaPrecioVenta, Nothing, lblVisualizaPrecioVenta.Text)
      End If
      '------------------------------------------------------------------------------------------------------------------------------

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMOSTRARSTOCK, chbFacturacionMostrarStock, Nothing, grpFacturacionColumnaMostrar.Text + " " + chbFacturacionMostrarStock.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMOSTRARKILOS, chbFacturacionMostrarKilos, Nothing, grpFacturacionColumnaMostrar.Text + " " + chbFacturacionMostrarKilos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONVISUALIZACANTIDADCONVERTIDA, chbFacturacionVisualizaCantidadConvertida, Nothing, chbFacturacionVisualizaCantidadConvertida.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONVISUALIZACONVERSION, chbFacturacionVisualizaConversion, Nothing, chbFacturacionVisualizaConversion.Text)

      '-- REQ-44219.- --------------------------------------------------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONVISUALIZADEPOSITO, chbFacturacionVisualizaDeposito, Nothing, chbFacturacionVisualizaDeposito.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONVISUALIZAUBICACION, chbFacturacionVisualizaUbicacion, Nothing, chbFacturacionVisualizaUbicacion.Text)
      '----------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONVISUALIZAORDEN, chbFacturacionVisualizaOrden, Nothing, chbFacturacionVisualizaOrden.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRESALTAPRODUCTOSENOFERTA, chbFacturacionResaltaProductosEnOferta, Nothing, chbFacturacionResaltaProductosEnOferta.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRAPIDAMOSTRARDESC1, chbFactRapidaMostrarDesc1, Nothing, grpFactRapidaColumnaMostrar.Text + " " + chbFactRapidaMostrarDesc1.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRAPIDAMOSTRARDESC2, chbFactRapidaMostrarDesc2, Nothing, grpFactRapidaColumnaMostrar.Text + " " + chbFactRapidaMostrarDesc2.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRAPIDAMOSTRARLISTAPRECIO, chbFactRapidaMostrarListaPrecio, Nothing, grpFactRapidaColumnaMostrar.Text + " " + chbFactRapidaMostrarListaPrecio.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRAPIDAMOSTRARPRUNITARIO, chbFactRapidaMostrarPrecioUnitario, Nothing, grpFactRapidaColumnaMostrar.Text + " " + chbFactRapidaMostrarPrecioUnitario.Text)

      '# Historia Clinica
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMUESTRAHISTORIACLINICA, chbFacturacionMuestraHistoriaClinica, Nothing, chbFacturacionMuestraHistoriaClinica.Tag.ToString())
      If cmbIdCategoriaPaciente.SelectedIndex > -1 Then ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.IDCATEGORIAPACIENTE, cmbIdCategoriaPaciente, Nothing, cmbIdCategoriaPaciente.Tag.ToString())
      If cmbIdCategoriaDoctor.SelectedIndex > -1 Then ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.IDCATEGORIADOCTOR, cmbIdCategoriaDoctor, Nothing, cmbIdCategoriaDoctor.Tag.ToString())

   End Sub

   '-- REG-32381.- ------------------------------------------------------------
   Private Sub cmbFacturacionVisualizaPrecioCosto_MouseMove(sender As Object, e As MouseEventArgs) Handles cmbFacturacionVisualizaPrecioCosto.MouseMove
      ttMensaje.SetToolTip(cmbFacturacionVisualizaPrecioCosto, _MensajeTooTip)
      ttMensaje.ToolTipTitle = "Facturacion - Visualizar Precio de Costo"
      ttMensaje.ToolTipIcon = ToolTipIcon.Info
   End Sub
   '-- REG-32379.- ------------------------------------------------------------
   Private Sub cmbFactRapidaVisualizaPrecioCosto_MouseMove(sender As Object, e As MouseEventArgs) Handles cmbFactRapidaVisualizaPrecioCosto.MouseMove
      ttMensaje.SetToolTip(cmbFactRapidaVisualizaPrecioCosto, _MensajeTooTip)
      ttMensaje.ToolTipTitle = "Facturacion Rapida - Visualizar Precio de Costo"
      ttMensaje.ToolTipIcon = ToolTipIcon.Info
   End Sub
   '---------------------------------------------------------------------------

End Class