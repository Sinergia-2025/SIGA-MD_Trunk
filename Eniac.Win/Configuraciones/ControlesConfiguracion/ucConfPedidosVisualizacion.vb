Public Class ucConfPedidosVisualizacion

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboMonedas1(cmbMonedaPrecioPorTamano)
      '-- REQ-44348.- ---------------------------------------------------------------------------------------------------------------
      e.Publicos.CargaComboDesdeEnum(cmbVisualizaPrecioPedido, GetType(Reglas.Publicos.FormatoVisualizaPrecioDolares), , True)
      '------------------------------------------------------------------------------------------------------------------------------
   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      txtPedidosDecimalesMostrarLargoAncho.Text = Reglas.Publicos.PedidosDecimalesMostrarLargoAncho.ToString()


      chbPedidosMostrarTamano.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarTamano
      chbPedidosMostrarUM.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarUM
      chbPedidosMostrarPrecioVentaPorTamano.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarPrecioVentaPorTamano
      cmbMonedaPrecioPorTamano.SelectedValue = Reglas.Publicos.DetallePedido.PedidosMonedaPrecioVentaPorTamano
      chbPedidosMostrarCosto.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarCosto
      chbPedidosMostrarCriticidad.Checked = Reglas.Publicos.PedidosMostrarCriticidad()
      chbPedidosMostrarMoneda.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarMoneda
      chbPedidosMostrarSemaforoRentabilidadDetalle.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarSemaforoRentabilidadDetalle
      chbProductoEspmm.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarProductoEspmm
      chbProductoEspPulgadas.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarProductoEspPulgadas

      '-- REQ-44348.- ---------------------------------------------------------------------------------------------------------------
      cmbVisualizaPrecioPedido.SelectedValue = Reglas.Publicos.PedidosVisualizaPrecioEnDolares
      '------------------------------------------------------------------------------------------------------------------------------

      chbProductoSAE.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarProductoSAE
      chbProductoProduccionProceso.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarProductoProduccionProceso
      chbProductoProduccionForma.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarProductoProduccionForma
      chbProductoLargoExtAlto.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarProductoLargoExtAlto
      chbProductoAnchoIntBase.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarProductoAnchoIntBase
      chbProductoArchitrave.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarProductoArchitrave
      chbProductoModeloForma.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarProductoModeloForma
      chbPedidosMostrarUrlPlanoDetalle.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarUrlPlanoDetalle
      chbPedidosMostrarFormula.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarFormula
      chbPedidosMostrarNota.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarNota
      chbPedidosMuestraProvHabitual.Checked = Reglas.Publicos.PedidosMuestraProvHabitual
      '-- REQ-44585.- ---------------------------------------------------------------------------------------------------------------
      chbPedidosMuestraTotalMasIVA.Checked = Reglas.Publicos.DetallePedido.PedidosMostrarPrecioMasIva
      '------------------------------------------------------------------------------------------------------------------------------


   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSDECIMALESMOSTRARLARGOANCHO, txtPedidosDecimalesMostrarLargoAncho, Nothing, lblPedidosDecimalesMostrarLargoAncho.Text)


      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARTAMANO, chbPedidosMostrarTamano, Nothing, chbPedidosMostrarTamano.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARUM, chbPedidosMostrarUM, Nothing, chbPedidosMostrarUM.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRECIOVENTAPORTAMANO, chbPedidosMostrarPrecioVentaPorTamano, Nothing, chbPedidosMostrarPrecioVentaPorTamano.Text)
      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.PEDIDOSMONEDAPRECIOVENTAPORTAMANO, cmbMonedaPrecioPorTamano, Nothing, lblMonedaPrecioPorTamano.Text + " " + chbPedidosMostrarPrecioVentaPorTamano.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARCOSTO, chbPedidosMostrarCosto, Nothing, chbPedidosMostrarCosto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARCRITICIDAD, chbPedidosMostrarCriticidad, Nothing, chbPedidosMostrarCriticidad.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARMONEDA, chbPedidosMostrarMoneda, Nothing, chbPedidosMostrarMoneda.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARSEMAFORORENTABILIDADDETALLE, chbPedidosMostrarSemaforoRentabilidadDetalle, Nothing, chbPedidosMostrarSemaforoRentabilidadDetalle.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOESPMM, chbProductoEspmm, Nothing, chbProductoEspmm.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOESPPULGADAS, chbProductoEspPulgadas, Nothing, chbProductoEspPulgadas.Text)

      '-- REQ-44348.- ---------------------------------------------------------------------------------------------------------------
      If cmbVisualizaPrecioPedido.SelectedIndex > -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRECIOSENDOLARES, cmbVisualizaPrecioPedido, Nothing, lblVisualizaPrecioPedido.Text)
      End If
      '------------------------------------------------------------------------------------------------------------------------------

      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOSAE, chbProductoSAE, Nothing, chbProductoSAE.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOPRODUCCIONPROCESO, chbProductoProduccionProceso, Nothing, chbProductoProduccionProceso.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOPRODUCCIONFORMA, chbProductoProduccionForma, Nothing, chbProductoProduccionForma.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOLARGOEXTALTO, chbProductoLargoExtAlto, Nothing, chbProductoLargoExtAlto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOANCHOINTBASE, chbProductoAnchoIntBase, Nothing, chbProductoAnchoIntBase.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOARCHITRAVE, chbProductoArchitrave, Nothing, chbProductoArchitrave.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOMODELOFORMA, chbProductoModeloForma, Nothing, chbProductoModeloForma.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARURLPLANODETALLE, chbPedidosMostrarUrlPlanoDetalle, Nothing, chbPedidosMostrarUrlPlanoDetalle.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARFORMULA, chbPedidosMostrarFormula, Nothing, chbPedidosMostrarFormula.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARNOTA, chbPedidosMostrarNota, Nothing, chbPedidosMostrarNota.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMUESTRAPROVHABITUAL, chbPedidosMuestraProvHabitual, Nothing, chbPedidosMuestraProvHabitual.Text)
      '-- REQ-44585.- ---------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRECIOMASIVA, chbPedidosMuestraTotalMasIVA, Nothing, chbPedidosMuestraTotalMasIVA.Text)
      '------------------------------------------------------------------------------------------------------------------------------


   End Sub

End Class