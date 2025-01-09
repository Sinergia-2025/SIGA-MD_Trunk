Partial Class Publicos
   Public Shared ReadOnly Property OcultarProductosInactivosABMProductos() As Boolean
      Get
         Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.OCULTARPRODUCTOSINACTIVOSABMPRODUCTOS, False)
      End Get
   End Property

End Class
