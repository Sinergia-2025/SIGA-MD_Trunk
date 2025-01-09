Public Class TurnoCalendario
   Inherits Entidad
   Public Const NombreTabla As String = "TurnosCalendarios"
   Public Enum Columnas
      IdTurno
      IdTurnoUnico
      IdCalendario
      FechaDesde
      FechaHasta
      IdCliente
      Observaciones
      IdTipoTurno
      IdProducto
      PrecioLista
      Precio
      DescuentoRecargoPorcGral
      DescuentoRecargoPorc1
      DescuentoRecargoPorc2
      PrecioNeto
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      NumeroSesion
      IdEstadoTurno
      IdEmbarcacion
      IdDestino
      DestinoLibre
      CantidadPasajeros
      FechaHoraLlegada
      IdPatenteVehiculo
   End Enum

   Public Sub New()
      TurnoProducto = New List(Of TurnosCalendariosProductos)()
      IdTurnoUnico = Guid.NewGuid().ToString()
      Activo = True
   End Sub
   Public Sub New(calendario As Calendario, fechaDesde As DateTime, fechaHasta As DateTime)
      Me.New()
      Me.Calendario = calendario
      Me.FechaDesde = fechaDesde
      Me.FechaHasta = fechaHasta

   End Sub

   Public Property IdTurno As Integer
   Public Property IdTurnoUnico As String
   'Public Property IdCalendario As Integer
   Public ReadOnly Property IdCalendario As Integer
      Get
         Return If(Calendario IsNot Nothing, Calendario.IdCalendario, 0)
      End Get
   End Property
   <System.Web.Script.Serialization.ScriptIgnore>
   Public Property Calendario As Entidades.Calendario
   <System.Web.Script.Serialization.ScriptIgnore>
   Public Property FechaDesde As DateTime
   <System.Web.Script.Serialization.ScriptIgnore>
   Public Property FechaHasta As DateTime

   Public Property FechaDesdeString As String
      Get
         Return FechaDesde.ToStringFormatoPropio()
      End Get
      Set(value As String)
         FechaDesde = value.ToDateTimeFormatoPropio()
      End Set
   End Property
   Public Property FechaHastaString As String
      Get
         Return FechaHasta.ToStringFormatoPropio()
      End Get
      Set(value As String)
         FechaHasta = value.ToDateTimeFormatoPropio()
      End Set
   End Property

   Public Property Observaciones As String

   Public Property IdPatenteVehiculo As String


   Public Property IdEmbarcacion As Long           'De SISEN. Solo la carga si estoy en SiSeN
   Public Property CodigoEmbarcacion As Long       'De SISEN. Solo para pantalla, no se persiste
   Public Property NombreEmbarcacion As String     'De SISEN. Solo para pantalla, no se persiste

   Public Property IdDestino As Short              'De SISEN. Solo la carga si estoy en SiSeN
   Public Property DestinoLibre As String          'De SISEN. Solo la carga si estoy en SiSeN
   Public Property CantidadPasajeros As Integer     'De SISEN. Solo la carga si estoy en SiSeN
   Public Property FechaHoraLlegada As DateTime?    'De SISEN. Solo la carga si estoy en SiSeN


   Public Property NumeroSesion As Integer
   Public Property IdCliente As Long
   Public Property CodigoCliente As Long           'No se persiste, solo para pantalla
   Public Property NombreCliente As String         'No se persiste, solo para pantalla

   Public Property IdTipoTurno As String
   Public Property NombreTipoTurno As String

   Public Property IdEstadoTurno As String
   Public Property NombreEstadoTurno As String

   Public Property IdProducto As String
   Public Property PrecioLista As Decimal?
   Public Property Precio As Decimal?
   Public Property DescuentoRecargoPorcGral As Decimal?
   Public Property DescuentoRecargoPorc1 As Decimal?
   Public Property DescuentoRecargoPorc2 As Decimal?
   Public Property PrecioNeto As Decimal?

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Short
   Public Property NumeroComprobante As Long

   Public Property Activo As Boolean   'Usado para sync con la web

   Public Property TurnoProducto() As List(Of TurnosCalendariosProductos)


End Class