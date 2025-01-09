Public Class ucConfPedidosProvPedidosProv

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      'TODO: Ver como se va a parametrizar esto
      e.Publicos.CargaComboEstadosPedidos(cmbEstadoPedidoPreVinculacion, False, False, False, False, False, "PEDIDOSCLIE")
      e.Publicos.CargaComboEstadosPedidos(cmbEstadoPedidoPostVinculacion, False, False, False, False, False, "PEDIDOSCLIE")
      e.Publicos.CargaComboEstadosPedidosProv(cmbEstadoPedidoProvPostVinculacion, False, False, False, False, False, "PEDIDOSPROV", Entidades.Publicos.LecturaEscrituraTodos.TODOS)
      e.Publicos.CargaComboEstadosPedidosProv(cmbEstadoPedidoProvPreVinculacion, False, False, False, False, False, "PEDIDOSPROV", Entidades.Publicos.LecturaEscrituraTodos.TODOS)

      e.Publicos.CargaComboEstadosPedidosProv(cmbPedidoProveedorEstadoNuevo, False, False, False, False, False, "PEDIDOSPROV", Entidades.Publicos.LecturaEscrituraTodos.TODOS)
      e.Publicos.CargaComboEstadosPedidosProv(cmbPedidoProveedorEstadoAnulado, False, False, False, False, False, "PEDIDOSPROV", Entidades.Publicos.LecturaEscrituraTodos.TODOS)

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Pedidos Proveedores
      chbPedidosProvPendientesFacturarAutomatico.Checked = Reglas.Publicos.PedidosProvFacturarAutomatico
      chbPedidoProvSinPrecio.Checked = Reglas.Publicos.PedidosProvConProductosEnCero
      chbGenerarPedidosStockSeleccionaTrue.Checked = Reglas.Publicos.GenerarPedidosStockSeleccionaTrue
      chbImpresionMuestraCodigoProveedor.Checked = Reglas.Publicos.ImpresionMuestraCodigoProveedorTrue

      cmbPedidoProveedorEstadoNuevo.SelectedValue = Reglas.Publicos.PedidoProveedorEstadoNuevo
      cmbPedidoProveedorEstadoAnulado.SelectedValue = Reglas.Publicos.PedidoProveedorEstadoAnulado

      chbGeneraPedidoProvModificaPrecioCosto.Checked = Reglas.Publicos.GenerarPedidosProveedorDesdeStockModificaPrecioCosto
      chbPedidosProveedoresConservaOrdenProductos.Checked = Reglas.Publicos.PedidosProveedoresConservaOrdenProductos



      If cmbEstadoPedidoPreVinculacion.Items.Count > 0 Then
         cmbEstadoPedidoPreVinculacion.SelectedValue = Reglas.Publicos.EstadoPedidoPreVinculacion
      End If
      If cmbEstadoPedidoPostVinculacion.Items.Count > 0 Then
         cmbEstadoPedidoPostVinculacion.SelectedValue = Reglas.Publicos.EstadoPedidoPostVinculacion
      End If
      If cmbEstadoPedidoProvPreVinculacion.Items.Count > 0 Then
         cmbEstadoPedidoProvPreVinculacion.SelectedValue = Reglas.Publicos.EstadoPedidoProvPreVinculacion
      End If
      If cmbEstadoPedidoProvPostVinculacion.Items.Count > 0 Then
         cmbEstadoPedidoProvPostVinculacion.SelectedValue = Reglas.Publicos.EstadoPedidoProvPostVinculacion
      End If

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Pedidos Proveedores
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSPROVFACTURARAUTOMATICO, chbPedidosProvPendientesFacturarAutomatico, Nothing, chbPedidosProvPendientesFacturarAutomatico.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSPROVCONPRODUCTOSENCERO, chbPedidoProvSinPrecio, Nothing, chbPedidoProvSinPrecio.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.GENERARPEDIDOSSTOCKSELECCIONATRUE, chbGenerarPedidosStockSeleccionaTrue, Nothing, chbGenerarPedidosStockSeleccionaTrue.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSPROVIMPRESIONMUESTRACODIGOPROV, chbImpresionMuestraCodigoProveedor, Nothing, chbImpresionMuestraCodigoProveedor.Text)

      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.PEDIDOPROVEEDORESTADONUEVO, cmbPedidoProveedorEstadoNuevo, Nothing, grpEstadoPedidoProveedor.Text.Replace("...", lblPedidoProveedorEstadoNuevo.Text))
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.PEDIDOPROVEEDORESTADOANULADO, cmbPedidoProveedorEstadoAnulado, Nothing, grpEstadoPedidoProveedor.Text.Replace("...", lblPedidoProveedorEstadoAnulado.Text))

      ActualizarParametro(Entidades.Parametro.Parametros.GENERAPEDIDOPROVEEDORDESDESTOCKMODIFICAPRECIOCOSTO, chbGeneraPedidoProvModificaPrecioCosto, Nothing, chbGeneraPedidoProvModificaPrecioCosto.Text)
      '-- REG-32599.- -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSPROVEEDORESCONSERVAORDENPRODUCTOS, chbPedidosProveedoresConservaOrdenProductos, Nothing, chbPedidosProveedoresConservaOrdenProductos.Text)


      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.ESTADOPEDIDOPREVINCULACION, cmbEstadoPedidoPreVinculacion, Nothing, lblEstadoPedidoPreVinculacion.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.ESTADOPEDIDOPOSTVINCULACION, cmbEstadoPedidoPostVinculacion, Nothing, lblEstadoPedidoPostVinculacion.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.ESTADOPEDIDOPROVPREVINCULACION, cmbEstadoPedidoProvPreVinculacion, Nothing, lblEstadoPedidoProvPreVinculacion.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.ESTADOPEDIDOPROVPOSTVINCULACION, cmbEstadoPedidoProvPostVinculacion, Nothing, lblEstadoPedidoProvPostVinculacion.Text)

   End Sub

End Class