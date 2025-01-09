Public Class ucConfArchivosProductos
   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboDesdeEnum(cmbProductoFormatoLikeBuscarPorCodigo, GetType(Entidades.Publicos.FormatoLike))
      e.Publicos.CargaComboDesdeEnum(cmbProductoFormatoLikeBuscarPorNombre, GetType(Entidades.Publicos.FormatoLike))

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Archivos - Productos
      txtProductoIVA.Text = Reglas.Publicos.ProductoIVA.ToString()
      chbProductoCodigoNumerico.Checked = Reglas.Publicos.ProductoCodigoNumerico
      chbHABILITACODIGOPRODUCTONUMERICO.Checked = Reglas.Publicos.HabilitaCodigoNumericoProducto
      chbProductoCodigoQuitarBlancos.Checked = Reglas.Publicos.ProductoCodigoQuitarBlancos
      cmbProductoFormatoLikeBuscarPorCodigo.SelectedValue = Reglas.Publicos.ProductoFormatoLikeBuscarPorCodigo
      cmbProductoFormatoLikeBuscarPorNombre.SelectedValue = Reglas.Publicos.ProductoFormatoLikeBuscarPorNombre
      chbProductoBusquedaCombinaCodigoNombre.Checked = Reglas.Publicos.ProductoBusquedaCombinaCodigoNombre
      chbProductoBuscarPorCodigoExacto.Checked = Reglas.Publicos.ProductoBuscarPorCodigoExacto
      chbBuscarProductoPorCodigoProveedorHabitual.Checked = Reglas.Publicos.BuscaProductoPorProveedorHabitual
      chkProductoUtilizaCodigoLargo.Checked = Reglas.Publicos.ProductoUtilizaCodigoLargo
      chbProductoUtilizaNombreCorto.Checked = Reglas.Publicos.ProductoUtilizaNombreCorto
      chbProductoUtilizaCantidadesEnteras.Checked = Reglas.Publicos.ProductoUtilizaCantidadesEnteras
      chbProductoCodigoDeBarras.Checked = Reglas.Publicos.ProductoUtilizaCodigoDeBarras
      chbProductoEmbalajeInverso.Checked = Reglas.Publicos.ProductoEmbalajeInverso
      chbProductoUtilizaProductoWeb.Checked = Reglas.Publicos.ProductoUtilizaProductoWeb


      chbEditaProductoModificaHistorial.Checked = Reglas.Publicos.EditaProductoNormalModificaHistorial
      chbProductoPermiteEsCambiable.Checked = Reglas.Publicos.ProductoPermiteEsCambiable
      chbProductoPermiteEsBonificable.Checked = Reglas.Publicos.ProductoPermiteEsBonificable
      '-- REQ-43595.- ------------------------------------------------------------------------------------------------
      chbProductoPermiteEsDevolucion.Checked = Reglas.Publicos.ProductoPermiteEsDevolucion
      '---------------------------------------------------------------------------------------------------------------
      txtUbicacionProductoPorDefecto.Text = Reglas.Publicos.ProductoUbicacionPorDefecto
      txtCantidadCaracteresProductoObservacion.Text = Reglas.Publicos.CantidadCaracteresProductoObservacion.ToString()
      txtCaracteresProductoCBPesoCantidad.Text = Reglas.Publicos.CaracteresProductoCBPesoCantidad.ToString()

      chbWebCarrito.Checked = Reglas.Publicos.ProductoPublicarWebCarrito
      chbTiendaNube.Checked = Reglas.Publicos.ProductoPublicarTiendaNube
      chbMercadoLibre.Checked = Reglas.Publicos.ProductoPublicarMercadoLibre
      chbArborea.Checked = Reglas.Publicos.ProductoPublicarArborea
      chbBalanza.Checked = Reglas.Publicos.ProductoPublicarBalanza
      chbListaPreciosClientes.Checked = Reglas.Publicos.ProductoPublicarListaPrecioClientes
      chbAppGestión.Checked = Reglas.Publicos.ProductoPublicarAppGestion
      chbSincronizacionSucursal.Checked = Reglas.Publicos.ProductoPublicarSincronizacionSucursal
      chbAppEmpresarial.Checked = Reglas.Publicos.ProductoPublicarAppEmpresarial


      txtProductosCantidadComprasSolapaCompras.Text = Reglas.Publicos.ProductosCantidadComprasSolapaCompras.ToString()
      chkOcultarProductosInactivosABMProductos.Checked = Reglas.Publicos.OcultarProductosInactivosABMProductos

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Archivos - Productos
      ActualizarParametro(Entidades.Parametro.Parametros.ProductoIVA, txtProductoIVA, Nothing, lblProductoIVA.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOCODIGONUMERICO, chbProductoCodigoNumerico, Nothing, chbProductoCodigoNumerico.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.HABILITACODIGOPRODUCTONUMERICO, chbHABILITACODIGOPRODUCTONUMERICO, Nothing, chbHABILITACODIGOPRODUCTONUMERICO.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOCODIGOQUITARBLANCOS, chbProductoCodigoQuitarBlancos, Nothing, chbProductoCodigoQuitarBlancos.Text)
      ActualizarParametro(Of Entidades.Publicos.FormatoLike)(Entidades.Parametro.Parametros.PRODUCTOFORMATOLIKEBUSCARPORCODIGO, cmbProductoFormatoLikeBuscarPorCodigo, Nothing, lblProductoFormatoLikeBuscarPorCodigo.Text)
      ActualizarParametro(Of Entidades.Publicos.FormatoLike)(Entidades.Parametro.Parametros.PRODUCTOFORMATOLIKEBUSCARPORNOMBRE, cmbProductoFormatoLikeBuscarPorNombre, Nothing, lblProductoFormatoLikeBuscarPorNombre.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOBUSQUEDACOMBINACODIGONOMBRE, chbProductoBusquedaCombinaCodigoNombre, Nothing, chbProductoBusquedaCombinaCodigoNombre.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOBUSCARPORCODIGOEXACTO, chbProductoBuscarPorCodigoExacto, Nothing, chbProductoBuscarPorCodigoExacto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.BUSCAPRODUCTOPORCODIGOPROVEEDORHABITUAL, chbBuscarProductoPorCodigoProveedorHabitual, Nothing, chbBuscarProductoPorCodigoProveedorHabitual.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOUTILIZACODIGOLARGO, chkProductoUtilizaCodigoLargo, Nothing, chkProductoUtilizaCodigoLargo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOUTILIZANOMBRECORTO, chbProductoUtilizaNombreCorto, Nothing, chbProductoUtilizaNombreCorto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOUTILIZACANTIDADESENTERAS, chbProductoUtilizaCantidadesEnteras, Nothing, chbProductoUtilizaCantidadesEnteras.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOUTILIZACODIGODEBARRAS, chbProductoCodigoDeBarras, Nothing, chbProductoCodigoDeBarras.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOUTILIZAEMBALAJEARRIBA, chbProductoEmbalajeInverso, Nothing, chbProductoEmbalajeInverso.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOUTILIZAPRODUCTOWEB, chbProductoUtilizaProductoWeb, Nothing, chbProductoUtilizaProductoWeb.Text)


      ActualizarParametro(Entidades.Parametro.Parametros.EDITAPRODUCTONORMALMODIFICAHISTORIAL, chbEditaProductoModificaHistorial, Nothing, chbEditaProductoModificaHistorial.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOPERMITEESCAMBIABLE, chbProductoPermiteEsCambiable, Nothing, chbProductoPermiteEsCambiable.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOPERMITEESBONIFICABLE, chbProductoPermiteEsBonificable, Nothing, chbProductoPermiteEsBonificable.Text)
      '-- REQ-43595.- ------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOPERMITEESDEVUELTO, chbProductoPermiteEsDevolucion, Nothing, chbProductoPermiteEsDevolucion.Text)
      '---------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOUBICACIONPORDEFECTO, txtUbicacionProductoPorDefecto, Nothing, lblUbicacionPorDefecto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CANTIDADCARACTERESPRODUCTOOBSERVACION, txtCantidadCaracteresProductoObservacion, Nothing, lblCaracterProductoObservacion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CARACTERESPRODUCTOCBPESOCANTIDAD, txtCaracteresProductoCBPesoCantidad, Nothing, lblCaracterProductoObservacion.Text)


      'PE-31388
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOPUBLICARWEBCARRITO, chbWebCarrito, Nothing, chbWebCarrito.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOPUBLICARTIENDANUBE, chbTiendaNube, Nothing, chbTiendaNube.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOPUBLICARMERCADOLIBRE, chbMercadoLibre, Nothing, chbMercadoLibre.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOPUBLICARARBOREA, chbArborea, Nothing, chbArborea.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOPUBLICARBALANZA, chbBalanza, Nothing, chbBalanza.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOPUBLICARLISTAPRECIOCLIENTES, chbListaPreciosClientes, Nothing, chbListaPreciosClientes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOPUBLICARAPPGESTION, chbAppGestión, Nothing, chbAppGestión.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOPUBLICARSINCRONIZACIONSUCURSAL, chbSincronizacionSucursal, Nothing, chbSincronizacionSucursal.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOPUBLICARAPPEMPRESARIAL, chbAppEmpresarial, Nothing, chbAppEmpresarial.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOSCANTIDADCOMPRASSOLAPACOMPRAS, txtProductosCantidadComprasSolapaCompras, Nothing, lblProductosCantidadComprasSolapaCompras.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.OCULTARPRODUCTOSINACTIVOSABMPRODUCTOS, chkOcultarProductosInactivosABMProductos, Nothing, chkOcultarProductosInactivosABMProductos.Text)

   End Sub

   Protected Overrides Sub OnValidando(e As ValidacionEventArgs)
      MyBase.OnValidando(e)

      If txtCaracteresProductoCBPesoCantidad.ValorNumericoPorDefecto(0I) > 7 Or
         txtCaracteresProductoCBPesoCantidad.ValorNumericoPorDefecto(0I) < 5 Then
         e.AgregarError("Caracteres para el código de producto en cód. de barra con PRECIO/CANTIDAD debe ser entre 5 y 7")
         txtCaracteresProductoCBPesoCantidad.Focus()
      End If

   End Sub

End Class