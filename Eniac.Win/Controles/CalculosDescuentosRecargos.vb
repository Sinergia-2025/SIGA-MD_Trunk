Option Strict On
Option Explicit On
Public Class CalculosDescuentosRecargos
   Private _Cache As Reglas.BusquedasCacheadas
   Public Property Cache() As Reglas.BusquedasCacheadas
      Get
         Return _Cache
      End Get
      Private Set(ByVal value As Reglas.BusquedasCacheadas)
         _Cache = value
      End Set
   End Property

   Private _inicializado As Boolean = False
   Public ReadOnly Property Inicializado As Boolean
      Get
         Return _inicializado
      End Get
   End Property
   Private Property Regla As Reglas.CalculosDescuentosRecargos

   Public Event ReporteEstado(sender As Object, e As CalculosDescuentosRecargosReporteEstadoEventArgs)

   Public Property HabilitaDescuentoRecargoProducto As Boolean = True

   Public Sub Inicializar(cache As Reglas.BusquedasCacheadas)
      Me.Cache = cache

      Regla = New Reglas.CalculosDescuentosRecargos(cache)
      _inicializado = True
   End Sub

   Public Sub Inicializar()
      Dim Cache As Reglas.BusquedasCacheadas = New Reglas.BusquedasCacheadas()

      OnReporteEstado("Inicializando Cache Categorias")
      Cache.InicializaCacheCategorias()
      OnReporteEstado("Inicializando Cache Rubros")
      Cache.InicializaCacheRubros()
      OnReporteEstado("Inicializando Cache SubRubros")
      Cache.InicializaCacheSubRubrosEntidad()

      OnReporteEstado("Inicializando Cache Descuentos Cliente/Rubros")
      Cache.InicializaCacheClienteDescuentosRubros()
      OnReporteEstado("Inicializando Cache Descuentos Cliente/SubRubros")
      Cache.InicializaCacheClienteDescuentosSubRubros()
      OnReporteEstado("Inicializando Cache Descuentos Cliente/Marcas")
      Cache.InicializaCacheClienteDescuentosMarcas()
      OnReporteEstado("Inicializando Cache Descuentos Cliente/Productos")
      Cache.InicializaCacheClienteDescuentosProductos()

      OnReporteEstado("Inicializando Cache Descuentos Categoria/Rubros")
      Cache.InicializaCacheCategoriasDescuentosRubros()
      OnReporteEstado("Inicializando Cache Descuentos Categoria/SubRubros")
      Cache.InicializaCacheCategoriasDescuentosSubRubros()
      OnReporteEstado("Inicializando Cache Descuentos Categoria/SubSubRubros")
      Cache.InicializaCacheCategoriasDescuentosSubSubRubros()

      Inicializar(Cache)

      OnReporteEstado("Fin Inicializacion")
   End Sub

   Private Sub OnReporteEstado(mensaje As String)
      OnReporteEstado(New CalculosDescuentosRecargosReporteEstadoEventArgs(mensaje))
   End Sub

   Protected Overridable Sub OnReporteEstado(e As CalculosDescuentosRecargosReporteEstadoEventArgs)
      My.Application.Log.WriteEntry(String.Format("Componente CalculosDescuentosRecargos {0} - {1:dd/MM/yyyy HH:mm:ss.fff}", e.Estado, Now), TraceEventType.Verbose)
      RaiseEvent ReporteEstado(Me, e)
   End Sub

   Public Function DescuentoRecargo(cliente As Entidades.Cliente, tipoComprobante As Entidades.TipoComprobante, formaPago As Entidades.VentaFormaPago,
                                    cantidadLineasVenta As Integer) As Decimal
      If cliente Is Nothing Or tipoComprobante Is Nothing Then Return 0
      Return DescuentoRecargo(cliente, tipoComprobante.GrabaLibro, tipoComprobante.EsPreElectronico, formaPago, cantidadLineasVenta)
   End Function

   Public Function DescuentoRecargo(cliente As Entidades.Cliente, producto As Entidades.Producto, cantidad As Decimal, decimalesRedondeoEnPrecio As Integer) As Reglas.DescuentoRecargoProducto
      VerificaInicializacion()
      If HabilitaDescuentoRecargoProducto Then
         Return Regla.DescuentoRecargo(cliente, producto.IdProducto, cantidad, decimalesRedondeoEnPrecio)
      Else
         Return New Reglas.DescuentoRecargoProducto()
      End If
   End Function

   Public Function DescuentoRecargo(cliente As Entidades.Cliente, grabaLibro As Boolean, esPreElectronico As Boolean, formaPago As Entidades.VentaFormaPago,
                                    cantidadLineasVenta As Integer) As Decimal
      VerificaInicializacion()
      Return Regla.DescuentoRecargo(cliente, grabaLibro, esPreElectronico, formaPago, cantidadLineasVenta)
   End Function


   Private Sub VerificaInicializacion()
      If Not _inicializado Then Inicializar() ' Throw New Exception("Componente de Calculo de Descuentos y Recargos no inicializada")
   End Sub

End Class
Public Class CalculosDescuentosRecargosReporteEstadoEventArgs
   Inherits EventArgs
   Private _estado As String
   Public ReadOnly Property Estado() As String
      Get
         Return _estado
      End Get
   End Property

   Public Sub New(estado As String)
      _estado = estado
   End Sub

End Class