Partial Class Publicos
   Public Class DetallePedido
      Public Shared ReadOnly Property PedidosMostrarTamano() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARTAMANO, False)
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarUM() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARUM, False)
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarCosto() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARCOSTO, False)
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarPrecioVentaPorTamano() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRECIOVENTAPORTAMANO, False)
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMonedaPrecioVentaPorTamano() As Integer
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMONEDAPRECIOVENTAPORTAMANO, 1I)
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarMoneda() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARMONEDA, False)
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarSemaforoRentabilidadDetalle() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARSEMAFORORENTABILIDADDETALLE, False)
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarUrlPlanoDetalle() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARURLPLANODETALLE, False)
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarFormula() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARFORMULA, False)
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarNota() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARNOTA, False)
         End Get
      End Property
      Public Shared ReadOnly Property PedidosMostrarPrecioMasIva() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRECIOMASIVA, False)
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarProductoEspmm() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOESPMM, False)
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarProductoEspPulgadas() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOESPPULGADAS, False)
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarProductoSAE() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOSAE, False)
         End Get
      End Property
      Public Shared ReadOnly Property PedidosMostrarProductoProduccionProceso() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOPRODUCCIONPROCESO, False)
         End Get
      End Property
      Public Shared ReadOnly Property PedidosMostrarProductoProduccionForma() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOPRODUCCIONFORMA, False)
         End Get
      End Property
      Public Shared ReadOnly Property PedidosMostrarProductoLargoExtAlto() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOLARGOEXTALTO, False)
         End Get
      End Property
      Public Shared ReadOnly Property PedidosMostrarProductoAnchoIntBase() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOANCHOINTBASE, False)
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarProductoArchitrave() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOARCHITRAVE, False)
         End Get
      End Property
      Public Shared ReadOnly Property PedidosMostrarProductoModeloForma() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOMODELOFORMA, False)
         End Get
      End Property
   End Class

End Class