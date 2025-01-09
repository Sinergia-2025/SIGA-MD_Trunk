Public Class ucConfArborea
   Private Property _Cargando As Boolean = False

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)
      '-- Carga el combo de Tienda Nube.- -----
      e.Publicos.CargaComboCategorias(cmbArboreaCategoriaCliente, False, False)
      e.Publicos.CargaComboCategoriasFiscales(cmbArboreaCategoriaFiscalCliente)
      e.Publicos.CargaComboEmpleados(cmbArboreaVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
      e.Publicos.CargaComboTiposComprobantes(cmbArboreaPedidosTipoComprobante, True, "VENTAS")
      e.Publicos.CargaComboFormasDePago(cmbArboreaPedidosFormaDePago)
      e.Publicos.CargaComboCriticidades(cmbArboreaPedidosCriticidad)
      '------------------------------------------
      '-- Carga el combo de lista de precios.- --
      e.Publicos.CargaComboListasDePrecios(cmbListaPrecio01, seleccionMultiple:=False, seleccionTodos:=False)
      e.Publicos.CargaComboListasDePrecios(cmbListaPrecio02, seleccionMultiple:=False, seleccionTodos:=False)
      e.Publicos.CargaComboListasDePrecios(cmbListaPrecio03, seleccionMultiple:=False, seleccionTodos:=False)
      e.Publicos.CargaComboListasDePrecios(cmbListaPrecio04, seleccionMultiple:=False, seleccionTodos:=False)

      e.Publicos.CargaComboListasDePrecios(cmbListaPrecioCLNuevo, seleccionMultiple:=False, seleccionTodos:=False)
      '-- REQ-36468.- -----------------------------------------------------------------------------------------------------------------------------
      e.Publicos.CargaComboDesdeEnum(cmbActualizaCategorias, GetType(Reglas.Publicos.ActualizarTiendasWeb), , True)
      '-- REQ-37922.- -----------------------------------------------------------------------------------------------------------------------------
      e.Publicos.CargaComboDesdeEnum(cmbPrecioProducto, GetType(Reglas.Publicos.MonedaProductoTiendasWeb), , True)
      '--------------------------------------------------------------------------------------------------------------------------------------------
   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)
      '--------------------------------------------------------------------------------------------------------------------------------------------
      txtArboreaURLBase.Text = Reglas.Publicos.TiendasWeb.Arborea.ArboreaURLBase
      txtArboreaUsuarioToken.Text = Reglas.Publicos.TiendasWeb.Arborea.ArboreaUsuarioToken
      txtArboreaClaveToken.Text = Reglas.Publicos.TiendasWeb.Arborea.ArboreaClaveToken
      txtArboreaCategoriaPrincipal.Text = Reglas.Publicos.TiendasWeb.Arborea.ArboreaCategoriaPrincipal

      txtArboreaCorreoNotificaciones.Text = Reglas.Publicos.TiendasWeb.Arborea.ArboreaCorreoNotificaciones
      txtArboreaProductoEnvio.Text = Reglas.Publicos.TiendasWeb.Arborea.ArboreaIdProductoEnvio

      txtArboreaURLListaPrecios.Text = Reglas.Publicos.TiendasWeb.Arborea.ArboreaURLListaPrecios

      '-- REQ-33743.- ------------------------------------------------------------------------------------------------------------------------------
      txtArboreaURLListaPreciosClientes.Text = Reglas.Publicos.TiendasWeb.Arborea.ArboreaURLListaPreciosClientes
      '---------------------------------------------------------------------------------------------------------------------------------------------

      chbArboreaExportarSolicitudesSubida.Checked = Reglas.Publicos.TiendasWeb.Arborea.ArboreaExportarSolicitudesSubida
      txtArboreaExportarSolicitudesSubidaPath.Text = Reglas.Publicos.TiendasWeb.Arborea.ArboreaExportarSolicitudesSubidaPath


      cmbArboreaCategoriaFiscalCliente.SelectedValue = Reglas.Publicos.TiendasWeb.Arborea.ArboreaCategoriaFiscalCliente

      cmbArboreaCategoriaCliente.SelectedValue = Reglas.Publicos.TiendasWeb.Arborea.ArboreaCategoriaCliente
      cmbArboreaVendedor.SelectedValue = Reglas.Publicos.TiendasWeb.Arborea.ArboreaVendedor
      cmbArboreaPedidosTipoComprobante.SelectedValue = Reglas.Publicos.TiendasWeb.Arborea.ArboreaPedidosTipoComprobante
      cmbArboreaPedidosCriticidad.SelectedValue = Reglas.Publicos.TiendasWeb.Arborea.ArboreaPedidosCriticidad
      cmbArboreaPedidosFormaDePago.SelectedValue = Reglas.Publicos.TiendasWeb.Arborea.ArboreaPedidosFormaDePago
      '--------------------------------------------------------------------------------------------------------------------------------------------
      _Cargando = True
      cmbListaPrecio01.SelectedValue = Reglas.Publicos.TiendasWeb.Arborea.ArboreaListasPrecios01
      cmbListaPrecio02.SelectedValue = Reglas.Publicos.TiendasWeb.Arborea.ArboreaListasPrecios02
      cmbListaPrecio03.SelectedValue = Reglas.Publicos.TiendasWeb.Arborea.ArboreaListasPrecios03
      cmbListaPrecio04.SelectedValue = Reglas.Publicos.TiendasWeb.Arborea.ArboreaListasPrecios04

      _Cargando = False
      If Reglas.Publicos.TiendasWeb.Arborea.ArboreaListasPrecios01 > -1 Then
         chbListaPrecio01.Checked = True
      End If
      If Reglas.Publicos.TiendasWeb.Arborea.ArboreaListasPrecios02 > -1 Then
         chbListaPrecio02.Checked = True
      End If
      If Reglas.Publicos.TiendasWeb.Arborea.ArboreaListasPrecios03 > -1 Then
         chbListaPrecio03.Checked = True
      End If
      If Reglas.Publicos.TiendasWeb.Arborea.ArboreaListasPrecios04 > -1 Then
         chbListaPrecio04.Checked = True
      End If

      cmbListaPrecioCLNuevo.SelectedValue = Reglas.Publicos.TiendasWeb.Arborea.ArboreaListasPreciosCLNuevo
      If Reglas.Publicos.TiendasWeb.Arborea.ArboreaListasPreciosCLNuevo > -1 Then
         chbListaPrecioCLNuevo.Checked = True
      End If


      '-- REQ-36468.- -----------------------------------------------------------------------------------------------------------------------------
      cmbActualizaCategorias.SelectedValue = Reglas.Publicos.ActualizacionCategoriasARB
      cmbPrecioProducto.SelectedValue = Reglas.Publicos.PrecioProductoARB
      '--------------------------------------------------------------------------------------------------------------------------------------------
      chbArboreaSincronizaCategorias.Checked = Reglas.Publicos.TiendasWeb.Arborea.ArboreasincronizaCategorias
      '--------------------------------------------------------------------------------------------------------------------------------------------
      chbImportaMarcas.Checked = Reglas.Publicos.TiendasWeb.Arborea.ArboreaImportaMarcas
      txtImportaMarcas.Enabled = chbImportaMarcas.Checked
      txtImportaMarcas.Text = "0"
      If chbImportaMarcas.Checked Then
         txtImportaMarcas.Text = Reglas.Publicos.TiendasWeb.Arborea.ArboreaImportaMarcasID
      End If
      chbProductoPrecioEmbalaje.Checked = Reglas.Publicos.TiendasWeb.Arborea.ArboreaPrecioPorEmbalaje

      chbPreciosConIvaPV.Checked = Reglas.Publicos.TiendasWeb.Arborea.ArboreaPreciosConIvaPV
      chbPreciosConIvaLP1.Checked = Reglas.Publicos.TiendasWeb.Arborea.ArboreaPreciosConIvaLP1
      chbPreciosConIvaLP2.Checked = Reglas.Publicos.TiendasWeb.Arborea.ArboreaPreciosConIvaLP2
      chbPreciosConIvaLP3.Checked = Reglas.Publicos.TiendasWeb.Arborea.ArboreaPreciosConIvaLP3

   End Sub
   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)
      '--------------------------------------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.ARBOREAURLBASE, txtArboreaURLBase, Nothing, lblArboreaURLBase.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ARBOREAUSUARIOTOKEN, txtArboreaUsuarioToken, Nothing, lblArboreaUsuarioToken.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ARBOREACLAVETOKEN, txtArboreaClaveToken, Nothing, lblArboreaClaveToken.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ARBOREACATEGORIAPRINCIPAL, txtArboreaCategoriaPrincipal, Nothing, lblArboreaCategoriaPrincipal.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.ARBOREAURLLISTAPRECIOS, txtArboreaURLListaPrecios, Nothing, lblArboreaURLListaPrecios.Text)

      '-- REQ-33743.- ------------------------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.ARBOREAURLLISTAPRECIOSCLIENTES, txtArboreaURLListaPreciosClientes, Nothing, lblArboreaURLListaPreciosClientes.Text)
      '---------------------------------------------------------------------------------------------------------------------------------------------

      ActualizarParametro(Entidades.Parametro.Parametros.ARBOREAEXPORTARSOLICITUDESSUBIDA, chbArboreaExportarSolicitudesSubida, Nothing, chbArboreaExportarSolicitudesSubida.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ARBOREAEXPORTARSOLICITUDESSUBIDAPATH, txtArboreaExportarSolicitudesSubidaPath, Nothing, chbArboreaExportarSolicitudesSubida.Text + "Path")

      ActualizarParametro(Entidades.Parametro.Parametros.ARBOREACORREONOTIFICACIONES, txtArboreaCorreoNotificaciones, Nothing, lblArboreaCorreoNotificaciones.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ARBOREAIDPRODUCTOENVIO, txtArboreaProductoEnvio, Nothing, lblArboreaProductoEnvio.Text)
      '-------------------------------------------------------
      If cmbArboreaCategoriaCliente.SelectedIndex > -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.ARBOREACATEGORIACLIENTE, cmbArboreaCategoriaCliente, Nothing, lblArboreaCategoriaCliente.Text)
      End If
      If cmbArboreaCategoriaFiscalCliente.SelectedIndex > -1 Then
         '-- REQ-32999.- ----------------------------------------
         ActualizarParametro(Of Short)(Entidades.Parametro.Parametros.ARBOREACATEGORIAFISCALCLIENTE, cmbArboreaCategoriaFiscalCliente, Nothing, lblArboreaCategoriaFiscalCliente.Text)
      End If
      If cmbArboreaVendedor.SelectedIndex > -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.ARBOREAVENDEDOR, cmbArboreaVendedor, Nothing, lblArboreaVendedor.Text)
      End If
      If cmbArboreaPedidosTipoComprobante.SelectedIndex > -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.ARBOREAPEDIDOSTIPOCOMPROBANTE, cmbArboreaPedidosTipoComprobante, Nothing, lblArboreaPedidosTipoComprobante.Text)
      End If
      If cmbArboreaPedidosCriticidad.SelectedIndex > -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.ARBOREAPEDIDOSCRITICIDAD, cmbArboreaPedidosCriticidad, Nothing, lblArboreaPedidosCriticidad.Text)
      End If
      If cmbArboreaPedidosFormaDePago.SelectedIndex > -1 Then
         '-- REQ-32999.- ----------------------------------------
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.ARBOREAPEDIDOSFORMADEPAGO, cmbArboreaPedidosFormaDePago, Nothing, lblArboreaPedidosFormaDePago.Text)
      End If
      '-- REQ-33384.- ----------------------------------------
      ActualizarParametroClaveTexto(Entidades.Parametro.Parametros.ARBOREALISTAPRECIOS01.ToString(), If(chbListaPrecio01.Checked, cmbListaPrecio01.SelectedValue.ToString(), "-1"), Nothing, chbListaPrecio01.Text)
      ActualizarParametroClaveTexto(Entidades.Parametro.Parametros.ARBOREALISTAPRECIOS02.ToString(), If(chbListaPrecio02.Checked, cmbListaPrecio02.SelectedValue.ToString(), "-1"), Nothing, chbListaPrecio02.Text)
      ActualizarParametroClaveTexto(Entidades.Parametro.Parametros.ARBOREALISTAPRECIOS03.ToString(), If(chbListaPrecio03.Checked, cmbListaPrecio03.SelectedValue.ToString(), "-1"), Nothing, chbListaPrecio03.Text)
      ActualizarParametroClaveTexto(Entidades.Parametro.Parametros.ARBOREALISTAPRECIOS04.ToString(), If(chbListaPrecio04.Checked, cmbListaPrecio04.SelectedValue.ToString(), "-1"), Nothing, chbListaPrecio04.Text)

      ActualizarParametroClaveTexto(Entidades.Parametro.Parametros.ARBOREALISTAPRECIOSCLNUEVO.ToString(), If(chbListaPrecioCLNuevo.Checked, cmbListaPrecioCLNuevo.SelectedValue.ToString(), "-1"), Nothing, chbListaPrecioCLNuevo.Text)

      '--------------------------------------------------------------------------------------------------------------------------------------------
      If cmbActualizaCategorias.SelectedIndex > -1 Then
         '-- REQ-36468.- -------------------------------------------------------------------------------------------------------------------------
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.ARBOREAACTUALIZACATEGORIA, cmbActualizaCategorias, Nothing, lblActualizaCategorias.Text)
      End If
      If cmbPrecioProducto.SelectedIndex > -1 Then
         '-- REQ-36468.- -------------------------------------------------------------------------------------------------------------------------
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.ARBOREAPRECIOPRODUCTO, cmbPrecioProducto, Nothing, lblPrecioProducto.Text)
      End If

      ActualizarParametro(Entidades.Parametro.Parametros.ARBOREASINCRONIZACATEGORIAS, chbArboreaSincronizaCategorias, Nothing, chbArboreaSincronizaCategorias.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.ARBOREAIMPORTAMARCASUBIDA, chbImportaMarcas, Nothing, chbImportaMarcas.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ARBOREAIMPORTAMARCASUBIDAID, txtImportaMarcas, Nothing, txtImportaMarcas.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ARBOREAPRECIOPOREMBALAJE, chbProductoPrecioEmbalaje, Nothing, chbProductoPrecioEmbalaje.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.PRECIOCONIVAINCLUIDOLISTAPV, chbPreciosConIvaPV, Nothing, chbPreciosConIvaPV.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRECIOCONIVAINCLUIDOLISTALP1, chbPreciosConIvaLP1, Nothing, chbPreciosConIvaLP1.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRECIOCONIVAINCLUIDOLISTALP2, chbPreciosConIvaLP2, Nothing, chbPreciosConIvaLP2.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRECIOCONIVAINCLUIDOLISTALP3, chbPreciosConIvaLP3, Nothing, chbPreciosConIvaLP3.Text)

   End Sub

   Private Sub chbListaPrecio01_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaPrecio01.CheckedChanged
      If Not _Cargando Then
         Select Case chbListaPrecio01.Checked
            Case True
               cmbListaPrecio01.Enabled = True
            Case False
               cmbListaPrecio01.Enabled = False
               cmbListaPrecio01.SelectedIndex = -1
         End Select
      End If
   End Sub

   Private Sub chbListaPrecio02_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaPrecio02.CheckedChanged
      If Not _Cargando Then
         Select Case chbListaPrecio02.Checked
            Case True
               cmbListaPrecio02.Enabled = True
            Case False
               cmbListaPrecio02.Enabled = False
               cmbListaPrecio02.SelectedIndex = -1
         End Select
      End If
   End Sub

   Private Sub chbListaPrecio03_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaPrecio03.CheckedChanged
      If Not _Cargando Then
         Select Case chbListaPrecio03.Checked
            Case True
               cmbListaPrecio03.Enabled = True
            Case False
               cmbListaPrecio03.Enabled = False
               cmbListaPrecio03.SelectedIndex = -1
         End Select
      End If
   End Sub

   Private Sub chbListaPrecio04_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaPrecio04.CheckedChanged
      If Not _Cargando Then
         Select Case chbListaPrecio04.Checked
            Case True
               cmbListaPrecio04.Enabled = True
            Case False
               cmbListaPrecio04.Enabled = False
               cmbListaPrecio04.SelectedIndex = -1
         End Select
      End If
   End Sub

   Private Sub chbListaPrecioCLNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaPrecioCLNuevo.CheckedChanged
      If Not _Cargando Then
         Select Case chbListaPrecioCLNuevo.Checked
            Case True
               cmbListaPrecioCLNuevo.Enabled = True
            Case False
               cmbListaPrecioCLNuevo.Enabled = False
               cmbListaPrecioCLNuevo.SelectedIndex = -1
         End Select
      End If
   End Sub

   Private Sub chbImportaMarcas_CheckedChanged(sender As Object, e As EventArgs) Handles chbImportaMarcas.CheckedChanged
      txtImportaMarcas.Text = "0"
      txtImportaMarcas.Enabled = chbImportaMarcas.Checked
      txtImportaMarcas.Focus()
   End Sub
End Class
