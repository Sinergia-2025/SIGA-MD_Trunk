Namespace JSonEntidades.Archivos
   Public Class ProductoJSon
      Implements IValidable
      Public Property CuitEmpresa As String
      Public Property IdProducto As String
      Public Property NombreProducto As String
      Public Property Tamano As Decimal
      Public Property IdUnidadDeMedida As String
      Public Property IdMarca As Integer
      Public Property IdRubro As Integer
      Public Property MesesGarantia As Integer
      Public Property Activo As Boolean
      Public Property AfectaStock As Boolean
      Public Property IdModelo As Integer
      Public Property IdSubRubro As Integer
      Public Property Lote As Boolean
      Public Property NroSerie As Boolean
      Public Property IdTipoImpuesto As String
      Public Property Alicuota As Decimal
      Public Property CodigoDeBarras As String
      Public Property EsServicio As Boolean
      Public Property Observacion As String
      Public Property PublicarEnWeb As Boolean
      Public Property PermiteModificarDescripcion As Boolean

      Public Property PublicarEnTiendaNube As Boolean
      Public Property PublicarEnMercadoLibre As Boolean
      Public Property PublicarEnArborea As Boolean
      Public Property PublicarEnGestion As Boolean
      Public Property PublicarEnEmpresarial As Boolean
      Public Property PublicarEnBalanza As Boolean
      Public Property PublicarEnSincronizacionSucursal As Boolean

      Public Property EsDeCompras As Boolean
      Public Property EsDeVentas As Boolean
      Public Property DescontarStockComponentes As Boolean
      Public Property IdMoneda As Integer
      Public Property EsCompuesto As Boolean
      Public Property EsDevuelto As Boolean

      Public Property CodigoDeBarrasConPrecio As Boolean
      Public Property EsAlquilable As Boolean
      Public Property EquipoMarca As String
      Public Property EquipoModelo As String
      Public Property NumeroSerie As String
      Public Property CaractSII As String
      Public Property Anio As Integer
      Public Property Alicuota2 As Decimal
      Public Property PagaIngresosBrutos As Boolean
      Public Property Embalaje As Integer
      Public Property Kilos As Decimal
      Public Property KilosEsUMCompras As Boolean
      Public Property IdFormula As Integer
      Public Property IdProductoMercosur As String
      Public Property IdProductoSecretaria As String
      Public Property PublicarListaDePreciosClientes As Boolean
      Public Property FacturacionCantidadNegativa As Boolean
      Public Property SolicitaEnvase As Boolean
      Public Property AlertaDeCaja As Boolean
      Public Property NombreCorto As String
      Public Property EsRetornable As Boolean
      Public Property Orden As Integer
      Public Property ModalidadCodigoDeBarras As String
      Public Property IdProveedor As Long
      Public Property CodigoLargoProducto As String
      Public Property EsObservacion As Boolean
      Public Property PrecioPorEmbalaje As Boolean
      Public Property UnidHasta1 As Decimal
      Public Property UnidHasta2 As Decimal
      Public Property UnidHasta3 As Decimal
      Public Property UHPorc1 As Decimal
      Public Property UHPorc2 As Decimal
      Public Property UHPorc3 As Decimal
      Public Property IdCuentaCompras As Long
      Public Property IdCuentaVentas As Long
      Public Property ImporteImpuestoInterno As Decimal
      Public Property EsOferta As String
      Public Property IncluirExpensas As Boolean
      Public Property IdCuentaComprasSecundaria As Long
      Public Property IdCentroCosto As Integer
      Public Property UnidHasta4 As Decimal
      Public Property UnidHasta5 As Decimal
      Public Property UHPorc4 As Decimal
      Public Property UHPorc5 As Decimal
      Public Property UHListaPrecios1 As Integer?
      Public Property UHListaPrecios2 As Integer?
      Public Property UHListaPrecios3 As Integer?
      Public Property UHListaPrecios4 As Integer?
      Public Property UHListaPrecios5 As Integer?
      Public Property ObservacionCompras As String
      Public Property SolicitaPrecioVentaPorTamano As Boolean
      Public Property IdProduccionProceso As Integer
      Public Property IdProduccionForma As Integer
      Public Property Espmm As Decimal
      Public Property CodigoSAE As String
      Public Property EspPulgadas As String

      Public Property CalculaPreciosSegunFormula As Boolean
      Public Property IdSubSubRubro As Integer?
      Public Property PorcImpuestoInterno As Decimal
      Public Property OrigenPorcImpInt As Entidades.OrigenesPorcImpInt
      Public Property FechaActualizacionWeb As String
      Public Property EsCambiable As Boolean
      Public Property EsBonificable As Boolean
      Public Property DescRecProducto As Decimal
      Public Property ActualizaPreciosSucursalesAsociadas As Boolean

      Public Property CalidadStatusLiberado As Boolean
      Public Property CalidadFechaLiberado As String
      Public Property CalidadUserLiberado As String
      Public Property CalidadStatusEntregado As Boolean
      Public Property CalidadFechaEntregado As String
      Public Property CalidadUserEntregado As String
      Public Property CalidadFechaIngreso As String
      Public Property CalidadFechaEgreso As String
      Public Property CalidadNroCertificado As Integer
      Public Property CalidadFecCertificado As String
      Public Property CalidadUsrCertificado As String
      Public Property CalidadObservaciones As String
      Public Property CalidadFechaPreEnt As String
      Public Property CalidadFechaEntProg As String
      Public Property EsComercial As Boolean
      Public Property ProductoIdentificacion As List(Of JSonEntidades.Archivos.ProductoIdentificacionJson)
      Public Property ProductoFormula As List(Of JSonEntidades.Archivos.ProductoFormulaJson)
      Public Property ProductoComponente As List(Of JSonEntidades.Archivos.ProductoComponenteJson)

      Public Property Alto As Decimal
      Public Property Ancho As Decimal
      Public Property Largo As Decimal
      Public Property IdUnidadDeMedida2 As String
      Public Property Conversion As Decimal

      Public Property IdUnidadDeMedidaCompra As String
      Public Property FactorConversionCompra As Decimal
      Public Property IdUnidadDeMedidaProduccion As String
      Public Property FactorConversionProduccion As Decimal

      Public Property IdProductoNumerico As Long?
      Public Property EnviarSinCargo As Boolean
      Public Property CodigoProductoTiendaNube As String
      Public Property CodigoProductoArborea As String
      Public Property CodigoProductoMercadoLibre As String
      Public Property IdVarianteProducto As String
      Public Property IdProductoTipoServicio As Integer
      Public Property CalidadNroDeMotor As String
      Public Property CalidadFechaEntReProg As String
      Public Property IdProductoModelo As Integer
      Public Property CalidadNroCertEntregado As Integer
      Public Property CalidadFecCertEntregado As String
      Public Property CalidadUsrCertEntregado As String
      Public Property CalidadStatusLiberadoPDI As Boolean
      Public Property CalidadFechaLiberadoPDI As String
      Public Property CalidadUserLiberadoPDI As String
      Public Property CalidadNroCertEObs As String
      Public Property CalidadNroRemito As Long
      Public Property TipoBonificacion As Entidades.Producto.TiposBonificacionesProductos

      Public Property EsPerceptibleIVARes53292023 As Boolean

      'Por ahora ignoramos la foto. Tenemos que ver cual es la mejor opción 
      'porque puede (y seguramente va a pasar) explotar la interfase por tamaño.
      'Public Property Foto	image

      Public Property ConErrores As Boolean Implements IValidable.ConErrores
      Public Property ___Estado As String Implements IValidable.___Estado
      Public Property ___MensajeError As String Implements IValidable.___MensajeError

      Public Property drOrigen As DataRow Implements IValidable.drOrigen
      Public Property CalidadNumeroChasis As String
      Public Property CalidadNroCarroceria As Integer
      Public Property ComisionPorVenta As Decimal

   End Class

   Public Class ProductoJSonTransporte
      Public Property CuitEmpresa As String
      Public Property IdProducto As String
      Public Property DatosProducto As String
      Public Property FechaActualizacion As String

      Public Sub New()
      End Sub

      Public Sub New(cuitEmpresa As String, idProducto As String, fechaActualizacion As String)
         Me.CuitEmpresa = cuitEmpresa
         Me.IdProducto = idProducto
         Me.FechaActualizacion = fechaActualizacion
      End Sub

   End Class

End Namespace