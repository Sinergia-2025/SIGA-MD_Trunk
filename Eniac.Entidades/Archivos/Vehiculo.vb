Public Class Vehiculo
   Inherits Entidad
   Public Const NombreTabla As String = "Vehiculos"
   Public Enum Columnas
      PatenteVehiculo
      IdMarcaVehiculo
      DescripMarcaVehiculo
      IdModeloVehiculo
      DescripModeloVehiculo
      Color
      VencimientoSeguro
      Ruta
      Vtv
      Activo
      'IdCliente
      EstaAdentro

      IdTipoUnidad
      SubTipoUnidad
      AnioPatentamiento
      MedidasVehiculo
      LlantasVehiculo
      AuxilioVehiculo
      NeumaticosVehiculo
      OtrosVehiculo
      IdentificacionVehiculo
      ObservacionesVehiculo
      IdEstadoVehiculo

      PrecioCompra
      PrecioReferencia
      IdProductoReferencia
      PrecioLista

      IdMarcaOperacionIngreso
      AnioOperacionIngreso
      NumeroOperacionIngreso
      SecuenciaOperacionIngreso

   End Enum

   Public Sub New()
      Clientes = New List(Of VehiculoCliente)()
      EstadoVehiculo = New EstadoVehiculo()
      TipoUnidad = New ConcesionarioTipoUnidad()
      Activo = True
      LlantasVehiculo = ConcesionarioLlantasVehiculo.NA
      AuxilioVehiculo = Publicos.SiNo.NO
      IdentificacionVehiculo = Publicos.SiNo.NO
      AnioPatentamiento = Date.Today.Year

   End Sub

   Public Property PatenteVehiculo As String
   Public Property IdMarcaVehiculo As Integer
   Public Property DescripMarcaVehiculo As String              'Para mostrar en pantalla, no se persiste.
   Public Property IdModeloVehiculo As Integer
   Public Property DescripModeloVehiculo As String             'Para mostrar en pantalla, no se persiste.
   Public Property Color As String
   Public Property VencimientoSeguro As Date
   Public Property Ruta As Date?
   Public Property Vtv As Date?
   Public Property Activo As Boolean
   ''Public Property IdCliente As Long
   Public Property Clientes As List(Of VehiculoCliente)
   Public Property EstaAdentro As Boolean

   Public Property TipoUnidad As ConcesionarioTipoUnidad
   Public Property SubTipoUnidad As String
   Public Property AnioPatentamiento As Integer
   Public Property MedidasVehiculo As String
   Public Property LlantasVehiculo As ConcesionarioLlantasVehiculo
   Public Property AuxilioVehiculo As Publicos.SiNo
   Public Property NeumaticosVehiculo As String
   Public Property OtrosVehiculo As String
   Public Property IdentificacionVehiculo As Publicos.SiNo
   Public Property ObservacionesVehiculo As String
   Public Property EstadoVehiculo As EstadoVehiculo

   Public Property PrecioCompra As Decimal
   Public Property PrecioReferencia As Decimal
   Public Property IdProductoReferencia As String
   Public Property NombreProductoReferencia As String
   Public Property PrecioLista As Decimal

   Public Property IdMarcaOperacionIngreso As Integer?
   Public Property AnioOperacionIngreso As Integer?
   Public Property NumeroOperacionIngreso As Integer?
   Public Property SecuenciaOperacionIngreso As Integer?
   Public Property CodigoOperacionIngreso As String         'Para mostrar en pantalla, no se persiste.


   Public Property HasValue As Boolean


   Public ReadOnly Property NombreTipoUnidad As String
      Get
         Return TipoUnidad.NombreTipoUnidad
      End Get
   End Property
   Public ReadOnly Property NombreEstadoVehiculo As String
      Get
         Return EstadoVehiculo.NombreEstadoVehiculo
      End Get
   End Property

End Class