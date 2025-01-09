Partial Class Publicos
   Public Class DetalleProduccion
      Public Shared ReadOnly Property OrdProdMostrarCosto() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.ORDPRODMOSTRARCOSTO, False)
         End Get
      End Property

      Public Shared ReadOnly Property OrdProdMostrarVenta() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.ORDPRODMOSTRARVENTA, True)
         End Get
      End Property

      Public Shared ReadOnly Property OrdProdMostrarFormula() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.ORDPRODMOSTRARFORMULA, False)
         End Get
      End Property

      Public Shared ReadOnly Property OrdProdMostrarProductoLargoExtAlto() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.ORDPRODMOSTRARPRODUCTOLARGOEXTALTO, False)
         End Get
      End Property
      Public Shared ReadOnly Property OrdProdMostrarProductoAnchoIntBase() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.ORDPRODMOSTRARPRODUCTOANCHOINTBASE, False)
         End Get
      End Property

      Public Shared ReadOnly Property CalcularPrecioVentaPorcentajeFormula() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PRODUCCIONCALCULARPORCENTAJEFORMULA, False)
         End Get
      End Property

      Public Shared ReadOnly Property ImprimirComponentesNecesarios() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.ORDPRODIMPRIMIRCOMPONENTESNECESARIOS, False)
         End Get
      End Property
      Public Shared ReadOnly Property CantidadNecesariaUnitaria() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.ORDPRODCANTIDADNECESARIAUNITARIA, False)
         End Get
      End Property
      Public Shared ReadOnly Property CantidadLineaSeparacion() As Integer
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.ORDPRODCANTIDADLINEASEPARACION, 0I)
         End Get
      End Property

      Public Shared ReadOnly Property OrdProdMostrarProductoArchitrave() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.ORDPRODMOSTRARPRODUCTOARCHITRAVE, False)
         End Get
      End Property

      Public Shared ReadOnly Property OrdProdMostrarProductoModeloForma() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.ORDPRODMOSTRARPRODUCTOMODELOFORMA, False)
         End Get
      End Property

   End Class


End Class