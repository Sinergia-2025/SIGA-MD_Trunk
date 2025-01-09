Public Class ucConfArchivosWeb

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboDesdeEnum(cmbProductosPublicarEnWeb, GetType(Entidades.Publicos.SiNoTodos))

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Archivos - WEB
      txtWebArchivosCarpetaExportacion.Text = Reglas.Publicos.WebArchivos.CarpetaExportacion

      txtWebArchivosClientesUrlDelete.Text = Reglas.Publicos.WebArchivos.Clientes.UrlDELETE
      txtWebArchivosClientesUrlGet.Text = Reglas.Publicos.WebArchivos.Clientes.UrlGET
      txtWebArchivosClientesUrlGetMaxFecha.Text = Reglas.Publicos.WebArchivos.Clientes.UrlGETMaxFecha
      txtWebArchivosClientesUrlGetCount.Text = Reglas.Publicos.WebArchivos.Clientes.UrlGETCount
      txtWebArchivosClientesUrlPost.Text = Reglas.Publicos.WebArchivos.Clientes.UrlPOST
      txtWebArchivosClientesTamanoPaginaPost.Text = Reglas.Publicos.WebArchivos.Clientes.TamanoPaginaPost.ToString()
      txtWebArchivosClientesTamanoPaginaGet.Text = Reglas.Publicos.WebArchivos.Clientes.TamanoPaginaGet.ToString()

      txtWebArchivosProductosUrlDelete.Text = Reglas.Publicos.WebArchivos.Productos.UrlDELETE
      txtWebArchivosProductosUrlGet.Text = Reglas.Publicos.WebArchivos.Productos.UrlGET
      txtWebArchivosProductosUrlGetMaxFecha.Text = Reglas.Publicos.WebArchivos.Productos.UrlGETMaxFecha
      txtWebArchivosProductosUrlGetCount.Text = Reglas.Publicos.WebArchivos.Productos.UrlGETCount
      txtWebArchivosProductosUrlPost.Text = Reglas.Publicos.WebArchivos.Productos.UrlPOST
      txtWebArchivosProductosTamanoPaginaPost.Text = Reglas.Publicos.WebArchivos.Productos.TamanoPaginaPost.ToString()
      txtWebArchivosProductosTamanoPaginaGet.Text = Reglas.Publicos.WebArchivos.Productos.TamanoPaginaGet.ToString()

      cmbProductosPublicarEnWeb.SelectedValue = Reglas.Publicos.WebArchivos.Productos.PublicarEnWeb
      chbProductosIncluirImagenes.Checked = Reglas.Publicos.WebArchivos.Productos.IncluirImagenes


      txtWebArchivosProductosSucursalUrlDelete.Text = Reglas.Publicos.WebArchivos.ProductosSucursales.UrlDELETE
      txtWebArchivosProductosSucursalUrlGet.Text = Reglas.Publicos.WebArchivos.ProductosSucursales.UrlGET
      txtWebArchivosProductosSucursalUrlGetMaxFecha.Text = Reglas.Publicos.WebArchivos.ProductosSucursales.UrlGETMaxFecha
      txtWebArchivosProductosSucursalUrlGetCount.Text = Reglas.Publicos.WebArchivos.ProductosSucursales.UrlGETCount
      txtWebArchivosProductosSucursalUrlPost.Text = Reglas.Publicos.WebArchivos.ProductosSucursales.UrlPOST
      txtWebArchivosProductosSucursalTamanoPaginaPost.Text = Reglas.Publicos.WebArchivos.ProductosSucursales.TamanoPaginaPost.ToString()
      txtWebArchivosProductosSucursalTamanoPaginaGet.Text = Reglas.Publicos.WebArchivos.ProductosSucursales.TamanoPaginaGet.ToString()
      chbWebArchivosProductosActualizaStockEstoyAca.Checked = Reglas.Publicos.WebArchivos.ProductosSucursales.ActualizaStockEstoyAca

      txtWebArchivosProductosSucursalesPreciosUrlDelete.Text = Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.UrlDELETE
      txtWebArchivosProductosSucursalesPreciosUrlGet.Text = Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.UrlGET
      txtWebArchivosProductosSucursalesPreciosUrlGetMaxFecha.Text = Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.UrlGETMaxFecha
      txtWebArchivosProductosSucursalesPreciosUrlGetCount.Text = Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.UrlGETCount
      txtWebArchivosProductosSucursalesPreciosUrlPost.Text = Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.UrlPOST
      txtWebArchivosProductosSucursalesPreciosTamanoPaginaPost.Text = Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.TamanoPaginaPost.ToString()
      txtWebArchivosProductosSucursalesPreciosTamanoPaginaGet.Text = Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.TamanoPaginaGet.ToString()


      txtWebArchivosLocalidadesUrlDelete.Text = Reglas.Publicos.WebArchivos.Localidades.UrlDELETE
      txtWebArchivosLocalidadesUrlGet.Text = Reglas.Publicos.WebArchivos.Localidades.UrlGET
      txtWebArchivosLocalidadesUrlGetMaxFecha.Text = Reglas.Publicos.WebArchivos.Localidades.UrlGETMaxFecha
      txtWebArchivosLocalidadesUrlGetCount.Text = Reglas.Publicos.WebArchivos.Localidades.UrlGETCount
      txtWebArchivosLocalidadesUrlPost.Text = Reglas.Publicos.WebArchivos.Localidades.UrlPOST
      txtWebArchivosLocalidadesTamanoPaginaPost.Text = Reglas.Publicos.WebArchivos.Localidades.TamanoPaginaPost.ToString()
      txtWebArchivosLocalidadesTamanoPaginaGet.Text = Reglas.Publicos.WebArchivos.Localidades.TamanoPaginaGet.ToString()

      txtWebArchivosRubrosUrlDelete.Text = Reglas.Publicos.WebArchivos.Rubros.UrlDELETE
      txtWebArchivosRubrosUrlGet.Text = Reglas.Publicos.WebArchivos.Rubros.UrlGET
      txtWebArchivosRubrosUrlGetMaxFecha.Text = Reglas.Publicos.WebArchivos.Rubros.UrlGETMaxFecha
      txtWebArchivosRubrosUrlGetCount.Text = Reglas.Publicos.WebArchivos.Rubros.UrlGETCount
      txtWebArchivosRubrosUrlPost.Text = Reglas.Publicos.WebArchivos.Rubros.UrlPOST
      txtWebArchivosRubrosTamanoPaginaPost.Text = Reglas.Publicos.WebArchivos.Rubros.TamanoPaginaPost.ToString()
      txtWebArchivosRubrosTamanoPaginaGet.Text = Reglas.Publicos.WebArchivos.Rubros.TamanoPaginaGet.ToString()

      txtWebArchivosSubRubrosUrlDelete.Text = Reglas.Publicos.WebArchivos.SubRubros.UrlDELETE
      txtWebArchivosSubRubrosUrlGet.Text = Reglas.Publicos.WebArchivos.SubRubros.UrlGET
      txtWebArchivosSubRubrosUrlGetMaxFecha.Text = Reglas.Publicos.WebArchivos.SubRubros.UrlGETMaxFecha
      txtWebArchivosSubRubrosUrlGetCount.Text = Reglas.Publicos.WebArchivos.SubRubros.UrlGETCount
      txtWebArchivosSubRubrosUrlPost.Text = Reglas.Publicos.WebArchivos.SubRubros.UrlPOST
      txtWebArchivosSubRubrosTamanoPaginaPost.Text = Reglas.Publicos.WebArchivos.SubRubros.TamanoPaginaPost.ToString()
      txtWebArchivosSubRubrosTamanoPaginaGet.Text = Reglas.Publicos.WebArchivos.SubRubros.TamanoPaginaGet.ToString()

      txtWebArchivosSubSubRubrosUrlDelete.Text = Reglas.Publicos.WebArchivos.SubSubRubros.UrlDELETE
      txtWebArchivosSubSubRubrosUrlGet.Text = Reglas.Publicos.WebArchivos.SubSubRubros.UrlGET
      txtWebArchivosSubSubRubrosUrlGetMaxFecha.Text = Reglas.Publicos.WebArchivos.SubSubRubros.UrlGETMaxFecha
      txtWebArchivosSubSubRubrosUrlGetCount.Text = Reglas.Publicos.WebArchivos.SubSubRubros.UrlGETCount
      txtWebArchivosSubSubRubrosUrlPost.Text = Reglas.Publicos.WebArchivos.SubSubRubros.UrlPOST
      txtWebArchivosSubSubRubrosTamanoPaginaPost.Text = Reglas.Publicos.WebArchivos.SubSubRubros.TamanoPaginaPost.ToString()
      txtWebArchivosSubSubRubrosTamanoPaginaGet.Text = Reglas.Publicos.WebArchivos.SubSubRubros.TamanoPaginaGet.ToString()

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Archivos - WEB
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSCARPETAEXPORTACION, txtWebArchivosCarpetaExportacion, "WEB-ARCHIVOS", lblWebArchivosCarpetaExportacion.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSCLIENTESURLDELETE, txtWebArchivosClientesUrlDelete, "WEB-ARCHIVOS", lblWebArchivosClientesUrlDelete.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSCLIENTESURLGET, txtWebArchivosClientesUrlGet, "WEB-ARCHIVOS", lblWebArchivosClientesUrlGet.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSCLIENTESURLGETMAXFECHA, txtWebArchivosClientesUrlGetMaxFecha, "WEB-ARCHIVOS", lblWebArchivosClientesUrlGetMaxFecha.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSCLIENTESURLGETCOUNT, txtWebArchivosClientesUrlGetCount, "WEB-ARCHIVOS", lblWebArchivosClientesUrlGetCount.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSCLIENTESURLPOST, txtWebArchivosClientesUrlPost, "WEB-ARCHIVOS", lblWebArchivosClientesUrlPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSCLIENTESTAMANOPAGINAPOST, txtWebArchivosClientesTamanoPaginaPost, "WEB-ARCHIVOS", lblWebArchivosClientesTamanoPaginaPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSCLIENTESTAMANOPAGINAGET, txtWebArchivosClientesTamanoPaginaGet, "WEB-ARCHIVOS", lblWebArchivosClientesTamanoPaginaGet.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODUCTOSURLDELETE, txtWebArchivosProductosUrlDelete, "WEB-ARCHIVOS", lblWebArchivosProductosUrlDelete.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODUCTOSURLGET, txtWebArchivosProductosUrlGet, "WEB-ARCHIVOS", lblWebArchivosProductosUrlGet.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODUCTOSURLGETMAXFECHA, txtWebArchivosProductosUrlGetMaxFecha, "WEB-ARCHIVOS", lblWebArchivosProductosUrlGetMaxFecha.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODUCTOSURLGETCOUNT, txtWebArchivosProductosUrlGetCount, "WEB-ARCHIVOS", lblWebArchivosProductosUrlGetCount.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODUCTOSURLPOST, txtWebArchivosProductosUrlPost, "WEB-ARCHIVOS", lblWebArchivosProductosUrlPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODUCTOSTAMANOPAGINAPOST, txtWebArchivosProductosTamanoPaginaPost, "WEB-ARCHIVOS", lblWebArchivosProductosTamanoPaginaPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODUCTOSTAMANOPAGINAGET, txtWebArchivosProductosTamanoPaginaGet, "WEB-ARCHIVOS", lblWebArchivosProductosTamanoPaginaGet.Text)

      ActualizarParametro(Of Entidades.Publicos.SiNoTodos)(Entidades.Parametro.Parametros.WEBARCHIVOSPRODUCTOSPUBLICARENWEB, cmbProductosPublicarEnWeb, "WEB-ARCHIVOS", lblProductosPublicarEnWeb.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODUCTOSINCLUIRIMAGENES, chbProductosIncluirImagenes, "WEB-ARCHIVOS", lblProductosIncluirImagenes.Text)



      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODSUCURURLDELETE, txtWebArchivosProductosSucursalUrlDelete, "WEB-ARCHIVOS", lblWebArchivosProductosSucursalUrlDelete.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODSUCURURLGET, txtWebArchivosProductosSucursalUrlGet, "WEB-ARCHIVOS", lblWebArchivosProductosSucursalUrlGet.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODSUCURURLGETMAXFECHA, txtWebArchivosProductosSucursalUrlGetMaxFecha, "WEB-ARCHIVOS", lblWebArchivosProductosSucursalUrlGetMaxFecha.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODSUCURURLGETCOUNT, txtWebArchivosProductosSucursalUrlGetCount, "WEB-ARCHIVOS", lblWebArchivosProductosSucursalUrlGetCount.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODSUCURURLPOST, txtWebArchivosProductosSucursalUrlPost, "WEB-ARCHIVOS", lblWebArchivosProductosSucursalUrlPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODSUCURTAMANOPAGINAPOST, txtWebArchivosProductosSucursalTamanoPaginaPost, "WEB-ARCHIVOS", lblWebArchivosProductosSucursalTamanoPaginaPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODSUCURTAMANOPAGINAGET, txtWebArchivosProductosSucursalTamanoPaginaGet, "WEB-ARCHIVOS", lblWebArchivosProductosSucursalTamanoPaginaGet.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODSUCURACTUALIZASTOCKESTOYACA, chbWebArchivosProductosActualizaStockEstoyAca, "WEB-ARCHIVOS", chbWebArchivosProductosActualizaStockEstoyAca.Text)


      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODSUCURPRECIOSURLDELETE, txtWebArchivosProductosSucursalesPreciosUrlDelete, "WEB-ARCHIVOS", lblWebArchivosProductosSucursalesPreciosUrlDelete.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODSUCURPRECIOSURLGET, txtWebArchivosProductosSucursalesPreciosUrlGet, "WEB-ARCHIVOS", lblWebArchivosProductosSucursalesPreciosUrlGet.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODSUCURPRECIOSURLGETMAXFECHA, txtWebArchivosProductosSucursalesPreciosUrlGetMaxFecha, "WEB-ARCHIVOS", lblWebArchivosProductosSucursalesPreciosUrlGetMaxFecha.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODSUCURPRECIOSURLGETCOUNT, txtWebArchivosProductosSucursalesPreciosUrlGetCount, "WEB-ARCHIVOS", lblWebArchivosProductosSucursalesPreciosUrlGetCount.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODSUCURPRECIOSURLPOST, txtWebArchivosProductosSucursalesPreciosUrlPost, "WEB-ARCHIVOS", lblWebArchivosProductosSucursalesPreciosUrlPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODSUCURPRECIOSTAMANOPAGINAPOST, txtWebArchivosProductosSucursalesPreciosTamanoPaginaPost, "WEB-ARCHIVOS", lblWebArchivosProductosSucursalesPreciosTamanoPaginaPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSPRODSUCURPRECIOSTAMANOPAGINAGET, txtWebArchivosProductosSucursalesPreciosTamanoPaginaGet, "WEB-ARCHIVOS", lblWebArchivosProductosSucursalesPreciosTamanoPaginaGet.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSLOCALIDADESURLDELETE, txtWebArchivosLocalidadesUrlDelete, "WEB-ARCHIVOS", lblWebArchivosLocalidadesUrlDelete.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSLOCALIDADESURLGET, txtWebArchivosLocalidadesUrlGet, "WEB-ARCHIVOS", lblWebArchivosLocalidadesUrlGet.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSLOCALIDADESURLGETMAXFECHA, txtWebArchivosLocalidadesUrlGetMaxFecha, "WEB-ARCHIVOS", lblWebArchivosLocalidadesUrlGetMaxFecha.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSLOCALIDADESURLGETCOUNT, txtWebArchivosLocalidadesUrlGetCount, "WEB-ARCHIVOS", lblWebArchivosLocalidadesUrlGetCount.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSLOCALIDADESURLPOST, txtWebArchivosLocalidadesUrlPost, "WEB-ARCHIVOS", lblWebArchivosLocalidadesUrlPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSLOCALIDADESTAMANOPAGINAPOST, txtWebArchivosLocalidadesTamanoPaginaPost, "WEB-ARCHIVOS", lblWebArchivosLocalidadesTamanoPaginaPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSLOCALIDADESTAMANOPAGINAGET, txtWebArchivosLocalidadesTamanoPaginaGet, "WEB-ARCHIVOS", lblWebArchivosLocalidadesTamanoPaginaGet.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSRUBROSURLDELETE, txtWebArchivosRubrosUrlDelete, "WEB-ARCHIVOS", lblWebArchivosRubrosUrlDelete.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSRUBROSURLGET, txtWebArchivosRubrosUrlGet, "WEB-ARCHIVOS", lblWebArchivosRubrosUrlGet.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSRUBROSURLGETMAXFECHA, txtWebArchivosRubrosUrlGetMaxFecha, "WEB-ARCHIVOS", lblWebArchivosRubrosUrlGetMaxFecha.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSRUBROSURLGETCOUNT, txtWebArchivosRubrosUrlGetCount, "WEB-ARCHIVOS", lblWebArchivosRubrosUrlGetCount.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSRUBROSURLPOST, txtWebArchivosRubrosUrlPost, "WEB-ARCHIVOS", lblWebArchivosRubrosUrlPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSRUBROSTAMANOPAGINAPOST, txtWebArchivosRubrosTamanoPaginaPost, "WEB-ARCHIVOS", lblWebArchivosRubrosTamanoPaginaPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSRUBROSTAMANOPAGINAGET, txtWebArchivosRubrosTamanoPaginaGet, "WEB-ARCHIVOS", lblWebArchivosRubrosTamanoPaginaGet.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSUBRUBROSURLDELETE, txtWebArchivosSubRubrosUrlDelete, "WEB-ARCHIVOS", lblWebArchivosSubRubrosUrlDelete.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSUBRUBROSURLGET, txtWebArchivosSubRubrosUrlGet, "WEB-ARCHIVOS", lblWebArchivosSubRubrosUrlGet.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSUBRUBROSURLGETMAXFECHA, txtWebArchivosSubRubrosUrlGetMaxFecha, "WEB-ARCHIVOS", lblWebArchivosSubRubrosUrlGetMaxFecha.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSUBRUBROSURLGETCOUNT, txtWebArchivosSubRubrosUrlGetCount, "WEB-ARCHIVOS", lblWebArchivosSubRubrosUrlGetCount.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSUBRUBROSURLPOST, txtWebArchivosSubRubrosUrlPost, "WEB-ARCHIVOS", lblWebArchivosSubRubrosUrlPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSUBRUBROSTAMANOPAGINAPOST, txtWebArchivosSubRubrosTamanoPaginaPost, "WEB-ARCHIVOS", lblWebArchivosSubRubrosTamanoPaginaPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSUBRUBROSTAMANOPAGINAGET, txtWebArchivosSubRubrosTamanoPaginaGet, "WEB-ARCHIVOS", lblWebArchivosSubRubrosTamanoPaginaGet.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSUBSUBRUBROSURLDELETE, txtWebArchivosSubSubRubrosUrlDelete, "WEB-ARCHIVOS", lblWebArchivosSubSubRubrosUrlDelete.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSUBSUBRUBROSURLGET, txtWebArchivosSubSubRubrosUrlGet, "WEB-ARCHIVOS", lblWebArchivosSubSubRubrosUrlGet.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSUBSUBRUBROSURLGETMAXFECHA, txtWebArchivosSubSubRubrosUrlGetMaxFecha, "WEB-ARCHIVOS", lblWebArchivosSubSubRubrosUrlGetMaxFecha.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSUBSUBRUBROSURLGETCOUNT, txtWebArchivosSubSubRubrosUrlGetCount, "WEB-ARCHIVOS", lblWebArchivosSubSubRubrosUrlGetCount.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSUBSUBRUBROSURLPOST, txtWebArchivosSubSubRubrosUrlPost, "WEB-ARCHIVOS", lblWebArchivosSubSubRubrosUrlPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSUBSUBRUBROSTAMANOPAGINAPOST, txtWebArchivosSubSubRubrosTamanoPaginaPost, "WEB-ARCHIVOS", lblWebArchivosSubSubRubrosTamanoPaginaPost.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSUBSUBRUBROSTAMANOPAGINAGET, txtWebArchivosSubSubRubrosTamanoPaginaGet, "WEB-ARCHIVOS", lblWebArchivosSubSubRubrosTamanoPaginaGet.Text)

   End Sub

End Class
