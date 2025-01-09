Public Class ucConfLogistica

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboFormasDePago(cboFormasPagoOrgEntregas, "VENTAS")
      e.Publicos.CargaComboDesdeEnum(cmbOrganizarEntregaFiltroImpreso, GetType(Entidades.Publicos.SiNoTodos))
      e.Publicos.CargaComboDesdeEnum(cmbFormatoExportacion1, GetType(Entidades.GenerarArchivo.FormatosExportacion), , True)

      e.Publicos.CargaComboDesdeEnum(cmbPreventaImprimirPedidos, GetType(Reglas.Publicos.SiempreNuncaPreguntar), , True)
      e.Publicos.CargaComboDesdeEnum(cmbPreVentaAccionSinListaPrecios, GetType(Entidades.PreVenta.AccionSinListaPrecios))
      e.Publicos.CargaComboTiposMovimientos(cmbRegistracionPagosTipoMovimiento)
      e.Publicos.CargaComboDesdeEnum(cmbRegistracionPagosModoConsultarComprobantes, GetType(Entidades.RegistracionPagos.ModoConsultarComprobantes))


   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Logistica
      'Generar Archivos
      txtDestinoArchivosParaMoviles.Text = Reglas.Publicos.Logistica.RutaArchivosPalm
      cmbFormatoExportacion1.SelectedValue = Reglas.Publicos.Logistica.LogisticaFormatoExportacionDefault
      chbExportarPreciosConIVA1.Checked = Reglas.Publicos.Logistica.ExportarPreciosConIVA
      chbIncluirEsCambiableEsBonificable.Checked = Reglas.Publicos.Logistica.IncluirEsCambiableEsBonificable


      'Preventa
      chbPreventaV2ImportaDescuentosPedidosPDA.Checked = Reglas.Publicos.PreventaV2ImportaDescuentosPedidosPDA
      chbPreventaV2ImportaDescuentosSiMovilWeb.Checked = Reglas.Publicos.PreventaV2ImportaDescuentosSimovilWeb
      cmbPreventaImprimirPedidos.SelectedValue = Reglas.Publicos.PreventaImprimirPedidos
      chbPreventaV2RespetaListaPreciosCliente.Checked = Publicos.PreventaV2RespetaListaPreciosCliente
      cmbPreVentaAccionSinListaPrecios.SelectedValue = Reglas.Publicos.PreVentaAccionSinListaPrecios
      chbPreventaRespetaPrecioDelMovil.Checked = Reglas.Publicos.PreventaRespetaPrecioDelMovil
      chbPreVentaAgrupaOrdenProductoEnCadaPedido.Checked = Reglas.Publicos.PreVentaAgrupaOrdenProductoEnCadaPedido


      'Organizar Entrega
      If cboFormasPagoOrgEntregas.Items.Count > 0 Then
         cboFormasPagoOrgEntregas.SelectedValue = Reglas.Publicos.OrganizarEntregaFormaDePago
      End If
      cmbOrganizarEntregaFiltroImpreso.SelectedValue = Reglas.Publicos.OrganizarEntregaFiltroImpreso
      chbOrganizarEntregaFiltraFechaEnvio.Checked = Publicos.OrganizarEntregaFiltraFechaEnvio
      chbGenerarRepartoPermiteDistintasFechasEnvio.Checked = Reglas.Publicos.OrganizarEntregaPermiteDistintaFechaEnvio
      txtOrganizarEntregaFiltroFechaDesde.Text = Reglas.Publicos.OrganizarEntregaFiltroFechaDesde.ToString()


      'Consolidado de Carga
      chbConsolidadoCargaOrdenIdProducto.Checked = Reglas.Publicos.Logistica.ConsolidadoCargaOrdenIdProducto


      'Registración de Pagos contra Entrega
      cmbRegistracionPagosTipoMovimiento.SelectedValue = Reglas.Publicos.RegistracionPagosTipoMovimiento
      cmbRegistracionPagosModoConsultarComprobantes.SelectedValue = Reglas.Publicos.RegistracionPagosModoConsultarComprobantes


   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Logistica
      'Generar Archivos
      If Not IO.Directory.Exists(txtDestinoArchivosParaMoviles.Text) Then
         IO.Directory.CreateDirectory(txtDestinoArchivosParaMoviles.Text)
      End If
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.LOGISTICAFORMATOEXPORTACIONDEFAULT, cmbFormatoExportacion1, Nothing, lblFormatoExportacion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.EXPORTARPRECIOSCONIVA1, chbExportarPreciosConIVA1, Nothing, chbExportarPreciosConIVA1.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.INCLUIRESCAMBIABLEESBONIFICABLE, chbIncluirEsCambiableEsBonificable, Nothing, chbIncluirEsCambiableEsBonificable.Text)


      'Preventa
      ActualizarParametro(Entidades.Parametro.Parametros.PREVENTAV2IMPORTADESCUENTOSPEDIDOSPDA, chbPreventaV2ImportaDescuentosPedidosPDA, Nothing, chbPreventaV2ImportaDescuentosPedidosPDA.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PREVENTAV2IMPORTADESCUENTOSSIMOVILWEB, chbPreventaV2ImportaDescuentosSiMovilWeb, Nothing, chbPreventaV2ImportaDescuentosSiMovilWeb.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.PREVENTAIMPRIMIRPEDIDOS, cmbPreventaImprimirPedidos, Nothing, lblPreventaImprimirPedidos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PREVENTAV2RESPETALISTAPRECIOSCLIENTE, chbPreventaV2RespetaListaPreciosCliente, Nothing, chbPreventaV2RespetaListaPreciosCliente.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PREVENTARESPETAPRECIODELMOVIL, chbPreventaRespetaPrecioDelMovil, Nothing, chbPreventaRespetaPrecioDelMovil.Text)
      If cmbPreVentaAccionSinListaPrecios.SelectedIndex > -1 Then
         ActualizarParametro(Of Entidades.PreVenta.AccionSinListaPrecios)(Entidades.Parametro.Parametros.PREVENTAACCIONSINLISTAPRECIOS, cmbPreVentaAccionSinListaPrecios, Nothing, lblPreVentaAccionSinListaPrecios.Text)
      Else
         ActualizarParametroTexto(Entidades.Parametro.Parametros.PREVENTAACCIONSINLISTAPRECIOS, Entidades.PreVenta.AccionSinListaPrecios.CargaManual.ToString(), Nothing, lblPreVentaAccionSinListaPrecios.Text)
      End If
      ActualizarParametro(Entidades.Parametro.Parametros.PREVENTAAGRUPAORDENPRODUCTOENCADAPEDIDO, chbPreVentaAgrupaOrdenProductoEnCadaPedido, Nothing, chbPreVentaAgrupaOrdenProductoEnCadaPedido.Text)


      'Organizar Entrega
      If cboFormasPagoOrgEntregas.ValorSeleccionado(Of Integer) > 0 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.ORGANIZARENTREGASFORMADEPAGO, cboFormasPagoOrgEntregas, Nothing, cboFormasPagoOrgEntregas.LabelAsoc.Text)
      End If
      ActualizarParametro(Of Entidades.Publicos.SiNoTodos)(Entidades.Parametro.Parametros.ORGANIZARENTREGAFILTROIMPRESO, cmbOrganizarEntregaFiltroImpreso, Nothing, lblOrganizarEntregaFiltroImpreso.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ORGANIZARENTREGAFILTRAFECHAENVIO, chbOrganizarEntregaFiltraFechaEnvio, Nothing, chbOrganizarEntregaFiltraFechaEnvio.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ORGANIZARENTREGAPERMITEDISTINTAFECHAENVIO, chbGenerarRepartoPermiteDistintasFechasEnvio, Nothing, chbGenerarRepartoPermiteDistintasFechasEnvio.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ORGANIZARENTREGAFILTROFECHADESDE, txtOrganizarEntregaFiltroFechaDesde, Nothing, lblOrganizarEntregaFiltroFechaDesde.Text)


      'Consolidado de Carga
      ActualizarParametro(Entidades.Parametro.Parametros.CONSOLIDADOCARGAORDENIDPRODUCTO, chbConsolidadoCargaOrdenIdProducto, Nothing, chbConsolidadoCargaOrdenIdProducto.Text)


      'Registración de Pagos contra Entrega
      Dim valor1 = String.Empty
      If cmbRegistracionPagosTipoMovimiento.SelectedValue IsNot Nothing Then valor1 = cmbRegistracionPagosTipoMovimiento.SelectedValue.ToString()
      ActualizarParametroTexto(Entidades.Parametro.Parametros.REGISTRACIONPAGOSTIPOMOVIMIENTO, valor1, Nothing, lblRegistracionPagosTipoMovimiento.Text)

      If cmbRegistracionPagosModoConsultarComprobantes.SelectedIndex > -1 Then
         ActualizarParametro(Of Entidades.RegistracionPagos.ModoConsultarComprobantes)(Entidades.Parametro.Parametros.REGISTRACIONPAGOSMODOCONSULTARCOMPROBANTES, cmbRegistracionPagosModoConsultarComprobantes, Nothing, lblRegistracionPagosModoConsultarComprobantes.Text)
      End If


   End Sub

   Private Sub cmdDestinoArchivosParaMovilesExaminar_Click(sender As Object, e As EventArgs) Handles cmdDestinoArchivosParaMovilesExaminar.Click

      Using dialogo = New FolderBrowserDialog()
         dialogo.RootFolder = Environment.SpecialFolder.Desktop
         If dialogo.ShowDialog() = DialogResult.OK Then
            txtDestinoArchivosParaMoviles.Text = dialogo.SelectedPath
         End If
      End Using

   End Sub

End Class