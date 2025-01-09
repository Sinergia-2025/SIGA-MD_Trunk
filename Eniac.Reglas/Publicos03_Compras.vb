Partial Class Publicos
   Public Class Compras
      Public Shared ReadOnly Property ComprasPrecioCosto() As Entidades.Publicos.ComprasPrecioCosto
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.COMPRASPRECIOCOSTO, Entidades.Publicos.ComprasPrecioCosto.ACTUAL.ToString()).StringToEnum(Entidades.Publicos.ComprasPrecioCosto.ACTUAL)
         End Get
      End Property

      Public Shared ReadOnly Property ComprasImpresionVisualizaNrosSerie() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.COMPRASIMPRESIONVISNROSERIE, True)
         End Get
      End Property
      Public Shared ReadOnly Property ComprasVisualizaCodigoProveedor() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.VISUALIZACODIGOPROVEEDOR, False)
         End Get
      End Property
      Public Shared ReadOnly Property ComprasVisualizaPorcVarCosto() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.VISUALIZAPORCVARCOSTO, False)
         End Get
      End Property
      Public Shared ReadOnly Property ComprasPosicionarNombreProducto() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.COMPRASPOSICIONARNOMBREPRODUCTO, False)
         End Get
      End Property


      Public Class Redondeo
         Public Shared ReadOnly Property ComprasDecimalesRedondeoEnPrecio() As Integer
            Get
               Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.COMPRASDECIMALESREDONDEOENPRECIO, 4I)
            End Get
         End Property

         Public Shared ReadOnly Property ComprasDecimalesEnPrecio() As Integer
            Get
               Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.COMPRASDECIMALESENPRECIO, 2I)
            End Get
         End Property

         Public Shared ReadOnly Property ComprasDecimalesEnTotalXProducto() As Integer
            Get
               Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.COMPRASDECIMALESENTOTALXPRODUCTO, 2I)
            End Get
         End Property

         Public Shared ReadOnly Property ComprasDecimalesRedondeoEnCantidad() As Integer
            Get
               Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.COMPRASDECIMALESREDONDEOENCANTIDAD, 2I)
            End Get
         End Property

         Public Shared ReadOnly Property ComprasDecimalesMostrarEnCantidad() As Integer
            Get
               Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.COMPRASDECIMALESMOSTRARENCANTIDAD, 2I)
            End Get
         End Property

         Public Shared ReadOnly Property ComprasDecimalesEnTotalGeneral() As Integer
            Get
               Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.COMPRASDECIMALESENTOTALGENERAL, 2I)
            End Get
         End Property


      End Class
   End Class
End Class