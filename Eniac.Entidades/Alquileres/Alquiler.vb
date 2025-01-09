<Serializable()> _
<System.ComponentModel.Description("Alquiler")> _
Public Class Alquiler
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      NumeroContrato
      FechaContrato
      IdProducto
      FechaDesde
      FechaHasta
      esRenovable
      NombreCliente
      LocatarioNroDocumento
      LocatarioNombre
      LocatarioCargo
      ImporteAlquiler
      ImporteTraslado
      ImporteTotal
      PersonalCapacitado
      LugarER
      horaE
      horaR
      NombreProducto
      FechaRealFin
      IdEstado
      NombreEstado
      IdUsuario
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdCliente
   End Enum

   Private _NumeroContrato As Long
   Private _FechaContrato As Date
   Private _IdProducto As String
   Private _FechaDesde As Date
   Private _FechaHasta As Date
   Private _esRenovable As Boolean
   Private _LocatarioNroDocumento As Long
   Private _LocatarioNombre As String
   Private _LocatarioCargo As String
   Private _ImporteAlquiler As Decimal
   Private _ImporteTraslado As Decimal
   Private _ImporteTotal As Decimal
   Private _PersonalCapacitado As String
   Private _LugarER As String
   Private _horaE As String
   Private _horaR As String
   Private _NombreProducto As String
   Private _FechaRealFin As Date
   Private _idEstado As Integer
   Private _idUsuario As String
   Private _idTipoComprobante As String
   Private _letra As String
   Private _centroEmisor As Short
   Private _numeroComprobante As Long
   Private _IdCliente As Long


   Public Property NumeroContrato() As Long
      Get
         Return _NumeroContrato
      End Get
      Set(ByVal value As Long)
         _NumeroContrato = value
      End Set
   End Property
   Public Property FechaContrato() As Date
      Get
         Return _FechaContrato
      End Get
      Set(ByVal value As Date)
         _FechaContrato = value
      End Set
   End Property
   Public Property FechaDesde() As Date
      Get
         Return _FechaDesde
      End Get
      Set(ByVal value As Date)
         _FechaDesde = value
      End Set
   End Property
   Public Property FechaHasta() As Date
      Get
         Return _FechaHasta
      End Get
      Set(ByVal value As Date)
         _FechaHasta = value
      End Set
   End Property
   Public Property esRenovable() As Boolean
      Get
         Return _esRenovable
      End Get
      Set(ByVal value As Boolean)
         _esRenovable = value
      End Set
   End Property

   Public Property LocatarioNroDocumento() As Long
      Get
         Return _LocatarioNroDocumento
      End Get
      Set(ByVal value As Long)
         _LocatarioNroDocumento = value
      End Set
   End Property
   Public Property LocatarioNombre() As String
      Get
         Return _LocatarioNombre
      End Get
      Set(ByVal value As String)
         _LocatarioNombre = value
      End Set
   End Property
   Public Property LocatarioCargo() As String
      Get
         Return _LocatarioCargo
      End Get
      Set(ByVal value As String)
         _LocatarioCargo = value
      End Set
   End Property

   Public Property ImporteAlquiler() As Decimal
      Get
         Return _ImporteAlquiler
      End Get
      Set(ByVal value As Decimal)
         _ImporteAlquiler = value
      End Set
   End Property

   Public Property ImporteTraslado() As Decimal
      Get
         Return _ImporteTraslado
      End Get
      Set(ByVal value As Decimal)
         _ImporteTraslado = value
      End Set
   End Property

   Public Property ImporteTotal() As Decimal
      Get
         Return _ImporteTotal
      End Get
      Set(ByVal value As Decimal)
         _ImporteTotal = value
      End Set
   End Property

   Public Property IdProducto() As String
      Get
         Return _IdProducto
      End Get
      Set(ByVal value As String)
         _IdProducto = value
      End Set
   End Property

   Public Property PersonalCapacitado() As String
      Get
         Return _PersonalCapacitado
      End Get
      Set(ByVal value As String)
         _PersonalCapacitado = value
      End Set
   End Property
   Public Property LugarER() As String
      Get
         Return _LugarER
      End Get
      Set(ByVal value As String)
         _LugarER = value
      End Set
   End Property
   Public Property horaE() As String
      Get
         Return _horaE
      End Get
      Set(ByVal value As String)
         _horaE = value
      End Set
   End Property

   Public Property horaR() As String
      Get
         Return _horaR
      End Get
      Set(ByVal value As String)
         _horaR = value
      End Set
   End Property
   Public Property NombreProducto() As String
      Get
         Return _NombreProducto
      End Get
      Set(ByVal value As String)
         _NombreProducto = value
      End Set
   End Property

   Public Property FechaRealFin() As Date
      Get
         Return _FechaRealFin
      End Get
      Set(ByVal value As Date)
         _FechaRealFin = value
      End Set
   End Property

   Public Property IdEstado() As Integer
      Get
         Return _idEstado
      End Get
      Set(ByVal value As Integer)
         _idEstado = value
      End Set
   End Property

   Public Property IdUsuario() As String
      Get
         Return _idUsuario
      End Get
      Set(ByVal value As String)
         _idUsuario = value
      End Set
   End Property

   Public Property IdTipoComprobante() As String
      Get
         Return Me._idTipoComprobante
      End Get
      Set(ByVal value As String)
         Me._idTipoComprobante = value
      End Set
   End Property

   Public Property Letra() As String
      Get
         Return Me._letra
      End Get
      Set(ByVal value As String)
         Me._letra = value
      End Set
   End Property

   Public Property CentroEmisor() As Short
      Get
         Return Me._centroEmisor
      End Get
      Set(ByVal value As Short)
         Me._centroEmisor = value
      End Set
   End Property

   Public Property NumeroComprobante() As Long
      Get
         Return Me._numeroComprobante
      End Get
      Set(ByVal value As Long)
         Me._numeroComprobante = value
      End Set
   End Property

   Public Property IdCliente() As Long
      Get
         Return _IdCliente
      End Get
      Set(ByVal value As Long)
         _IdCliente = value
      End Set
   End Property

End Class
