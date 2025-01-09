Public Class ucConfAppMovilesConfiguraciones
   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)


      e.Publicos.CargaComboDesdeEnum(cmbBusquedaClientes, GetType(Entidades.JSonEntidades.CobranzasMovil.BusquedaClientes), , True)
      e.Publicos.CargaComboDesdeEnum(cmbOrdenarProductos, GetType(Entidades.JSonEntidades.CobranzasMovil.OrdenarProductos), , True)

      e.Publicos.CargaComboDesdeEnum(cmbSimovilCobranzaNombreCliente, GetType(Reglas.ServiciosRest.CobranzasMovil.Clientes.NombreCliente), , True)
      e.Publicos.CargaComboDesdeEnum(cmbSimovilCobranzaIncluirClientes, GetType(Reglas.ServiciosRest.CobranzasMovil.Clientes.IncluirClientes), , True)
      e.Publicos.CargaComboTiposDirecciones(cmbSimovilCobranzaTipoDireccion, 0,
                                            New Entidades.TipoDireccion With {.IdTipoDireccion = -1, .NombreTipoDireccion = "Principal"})
      e.Publicos.CargaComboDesdeEnum(cmbSimovilCobranzaSucursales, GetType(Entidades.JSonEntidades.CobranzasMovil.SucursalesSincronizar))

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Simovil Cobranzas
      cmbSimovilCobranzaNombreCliente.SelectedValue = Reglas.Publicos.SimovilCobranzaNombreCliente.ToString()
      cmbSimovilCobranzaTipoDireccion.SelectedValue = Reglas.Publicos.SimovilCobranzaTipoDireccion
      cmbSimovilCobranzaIncluirClientes.SelectedValue = Reglas.Publicos.SimovilCobranzaIncluirClientes.ToString()
      cmbSimovilCobranzaSucursales.SelectedValue = Reglas.Publicos.SimovilCobranzaSucursales

      chbSimovilPrecioConIVA.Checked = Reglas.Publicos.Simovil.PreciosConIVA
      chbSimovilSoloProductosConStock.Checked = Reglas.Publicos.Simovil.SoloProductosConStock
      '-- REQ-44258.- --------------------------------------------------------------------------------------------
      chbSimovilPublicarEmbalaje.Checked = Reglas.Publicos.Simovil.PublicarPrecioEmbalaje
      '-----------------------------------------------------------------------------------------------------------
      'Simovil Cobranzas/Pedidos - Incluir
      chbSimovilSubidaIncluirCuentasCorrientes.Checked = Reglas.Publicos.Simovil.Subida.IncluirCuentasCorrientes
      txtSimovilSubidaMaximoCuotasEnviarCuentasCorrientes.Text = Reglas.Publicos.Simovil.MaximoCuotasEnviarCuentasCorrientes.ToString()
      chbSimovilSubidaIncluirCuentasCorrientesDebeHaber.Checked = Reglas.Publicos.Simovil.Subida.IncluirCuentasCorrientesDebeHaber
      txtSimovilSubidaMesesEnviarCuentasCorrientesDebeHaber.Text = Reglas.Publicos.Simovil.MesesEnviarCuentasCorrientesDebeHaber.ToString()
      chbSimovilSubidaIncluirRubros.Checked = Reglas.Publicos.Simovil.Subida.IncluirRubros
      chbSimovilSubidaIncluirProductos.Checked = Reglas.Publicos.Simovil.Subida.IncluirProductos
      chbSiMovilIncluirProductosClientes.Checked = Reglas.Publicos.Simovil.Subida.IncluirProductosClientes
      chbSimovilSubidaIncluirProductosPrecios.Checked = Reglas.Publicos.Simovil.Subida.IncluirProductosPrecios
      chbSimovilSubidaAplicaPreciosOferta.Checked = Reglas.Publicos.Simovil.Subida.AplicaPreciosOferta
      chbSimovilSubidaIncluirConfiguraciones.Checked = Reglas.Publicos.Simovil.Subida.IncluirConfiguraciones
      chbSimovilSubidaIncluirUsuarios.Checked = Reglas.Publicos.Simovil.Subida.IncluirUsuarios
      chbSimovilSubidaIncluirCalendarios.Checked = Reglas.Publicos.Simovil.Subida.IncluirCalendarios
      chbSimovilSubidaIncluirEmbarcaciones.Checked = Reglas.Publicos.Simovil.Subida.IncluirEmbarcaciones
      chbSimovilSubidaIncluirDestinos.Checked = Reglas.Publicos.Simovil.Subida.IncluirDestinos

      'Simovil Cobranzas/Pedidos - Tamaño de Paginas
      txtSimovilSubidaPaginaRutas.Text = Reglas.Publicos.Simovil.Subida.PaginaRutas.ToString()
      txtSimovilSubidaPaginaRutasClientes.Text = Reglas.Publicos.Simovil.Subida.PaginaRutasClientes.ToString()
      txtSimovilSubidaPaginaRutasListasPrecios.Text = Reglas.Publicos.Simovil.Subida.PaginaRutasListasPrecios.ToString()
      txtSimovilSubidaPaginaClientes.Text = Reglas.Publicos.Simovil.Subida.PaginaClientes.ToString()
      txtSimovilSubidaPaginaCuentasCorrientes.Text = Reglas.Publicos.Simovil.Subida.PaginaCuentasCorrientes.ToString()
      txtSimovilSubidaPaginaCuentasCorrientesDebeHaber.Text = Reglas.Publicos.Simovil.Subida.PaginaCuentasCorrientesDebeHaber.ToString()
      txtSimovilSubidaPaginaRubros.Text = Reglas.Publicos.Simovil.Subida.PaginaRubros.ToString()
      txtSimovilSubidaPaginaProductos.Text = Reglas.Publicos.Simovil.Subida.PaginaProductos.ToString()
      txtSimovilSubidaPaginaProductosPrecios.Text = Reglas.Publicos.Simovil.Subida.PaginaProductosPrecios.ToString()
      txtSimovilSubidaPaginaTickets.Text = Reglas.Publicos.Simovil.Subida.PaginaTickets.ToString() '-.PE-32232.-

      chbExportarArchivosEnviar.Checked = Reglas.Publicos.Simovil.Subida.ExportarArchivosEnviar
      txtPathExportarArchivosEnviar.Text = Reglas.Publicos.Simovil.Subida.PathExportarArchivosEnviar


      'Simovil Pedidos
      txtCorreoMovil1.Text = Reglas.Publicos.ParametrosSiMovil.CorreoMovil1
      txtCorreoMovil2.Text = Reglas.Publicos.ParametrosSiMovil.CorreoMovil2
      txtCorreoMovil3.Text = Reglas.Publicos.ParametrosSiMovil.CorreoMovil3

      cmbBusquedaClientes.SelectedValue = Reglas.Publicos.ParametrosSiMovil.BusquedaClientes
      cmbOrdenarProductos.SelectedValue = Reglas.Publicos.ParametrosSiMovil.OrdenarProductos

      txtSimovilPorcMaxDescuento.Text = Reglas.Publicos.ParametrosSiMovil.PorcMaxDescuento.ToString("N2")
      txtSimovilPorcMaxRecargo.Text = Reglas.Publicos.ParametrosSiMovil.PorcMaxRecargo.ToString("N2")

      chbSolicitaTipoComprobante.Checked = Reglas.Publicos.ParametrosSiMovil.SolicitaTipoComprobante
      chbSolicitaCierrePedidos.Checked = Reglas.Publicos.ParametrosSiMovil.SolicitaCierrePedidos
      chbUsarFechaExportacion.Checked = Reglas.Publicos.ParametrosSiMovil.UsarFechaExportacion
      chbOcultarCompartirVentasPorMail.Checked = Reglas.Publicos.ParametrosSiMovil.OcultarCompartirVentasPorMail
      chbOcultarResumenPromedio.Checked = Reglas.Publicos.ParametrosSiMovil.OcultarResumenPromedio
      chbEnviaMailCliente.Checked = Reglas.Publicos.ParametrosSiMovil.EnviaMailCliente
      chbEnviaMailEmpresa.Checked = Reglas.Publicos.ParametrosSiMovil.EnviaMailEmpresa

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Simovil Cobranzas
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.SIMOVILCOBRANZANOMBRECLIENTE, cmbSimovilCobranzaNombreCliente, Nothing, lblSimovilCobranzaNombreCliente.Text)
      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.SIMOVILCOBRANZATIPODIRECCION, cmbSimovilCobranzaTipoDireccion, Nothing, lblSimovilCobranzaTipoDireccion.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.SIMOVILCOBRANZAINCLUIRCLIENTES, cmbSimovilCobranzaIncluirClientes, Nothing, lblSimovilCobranzaIncluirClientes.Text)
      ActualizarParametro(Of Entidades.JSonEntidades.CobranzasMovil.SucursalesSincronizar)(Entidades.Parametro.Parametros.SIMOVILCOBRANZASUCURSALES, cmbSimovilCobranzaSucursales, Nothing, lblSimovilCobranzaSucursales.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILPRECIOSCONIVA, chbSimovilPrecioConIVA, Nothing, chbSimovilPrecioConIVA.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSOLOPRODUCTOSCONSTOCK, chbSimovilSoloProductosConStock, Nothing, chbSimovilSoloProductosConStock.Text)
      '-- REQ-44258.- ------------------------------------------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILPRECIOPOREMBALAJE, chbSimovilPublicarEmbalaje, Nothing, chbSimovilPublicarEmbalaje.Text)
      '---------------------------------------------------------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAINCLUIRCUENTASCORRIENTES, chbSimovilSubidaIncluirCuentasCorrientes, Nothing, chbSimovilSubidaIncluirCuentasCorrientes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAMAXIMOCUOTASENVIARCUENTASCORRIENTES, txtSimovilSubidaMaximoCuotasEnviarCuentasCorrientes, Nothing, lblSimovilSubidaMaximoCuotasEnviarCuentasCorrientes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAINCLUIRCUENTASCORRIENTESDEBEHABER, chbSimovilSubidaIncluirCuentasCorrientesDebeHaber, Nothing, chbSimovilSubidaIncluirCuentasCorrientesDebeHaber.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAMESESENVIARCUENTASCORRIENTESDEBEHABER, txtSimovilSubidaMesesEnviarCuentasCorrientesDebeHaber, Nothing, lblSimovilSubidaMesesEnviarCuentasCorrientesDebeHaber.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAINCLUIRRUBROS, chbSimovilSubidaIncluirRubros, Nothing, chbSimovilSubidaIncluirRubros.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAINCLUIRPRODUCTOS, chbSimovilSubidaIncluirProductos, Nothing, chbSimovilSubidaIncluirProductos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAINCLUIRPRODUCTOSCLIENTES, chbSiMovilIncluirProductosClientes, Nothing, chbSiMovilIncluirProductosClientes.Tag.ToString())
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAINCLUIRPRODUCTOSPRECIOS, chbSimovilSubidaIncluirProductosPrecios, Nothing, chbSimovilSubidaIncluirProductosPrecios.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAAPLICAPRECIOSOFERTA, chbSimovilSubidaAplicaPreciosOferta, Nothing, chbSimovilSubidaAplicaPreciosOferta.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAINCLUIRCONFIGURACIONES, chbSimovilSubidaIncluirConfiguraciones, Nothing, chbSimovilSubidaIncluirConfiguraciones.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAINCLUIRUSUARIOS, chbSimovilSubidaIncluirUsuarios, Nothing, chbSimovilSubidaIncluirUsuarios.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAINCLUIRCALENDARIOS, chbSimovilSubidaIncluirCalendarios, Nothing, chbSimovilSubidaIncluirCalendarios.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAINCLUIREMBARCACIONES, chbSimovilSubidaIncluirEmbarcaciones, Nothing, chbSimovilSubidaIncluirEmbarcaciones.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAINCLUIRDESTINOS, chbSimovilSubidaIncluirDestinos, Nothing, chbSimovilSubidaIncluirDestinos.Text)


      'Simovil Cobranzas/Pedidos - Tamaño de Paginas
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAPAGINARUTAS, txtSimovilSubidaPaginaRutas, Nothing, lblSimovilSubidaPaginaRutas.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAPAGINARUTASCLIENTES, txtSimovilSubidaPaginaRutasClientes, Nothing, lblSimovilSubidaPaginaRutasClientes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAPAGINARUTASLISTASPRECIOS, txtSimovilSubidaPaginaRutasListasPrecios, Nothing, lblSimovilSubidaPaginaRutasListasPrecios.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAPAGINACLIENTES, txtSimovilSubidaPaginaClientes, Nothing, lblSimovilSubidaPaginaClientes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAPAGINACUENTASCORRIENTES, txtSimovilSubidaPaginaCuentasCorrientes, Nothing, lblSimovilSubidaPaginaCuentasCorrientes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAPAGINACUENTASCORRIENTESDEBEHABER, txtSimovilSubidaPaginaCuentasCorrientesDebeHaber, Nothing, lblSimovilSubidaPaginaCuentasCorrientesDebeHaber.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAPAGINARUBROS, txtSimovilSubidaPaginaRubros, Nothing, lblSimovilSubidaPaginaRubros.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAPAGINAPRODUCTOS, txtSimovilSubidaPaginaProductos, Nothing, lblSimovilSubidaPaginaProductos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAPAGINAPRODUCTOSPRECIOS, txtSimovilSubidaPaginaProductosPrecios, Nothing, lblSimovilSubidaPaginaProductosPrecios.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAPAGINATICKETS, txtSimovilSubidaPaginaTickets, Nothing, lblSimovilSubidaPaginaTickets.Text) '-.PE-32232.-

      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAEXPORTARARCHIVOSENVIAR, chbExportarArchivosEnviar, Nothing, chbExportarArchivosEnviar.Text) '-.PE-32232.-
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSUBIDAPATHEXPORTARARCHIVOSENVIAR, txtPathExportarArchivosEnviar, Nothing, "Path" + chbExportarArchivosEnviar.Text) '-.PE-32232.-



      'Simovil  Pedidos
      ActualizarParametro(Entidades.Parametro.Parametros.CORREOMOVIL1, txtCorreoMovil1, Nothing, lblCorreoMovil1.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CORREOMOVIL2, txtCorreoMovil2, Nothing, lblCorreoMovil2.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CORREOMOVIL3, txtCorreoMovil3, Nothing, lblCorreoMovil3.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.BUSQUEDACLIENTES, cmbBusquedaClientes, Nothing, lblBusquedaClientes.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.ORDENARPRODUCTOS, cmbOrdenarProductos, Nothing, lblOrdenarProductos.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILPORCMAXDESCUENTO, txtSimovilPorcMaxDescuento, Nothing, lblSimovilPorcMaxDescuento.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILPORCMAXRECARGO, txtSimovilPorcMaxRecargo, Nothing, lblSimovilPorcMaxRecargo.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.SOLICITATIPOCOMPROBANTE, chbSolicitaTipoComprobante, Nothing, chbSolicitaTipoComprobante.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SOLICITACIERREPEDIDOS, chbSolicitaCierrePedidos, Nothing, chbSolicitaCierrePedidos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.USARFECHAEXPORTACION, chbUsarFechaExportacion, Nothing, chbUsarFechaExportacion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.OCULTARCOMPARTIRVENTASPORMAIL, chbOcultarCompartirVentasPorMail, Nothing, chbOcultarCompartirVentasPorMail.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ENVIAMAILCLIENTE, chbEnviaMailCliente, Nothing, chbEnviaMailCliente.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ENVIAMAILEMPRESA, chbEnviaMailEmpresa, Nothing, chbEnviaMailEmpresa.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.OCULTARRESUMENPROMEDIO, chbOcultarResumenPromedio, Nothing, chbOcultarResumenPromedio.Text)

   End Sub

   Protected Overrides Sub OnValidando(e As ValidacionEventArgs)
      MyBase.OnValidando(e)

      If txtSimovilPorcMaxDescuento.ValorNumericoPorDefecto(0D) > 99 Then
         e.AgregarError("El descuento máximo para el Movil no puede superar el 99%.")
         txtSimovilPorcMaxDescuento.Focus()
      End If


   End Sub

End Class